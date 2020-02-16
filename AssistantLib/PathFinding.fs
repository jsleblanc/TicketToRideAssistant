namespace AssistantLib

open System
open Cities

module PathFinding =

    type plan_t = {
        start_city:city_t
        finish_city:city_t
        trains:int
        cities:(city_t * city_t) seq
        colored_trains:Map<color_t,int list>
    }
    
    type private tracked_t = {
        distance:int
        route:route_t option
        parent:city_t option
    }

    let private mapIncrement (map:Map<color_t,int list>) (k,v) =
        match map.TryGetValue k with
        | true, current -> Map.add k (current @ [v]) map
        | false, _ -> Map.add k [v] map
        
    let private shortestPath_i (routeLookup:Map<city_t,route_t seq>) (cities:city_t Set) (startCity:city_t) (endCity:city_t) =
        let default_tracked_t = { distance = Int32.MaxValue; parent = None; route = None; }
        let startState = Set.fold (fun (acc:Map<city_t,tracked_t>) city -> acc.Add (city, default_tracked_t)) (Map.empty<city_t,tracked_t>) cities
        let startState = startState.Add (startCity, { distance = 0; parent = None; route = None; })
        let add (m:Map<city_t,tracked_t>) toCity fromCity trains distance route =
            let current = m.[toCity]
            if current.distance = Int32.MaxValue then
                let newTracked = { current with distance = distance + trains; parent = Some fromCity; route = Some route; }
                m.Add(toCity, newTracked)
            else
                let newDistance = current.distance + trains + distance
                if current.distance > newDistance then
                    m.Add(toCity, { current with distance = newDistance; parent = Some fromCity; route = Some route; })
                else
                    m
        let rec func city state (visited:city_t Set) =
            let toVisit = routeLookup.[city] (* |> filterRoutes *) |> Seq.where (fun r -> (visited.Contains r.to_city) |> not) |> Seq.toList
            let newState = Seq.fold (fun acc r -> add acc r.to_city city r.trains acc.[city].distance r) state toVisit
            let newVisited = visited.Add city
            if newVisited.Contains endCity then
                let rec getPath (city:city_t) = seq {                    
                    yield state.[city].route
                    match state.[city].route with
                    | Some r -> yield! getPath r.from_city
                    | None -> yield! Seq.empty
                }
                let path = getPath endCity |> Seq.choose id |> Seq.rev |> Seq.toList
                {
                    start_city = startCity
                    finish_city = endCity
                    trains = state.[endCity].distance
                    cities = path |> Seq.map (fun r -> (r.from_city, r.to_city))
                    colored_trains = path |> Seq.map (fun r -> (r.color, r.trains)) |> Seq.fold (fun acc r -> mapIncrement acc r) Map.empty
                }
            else
                let nextCity = Map.toSeq newState |> Seq.where (fun (c,_) -> newVisited.Contains c |> not) |> Seq.where (fun (_,t) -> t.distance > 0) |> Seq.minBy (fun (_,t) -> t.distance) |> (fun (c,_) -> c)
                func nextCity newState newVisited
        func startCity startState Set.empty    
    
    let private total counts = List.fold (fun acc v -> (acc + v)) 0 counts

    let private items counts = List.fold (fun acc v -> acc + (sprintf "%d, " v)) "" counts  
    
    let shortestPath = shortestPath_i getRoutes getCitiesSet
    
    let printPlan plan =
        printfn "%s to %s requires %d trains" plan.start_city.name plan.finish_city.name plan.trains
        printfn "Connecting through"
        plan.cities |> Seq.iter (fun (f,t) -> printfn "\t%s to %s" f.name t.name)
        printfn "Train Colors Required"
        plan.colored_trains
        |> Map.iter (fun c counts -> printfn "\t%s %d (%s)" (c.ToString()) (total counts) (items counts))
            
            
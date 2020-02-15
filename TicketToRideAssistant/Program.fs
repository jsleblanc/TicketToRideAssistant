// Learn more about F# at http://fsharp.org

open System
open System
open System
open System.Runtime.CompilerServices

open TicketToRideAssistant.Cities
open TicketToRideAssistant.PathFinding
open TicketToRideAssistant

open TicketToRideAssistant
(*
type color_t =
    | Blue
    | Green
    | Red
    | Black
    | Orange
    | White
    | Yellow
    | Pink

type city_t = {
    name:string;
}

type route_t = {
    from_city:city_t
    to_city:city_t
    trains:int
    color:color_t option
}

type tracked_t = {
    distance:int
    route:route_t option
    parent:city_t option
}

type plan_t = {
    start_city:city_t
    finish_city:city_t
    trains:int
    cities:city_t seq
    colored_trains:Map<color_t,int>
}
*)

[<EntryPoint>]
let main argv =
    
    let c = getCities
    let sp = shortestPath getRoutes getCitiesSet
    let result = sp c.vancouver c.miami
    printPlan result
    
    printfn "done"
    
    (*
    
    let vancouver = { name = "Vancouver" }
    let seattle = { name = "Seattle" }
    let portland = { name = "Portland" }
    let calgary = { name = "Calgary" }
    let helena = { name = "Helena" }
    let winnipeg = { name = "Winnipeg" }
    let saltlake = { name = "Salt Lake City" }
    let sanfran = { name = "San Francisco" }
    let duluth = { name = "Duluth" }
    let omaha = { name = "Omaha" }
    let denver = { name = "Denver" }
    let saultmarie = { name = "Sault St. Marie" }
    let toronto = { name = "Toronto" }
    let montreal = { name = "Montreal" }
    let chicago = { name = "Chicago" }
    let kansas = { name = "Kansas City" }
    let vegas = { name = "Las Vegas" }
    let losangeles = { name = "Los Angeles" }
    let phoenix = { name = "Phoenix" }
    let elpaso = { name = "El Paso" }
    let santafe = { name = "Santa Fe" }
    let oaklahoma = { name = "Oaklahoma City" }
    let saintlouis = { name = "Saint Louis" }
    let nashville = { name = "Nashville" }
    let pittsburgh = { name = "Pittsburgh" }
    let boston = { name = "Boston" }
    let newyork = { name = "New York" }
    let washington = { name = "Washington" }
    let raleigh = { name = "Raleigh" }
    let atlanta = { name = "Atlanta" }
    let charleston = { name = "Charleston" }
    let littlerock = { name = "Little Rock" }
    let dallas = { name = "Dallas" }
    let houston = { name = "Houston" }
    let neworleans = { name = "New Orleans" }
    let miami = { name = "Miami" }
    
    let routes = seq {
        { from_city = vancouver; to_city = seattle; trains = 1; color = None; }
        { from_city = seattle; to_city = portland; trains = 1; color = None; }
        { from_city = vancouver; to_city = calgary; trains = 3; color = None; }
        { from_city = seattle; to_city = calgary; trains = 4; color = None; }
        { from_city = calgary; to_city = helena; trains = 4; color = None; }
        { from_city = seattle; to_city = helena; trains = 6; color = Some Yellow; }
        { from_city = calgary; to_city = winnipeg; trains = 6; color = Some White; }
        { from_city = winnipeg; to_city = helena; trains = 4; color = Some Blue; }
        { from_city = portland; to_city = saltlake; trains = 6; color = Some Blue; }
        { from_city = helena; to_city = saltlake; trains = 3; color = Some Pink; }
        { from_city = portland; to_city = sanfran; trains = 5; color = Some Green; }
        { from_city = portland; to_city = sanfran; trains = 5; color = Some Pink; }
        { from_city = helena; to_city = duluth; trains = 6; color = Some Orange; }
        { from_city = winnipeg; to_city = duluth; trains = 4; color = Some Black; }
        { from_city = helena; to_city = omaha; trains = 5; color = Some Red; }
        { from_city = helena; to_city = denver; trains = 4; color = Some Green; }
        { from_city = sanfran; to_city = saltlake; trains = 5; color = Some Orange; }
        { from_city = sanfran; to_city = saltlake; trains = 5; color = Some White; }
        { from_city = saltlake; to_city = denver; trains = 3; color = Some Red; }
        { from_city = saltlake; to_city = denver; trains = 3; color = Some Yellow; }
        { from_city = denver; to_city = omaha; trains = 4; color = Some Pink; }
        { from_city = winnipeg; to_city = saultmarie; trains = 6; color = None; }
        { from_city = duluth; to_city = saultmarie; trains = 3; color = None; }
        { from_city = duluth; to_city = toronto; trains = 6; color = Some Pink; }
        { from_city = saultmarie; to_city = toronto; trains = 2; color = None; }
        { from_city = toronto; to_city = montreal; trains = 3; color = None; }
        { from_city = saultmarie; to_city = montreal; trains = 5; color = Some Black; }
        { from_city = duluth; to_city = omaha; trains = 2; color = None; }
        { from_city = duluth; to_city = chicago; trains = 3; color = Some Red; }
        { from_city = omaha; to_city = chicago; trains = 4; color = Some Blue; }
        { from_city = omaha; to_city = kansas; trains = 1; color = None; }
        { from_city = denver; to_city = kansas; trains = 4; color = Some Black; }
        { from_city = denver; to_city = kansas; trains = 4; color = Some Orange; }
        { from_city = saltlake; to_city = vegas; trains = 3; color = Some Orange; }
        { from_city = vegas; to_city = losangeles; trains = 2; color = None; }
        { from_city = sanfran; to_city = losangeles; trains = 3; color = Some Pink; }
        { from_city = sanfran; to_city = losangeles; trains = 3; color = Some Yellow; }
        { from_city = losangeles; to_city = phoenix; trains = 3; color = None; }
        { from_city = losangeles; to_city = elpaso; trains = 6; color = Some Black; }
        { from_city = phoenix; to_city = elpaso; trains = 3; color = None; }
        { from_city = phoenix; to_city = denver; trains = 5; color = Some White; }
        { from_city = phoenix; to_city = santafe; trains = 3; color = None; }
        { from_city = elpaso; to_city = santafe; trains = 2; color = None; }
        { from_city = santafe; to_city = denver; trains = 2; color = None; }
        { from_city = denver; to_city = oaklahoma; trains = 4; color = Some Red; }
        { from_city = santafe; to_city = oaklahoma; trains = 3; color = Some Blue; }
        { from_city = elpaso; to_city = oaklahoma; trains = 5; color = Some Yellow; }
        { from_city = elpaso; to_city = dallas; trains = 4; color = Some Red; }
        { from_city = elpaso; to_city = houston; trains = 6; color = Some Green; }
        { from_city = kansas; to_city = oaklahoma; trains = 2; color = None; }
        { from_city = oaklahoma; to_city = dallas; trains = 2; color = None; }
        { from_city = dallas; to_city = houston; trains = 1; color = None; }
        { from_city = kansas; to_city = saintlouis; trains = 2; color = Some Blue; }
        { from_city = kansas; to_city = saintlouis; trains = 2; color = Some Pink; }
        { from_city = oaklahoma; to_city = littlerock; trains = 2; color = None; }
        { from_city = dallas; to_city = littlerock; trains = 2; color = None; }
        { from_city = houston; to_city = neworleans; trains = 2; color = None; }
        { from_city = littlerock; to_city = neworleans; trains = 3; color = Some Green; }
        { from_city = littlerock; to_city = nashville; trains = 3; color = Some White; }
        { from_city = neworleans; to_city = miami; trains = 6; color = Some Red; }
        { from_city = atlanta; to_city = miami; trains = 5; color = Some Blue; }
        { from_city = charleston; to_city = miami; trains = 5; color = Some Pink; }
        { from_city = neworleans; to_city = atlanta; trains = 4; color = Some Yellow; }
        { from_city = neworleans; to_city = atlanta; trains = 4; color = Some Orange; }
        { from_city = toronto; to_city = chicago; trains = 4; color = Some White; }
        { from_city = chicago; to_city = saintlouis; trains = 2; color = Some Green; }
        { from_city = chicago; to_city = saintlouis; trains = 2; color = Some White; }
        { from_city = montreal; to_city = boston; trains = 2; color = None; }
        { from_city = montreal; to_city = newyork; trains = 3; color = Some Blue; }
        { from_city = toronto; to_city = pittsburgh; trains = 2; color = None; }
        { from_city = saintlouis; to_city = littlerock; trains = 2; color = None; }
        { from_city = saintlouis; to_city = nashville; trains = 2; color = None; }
        { from_city = nashville; to_city = atlanta; trains = 1; color = None; }
        { from_city = saintlouis; to_city = pittsburgh; trains = 5; color = Some Green; }
        { from_city = chicago; to_city = pittsburgh; trains = 3; color = Some Orange; }
        { from_city = chicago; to_city = pittsburgh; trains = 3; color = Some Black; }
        { from_city = pittsburgh; to_city = nashville; trains = 4; color = Some Yellow; }
        { from_city = pittsburgh; to_city = newyork; trains = 2; color = Some White; }
        { from_city = pittsburgh; to_city = newyork; trains = 2; color = Some Green; }
        { from_city = boston; to_city = newyork; trains = 2; color = Some Yellow; }
        { from_city = boston; to_city = newyork; trains = 2; color = Some Red; }
        { from_city = newyork; to_city = washington; trains = 2; color = Some Orange; }
        { from_city = newyork; to_city = washington; trains = 2; color = Some Black; }
        { from_city = pittsburgh; to_city = washington; trains = 2; color = None; }
        { from_city = pittsburgh; to_city = raleigh; trains = 2; color = None; }
        { from_city = nashville; to_city = raleigh; trains = 3; color = Some Black; }
        { from_city = atlanta; to_city = charleston; trains = 2; color = None; }
        { from_city = raleigh; to_city = charleston; trains = 2; color = None; }
        { from_city = atlanta; to_city = raleigh; trains = 2; color = None; }
        { from_city = raleigh; to_city = washington; trains = 2; color = None; }
    }
    
    let createOtherDirection (r:route_t) =
        seq {
            r
            { r with from_city = r.to_city; to_city = r.from_city; }
        }
    
    let cities =
        routes
        |> Seq.map (fun r -> [r.to_city; r.from_city])
        |> Seq.collect (fun c -> c)
        |> Seq.distinct
        |> Seq.toList
        |> Set.ofList
    
    let unavailableRoutes = Set.empty<route_t> //seq { { from_city = calgary; to_city = helena; trains = 4; color = None; } } |> Set.ofSeq
    
    let filterRoutes routes =
        routes
        |> Seq.where (fun r -> unavailableRoutes.Contains r |> not)
        |> Seq.groupBy (fun r -> r.to_city)
        |> Seq.map (fun (_,r) -> Seq.item(0) r)
        |> Seq.toList
        
    //TODO - Dijkstra's for shortest path
    //TODO - minimum spanning tree to find shortest connection that spans multiple nodes, ie: shortest path connecting x cities
            
    let mapIncrement (map:Map<color_t,int>) (k,v) =
        match map.TryGetValue k with
        | true, current -> Map.add k (current + v) map
        | false, _ -> Map.add k v map
     
    let f (x,y) =
        match (x,y) with
        | Some a, Some b -> Some (a,b)
        | _ -> None
            
    let shortestPath (startCity:city_t) endCity =
        let routeLookup =
            routes
            |> Seq.map createOtherDirection
            |> Seq.collect (fun s -> s)
            |> Seq.groupBy (fun r -> r.from_city)
            |> Map.ofSeq
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
                if current.distance > newDistance then m.Add(toCity, { current with distance = newDistance; parent = Some fromCity; route = Some route; }) else m
        let rec func city state (visited:city_t Set) =
            let toVisit = routeLookup.[city] |> filterRoutes |> Seq.where (fun r -> (visited.Contains r.to_city) |> not) |> Seq.toList
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
                    cities = path |> Seq.map (fun r -> r.from_city)
                    colored_trains = path |> Seq.map (fun r -> (r.color, Some r.trains)) |> Seq.map f |> Seq.choose id |> Seq.fold (fun acc r -> mapIncrement acc r) Map.empty
                }
            else
                let nextCity = Map.toSeq newState |> Seq.where (fun (c,_) -> newVisited.Contains c |> not) |> Seq.where (fun (_,t) -> t.distance > 0) |> Seq.minBy (fun (_,t) -> t.distance) |> (fun (c,_) -> c)
                func nextCity newState newVisited
        func startCity startState Set.empty
         

    let result = shortestPath calgary omaha
    
    printfn "Trains Required %d" result.trains
    printfn "Cities of route "
    result.cities |> Seq.iter (fun c -> printfn "%s" c.name)
    *)
    0 // return an integer exit code



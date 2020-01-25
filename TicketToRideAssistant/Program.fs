// Learn more about F# at http://fsharp.org

open System
open System
open System.Runtime.CompilerServices

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
    parent:city_t option
}

[<EntryPoint>]
let main argv =
    
    
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
    }
    
    let createOtherDirection (r:route_t) =
        seq {
            r
            { r with from_city = r.to_city; to_city = r.from_city; }
        }
    
    let cities = Set.ofList [
        vancouver
        seattle
        portland
        calgary
        helena
        winnipeg
        saltlake
        sanfran
        duluth
        omaha
        denver
        saultmarie
        toronto
        montreal
        chicago
        kansas
        vegas
        losangeles
        phoenix
        elpaso
        santafe
    ]
    
    let map =
        routes
        |> Seq.map createOtherDirection
        |> Seq.collect (fun s -> s)
        |> Seq.groupBy (fun r -> r.from_city)
        |> Map.ofSeq
    
    let filterRoutes routes =
        routes
        |> Seq.groupBy (fun r -> r.to_city)
        |> Seq.map (fun (_,r) -> Seq.item(0) r)
        |> Seq.toList
        
    //TODO - Dijkstra's for shortest path
    //TODO - minimum spanning tree to find shortest connection that spans multiple nodes, ie: shortest path connecting x cities
        

    let printVisited (v:city_t Set) =
        let s = Set.fold (fun acc c -> acc + c.name + ", ") "" v
        printfn "%s" s
    
    let shortestPath (startCity:city_t) endCity =
        let routeLookup =
            routes
            |> Seq.map createOtherDirection
            |> Seq.collect (fun s -> s)
            |> Seq.groupBy (fun r -> r.from_city)
            |> Map.ofSeq         
        let startState = Set.fold (fun (acc:Map<city_t,int>) city -> acc.Add (city, Int32.MaxValue)) (Map.empty<city_t,int>) cities
        let startState = startState.Add (startCity, 0)
        let add (m:Map<city_t,int>) toCity trains distance =
            if m.[toCity] = Int32.MaxValue then
                m.Add(toCity,distance + trains)
            else
                let value = m.[toCity] + trains + distance
                if m.[toCity] > value then m.Add(toCity, value) else m
        let rec func city state (visited:city_t Set) =
            let toVisit = routeLookup.[city] |> filterRoutes |> Seq.where (fun r -> (visited.Contains r.to_city) |> not) |> Seq.toList
            let newState = Seq.fold (fun acc r -> add acc r.to_city r.trains acc.[city]) state toVisit
            let newVisited = visited.Add city //List.fold (fun acc r -> Set.add r.to_city acc) visited toVisit
            if newVisited.Contains endCity then
                endCity
            else
                let nextCity = Map.toSeq newState |> Seq.where (fun (c,_) -> newVisited.Contains c |> not) |> Seq.where (fun (_,t) -> t > 0) |> Seq.minBy (fun (_,t) -> t) |> (fun (c,_) -> c)
                func nextCity newState newVisited
        func startCity startState Set.empty
         

    let result = shortestPath sanfran denver 
             
    printfn "Hello World from F#!"
    
    0 // return an integer exit code



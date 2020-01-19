// Learn more about F# at http://fsharp.org

open System

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
    to_city:city_t;
    trains:int
    color:color_t option;
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
    let saultmaria = { name = "Sault St. Marie" }
    let toronto = { name = "Toronto" }
    let montreal = { name = "Montreal" }
    let chicago = { name = "Chicago" }
    
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
        { from_city = winnipeg; to_city = saultmaria; trains = 6; color = None; }
        { from_city = duluth; to_city = saultmaria; trains = 3; color = None; }
        { from_city = duluth; to_city = toronto; trains = 6; color = Some Pink; }
        { from_city = saultmaria; to_city = toronto; trains = 2; color = None; }
        { from_city = toronto; to_city = montreal; trains = 3; color = None; }
        { from_city = saultmaria; to_city = montreal; trains = 5; color = Some Black; }
        { from_city = duluth; to_city = omaha; trains = 2; color = None; }
        { from_city = duluth; to_city = chicago; trains = 3; color = Some Red; }
        { from_city = omaha; to_city = chicago; trains = 4; color = Some Blue; }
    }
    
    let createOtherDirection (r:route_t) =
        seq {
            r
            { r with from_city = r.to_city; to_city = r.from_city; }
        }
    
    let map =
        routes
        |> Seq.map createOtherDirection
        |> Seq.collect (fun s -> s)
        |> Seq.groupBy (fun r -> r.from_city)
        |> Map.ofSeq
    
    let connections = map.[calgary]
    
    printfn "Hello World from F#!"
    
    0 // return an integer exit code

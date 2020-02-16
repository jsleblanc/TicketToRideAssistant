// Learn more about F# at http://fsharp.org

open AssistantLib.Cities
open AssistantLib.PathFinding

[<EntryPoint>]
let main argv =
    
    let c = getCities 
    let result = shortestPath c.vancouver c.miami
    printPlan result
    
    printfn "done"
    0



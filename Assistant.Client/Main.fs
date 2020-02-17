module Assistant.Client.Main

open AssistantLib
open Elmish
open Bolero
open Bolero.Html
open AssistantLib.PathFinding

type Model = {
    value: int
    plan: string
}
let initModel = {
    value = 0
    plan = ""
}

type Message =
    | Increment
    | Decrement
    | TTR
    
let update message model =
    match message with
    | Increment -> { model with value = model.value + 1 }
    | Decrement -> { model with value = model.value - 1 }
    | TTR ->
        let c = Cities.getCities
        let plan = shortestPath c.vancouver c.miami
        let s = sprintf "%s to %s requires %d trains" plan.start_city.name plan.finish_city.name plan.trains
        { model with plan = s }

let view model dispatch =
    div [] [
        button [on.click (fun _ -> dispatch Decrement)] [text "-"]
        text (string model.value)
        button [on.click (fun _ -> dispatch Increment)] [text "+"]        
        button [on.click (fun _ -> dispatch TTR)] [text "TTR plan"]
        text (string model.plan)
    ]
    
type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view

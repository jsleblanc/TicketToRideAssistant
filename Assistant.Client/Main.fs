module Assistant.Client.Main

open AssistantLib
open Elmish
open Bolero
open Bolero.Html
open AssistantLib.Cities
open AssistantLib.PathFinding
open Bolero.Html
open Bolero.Html
open Bolero.Html

type Graphictemplate = Template<"TTR_Map_Vector.html">

type Model = {
    value: int
    plan: string
    cities:city_t list
}
let initModel = {
    value = 0
    plan = ""
    cities = []
}

let addCity model city =
    if List.length model.cities = 2 then
        let last = List.item(1) model.cities
        { model with cities = [last;city] }
    else
        { model with cities = model.cities @ [city] }

let showCities model =
    List.fold (fun acc e -> sprintf "%s, %s" acc e.name) "" model.cities

type Message =
    | Increment
    | Decrement
    | Charleston
    | Atlanta
    | Nashville
    | Miami
    | NewOrleans
    | SaintLouis
    | Chicago
    | Pittsburgh
    | KansasCity
    | Omaha
    | Dallas
    | Houston
    | Denver
    | SaltLakeCity
    | Helena
    | Duluth
    | LosAngeles
    | SanFrancisco
    | Portland
    | Seattle
    | Phoenix
    //| SelectCity of string
    
let update message model =
    let c = getCities
    match message with
    | Increment -> { model with value = model.value + 1 }
    | Decrement -> { model with value = model.value - 1 }
    | Atlanta -> addCity model c.atlanta 
    | Nashville -> addCity model c.nashville
    | Miami -> addCity model c.miami
    | NewOrleans -> addCity model c.neworleans
    | SaintLouis -> addCity model c.saintlouis
    | Chicago -> addCity model c.chicago
    | Pittsburgh -> addCity model c.pittsburgh
    | KansasCity -> addCity model c.kansas
    | Omaha -> addCity model c.omaha
    | Dallas -> addCity model c.dallas
    | Houston -> addCity model c.houston
    | Denver -> addCity model c.denver
    | SaltLakeCity -> addCity model c.saltlake
    | Helena -> addCity model c.helena
    | Duluth -> addCity model c.duluth
    | LosAngeles -> addCity model c.losangeles
    | SanFrancisco -> addCity model c.sanfran
    | Portland -> addCity model c.portland
    | Seattle -> addCity model c.seattle
    | Phoenix -> addCity model c.phoenix
    (*
    | TTR ->
        let c = Cities.getCities
        let plan = shortestPath c.vancouver c.miami
        let s = sprintf "%s to %s requires %d trains" plan.start_city.name plan.finish_city.name plan.trains
        { model with plan = s }
*)
let view model dispatch =
    div [] [
        div [] [
            //button [on.click (fun _ -> dispatch Decrement)] [text "-"]
            text (string (showCities model))
            //button [on.click (fun _ -> dispatch Increment)] [text "+"]        
            //button [on.click (fun _ -> dispatch TTR)] [text "TTR plan"]
            text (string model.plan)
        ]        
        div [] [
            Graphictemplate
                .ttrMap()
                .Atlanta(fun _ -> dispatch Message.Atlanta)
                .Nashville(fun _ -> dispatch Message.Nashville)
                .Miami(fun _ -> dispatch Message.Miami)
                .NewOrleans(fun _ -> dispatch Message.NewOrleans)
                .SaintLouis(fun _ -> dispatch Message.SaintLouis)
                .Chicago(fun _ -> dispatch Message.Chicago)
                .Pittsburgh(fun _ -> dispatch Message.Pittsburgh)
                .KansasCity(fun _ -> dispatch Message.KansasCity)
                .Omaha(fun _ -> dispatch Message.Omaha)
                .Dallas(fun _ -> dispatch Message.Dallas)
                .Houston(fun _ -> dispatch Message.Houston)
                .Denver(fun _ -> dispatch Message.Denver)
                .SaltLakeCity(fun _ -> dispatch Message.SaltLakeCity)
                .Helena(fun _ -> dispatch Message.Helena)
                .Duluth(fun _ -> dispatch Message.Duluth)
                .LosAngeles(fun _ -> dispatch Message.LosAngeles)
                .SanFrancisco(fun _ -> dispatch Message.SanFrancisco)
                .Portland(fun _ -> dispatch Message.Portland)
                .Seattle(fun _ -> dispatch Message.Seattle)
                .Phoenix(fun _ -> dispatch Message.Phoenix)
                .Elt()
        ]
    ]
    
    
type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view

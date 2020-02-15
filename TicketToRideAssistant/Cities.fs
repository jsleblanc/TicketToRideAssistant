namespace TicketToRideAssistant

module Cities =

    type city_t = {
        name:string;
    }

    type cities_t = {
        vancouver:city_t
        seattle:city_t
        portland:city_t
        calgary:city_t
        helena:city_t
        winnipeg:city_t
        saltlake:city_t
        sanfran:city_t
        duluth:city_t
        omaha:city_t
        denver:city_t
        saultmarie:city_t
        toronto:city_t
        montreal:city_t
        chicago:city_t
        kansas:city_t
        vegas:city_t
        losangeles:city_t
        phoenix:city_t
        elpaso:city_t
        santafe:city_t
        oaklahoma:city_t
        saintlouis:city_t
        nashville:city_t
        pittsburgh:city_t
        boston:city_t
        newyork:city_t
        washington:city_t
        raleigh:city_t
        atlanta:city_t
        charleston:city_t
        littlerock:city_t
        dallas:city_t
        houston:city_t
        neworleans:city_t
        miami:city_t
    }
    
    let getCities = {
        vancouver = { name = "Vancouver" }
        seattle = { name = "Seattle" }
        portland = { name = "Portland" }
        calgary = { name = "Calgary" }
        helena = { name = "Helena" }
        winnipeg = { name = "Winnipeg" }
        saltlake = { name = "Salt Lake City" }
        sanfran = { name = "San Francisco" }
        duluth = { name = "Duluth" }
        omaha = { name = "Omaha" }
        denver = { name = "Denver" }
        saultmarie = { name = "Sault St. Marie" }
        toronto = { name = "Toronto" }
        montreal = { name = "Montreal" }
        chicago = { name = "Chicago" }
        kansas = { name = "Kansas City" }
        vegas = { name = "Las Vegas" }
        losangeles = { name = "Los Angeles" }
        phoenix = { name = "Phoenix" }
        elpaso = { name = "El Paso" }
        santafe = { name = "Santa Fe" }
        oaklahoma = { name = "Oaklahoma City" }
        saintlouis = { name = "Saint Louis" }
        nashville = { name = "Nashville" }
        pittsburgh = { name = "Pittsburgh" }
        boston = { name = "Boston" }
        newyork = { name = "New York" }
        washington = { name = "Washington" }
        raleigh = { name = "Raleigh" }
        atlanta = { name = "Atlanta" }
        charleston = { name = "Charleston" }
        littlerock = { name = "Little Rock" }
        dallas = { name = "Dallas" }
        houston = { name = "Houston" }
        neworleans = { name = "New Orleans" }
        miami = { name = "Miami" }
    }
    
    let getCitiesSet =
        let c = getCities
        seq {
            c.vancouver
            c.vancouver;
            c.seattle;
            c.portland
            c.calgary
            c.helena
            c.winnipeg
            c.saltlake
            c.sanfran
            c.duluth
            c.omaha
            c.denver
            c.saultmarie
            c.toronto
            c.montreal
            c.chicago
            c.kansas
            c.vegas
            c.losangeles
            c.phoenix
            c.elpaso
            c.santafe
            c.oaklahoma
            c.saintlouis
            c.nashville
            c.pittsburgh
            c.boston
            c.newyork
            c.washington
            c.raleigh
            c.atlanta
            c.charleston
            c.littlerock
            c.dallas
            c.houston
            c.neworleans
            c.miami
        } |> Set.ofSeq
    
    type color_t =
    | Blue
    | Green
    | Red
    | Black
    | Orange
    | White
    | Yellow
    | Pink
    | Grey
    
    type route_t = {
        from_city:city_t
        to_city:city_t
        trains:int
        color:color_t
    }
    
    let getRoutes =
        let c = getCities
        let oneWay = seq {
            { from_city = c.vancouver; to_city = c.seattle; trains = 1; color = Grey; }
            { from_city = c.seattle; to_city = c.portland; trains = 1; color = Grey; }
            { from_city = c.vancouver; to_city = c.calgary; trains = 3; color = Grey; }
            { from_city = c.seattle; to_city = c.calgary; trains = 4; color = Grey; }
            { from_city = c.calgary; to_city = c.helena; trains = 4; color = Grey; }
            { from_city = c.seattle; to_city = c.helena; trains = 6; color = Yellow; }
            { from_city = c.calgary; to_city = c.winnipeg; trains = 6; color = White; }
            { from_city = c.winnipeg; to_city = c.helena; trains = 4; color = Blue; }
            { from_city = c.portland; to_city = c.saltlake; trains = 6; color = Blue; }
            { from_city = c.helena; to_city = c.saltlake; trains = 3; color = Pink; }
            { from_city = c.portland; to_city = c.sanfran; trains = 5; color = Green; }
            { from_city = c.portland; to_city = c.sanfran; trains = 5; color = Pink; }
            { from_city = c.helena; to_city = c.duluth; trains = 6; color = Orange; }
            { from_city = c.winnipeg; to_city = c.duluth; trains = 4; color = Black; }
            { from_city = c.helena; to_city = c.omaha; trains = 5; color = Red; }
            { from_city = c.helena; to_city = c.denver; trains = 4; color = Green; }
            { from_city = c.sanfran; to_city = c.saltlake; trains = 5; color = White; }
            { from_city = c.saltlake; to_city = c.denver; trains = 3; color = Red; }
            { from_city = c.saltlake; to_city = c.denver; trains = 3; color = Yellow; }
            { from_city = c.denver; to_city = c.omaha; trains = 4; color = Pink; }
            { from_city = c.winnipeg; to_city = c.saultmarie; trains = 6; color = Grey; }
            { from_city = c.duluth; to_city = c.saultmarie; trains = 3; color = Grey; }
            { from_city = c.duluth; to_city = c.toronto; trains = 6; color = Pink; }
            { from_city = c.saultmarie; to_city = c.toronto; trains = 2; color = Grey; }
            { from_city = c.toronto; to_city = c.montreal; trains = 3; color = Grey; }
            { from_city = c.saultmarie; to_city = c.montreal; trains = 5; color = Black; }
            { from_city = c.duluth; to_city = c.omaha; trains = 2; color = Grey; }
            { from_city = c.duluth; to_city = c.chicago; trains = 3; color = Red; }
            { from_city = c.omaha; to_city = c.chicago; trains = 4; color = Blue; }
            { from_city = c.omaha; to_city = c.kansas; trains = 1; color = Grey; }
            { from_city = c.denver; to_city = c.kansas; trains = 4; color = Black; }
            { from_city = c.denver; to_city = c.kansas; trains = 4; color = Orange; }
            { from_city = c.saltlake; to_city = c.vegas; trains = 3; color = Orange; }
            { from_city = c.vegas; to_city = c.losangeles; trains = 2; color = Grey; }
            { from_city = c.sanfran; to_city = c.losangeles; trains = 3; color = Pink; }
            { from_city = c.sanfran; to_city = c.losangeles; trains = 3; color = Yellow; }
            { from_city = c.losangeles; to_city = c.phoenix; trains = 3; color = Grey; }
            { from_city = c.losangeles; to_city = c.elpaso; trains = 6; color = Black; }
            { from_city = c.phoenix; to_city = c.elpaso; trains = 3; color = Grey; }
            { from_city = c.phoenix; to_city = c.denver; trains = 5; color = White; }
            { from_city = c.phoenix; to_city = c.santafe; trains = 3; color = Grey; }
            { from_city = c.elpaso; to_city = c.santafe; trains = 2; color = Grey; }
            { from_city = c.santafe; to_city = c.denver; trains = 2; color = Grey; }
            { from_city = c.denver; to_city = c.oaklahoma; trains = 4; color = Red; }
            { from_city = c.santafe; to_city = c.oaklahoma; trains = 3; color = Blue; }
            { from_city = c.elpaso; to_city = c.oaklahoma; trains = 5; color = Yellow; }
            { from_city = c.elpaso; to_city = c.dallas; trains = 4; color = Red; }
            { from_city = c.elpaso; to_city = c.houston; trains = 6; color = Green; }
            { from_city = c.kansas; to_city = c.oaklahoma; trains = 2; color = Grey; }
            { from_city = c.oaklahoma; to_city = c.dallas; trains = 2; color = Grey; }
            { from_city = c.dallas; to_city = c.houston; trains = 1; color = Grey; }
            { from_city = c.kansas; to_city = c.saintlouis; trains = 2; color = Blue; }
            { from_city = c.kansas; to_city = c.saintlouis; trains = 2; color = Pink; }
            { from_city = c.oaklahoma; to_city = c.littlerock; trains = 2; color = Grey; }
            { from_city = c.dallas; to_city = c.littlerock; trains = 2; color = Grey; }
            { from_city = c.houston; to_city = c.neworleans; trains = 2; color = Grey; }
            { from_city = c.littlerock; to_city = c.neworleans; trains = 3; color = Green; }
            { from_city = c.littlerock; to_city = c.nashville; trains = 3; color = White; }
            { from_city = c.neworleans; to_city = c.miami; trains = 6; color = Red; }
            { from_city = c.atlanta; to_city = c.miami; trains = 5; color = Blue; }
            { from_city = c.charleston; to_city = c.miami; trains = 5; color = Pink; }
            { from_city = c.neworleans; to_city = c.atlanta; trains = 4; color = Yellow; }
            { from_city = c.neworleans; to_city = c.atlanta; trains = 4; color = Orange; }
            { from_city = c.toronto; to_city = c.chicago; trains = 4; color = White; }
            { from_city = c.chicago; to_city = c.saintlouis; trains = 2; color = Green; }
            { from_city = c.chicago; to_city = c.saintlouis; trains = 2; color = White; }
            { from_city = c.montreal; to_city = c.boston; trains = 2; color = Grey; }
            { from_city = c.montreal; to_city = c.newyork; trains = 3; color = Blue; }
            { from_city = c.toronto; to_city = c.pittsburgh; trains = 2; color = Grey; }
            { from_city = c.saintlouis; to_city = c.littlerock; trains = 2; color = Grey; }
            { from_city = c.saintlouis; to_city = c.nashville; trains = 2; color = Grey; }
            { from_city = c.nashville; to_city = c.atlanta; trains = 1; color = Grey; }
            { from_city = c.saintlouis; to_city = c.pittsburgh; trains = 5; color = Green; }
            { from_city = c.chicago; to_city = c.pittsburgh; trains = 3; color = Orange; }
            { from_city = c.chicago; to_city = c.pittsburgh; trains = 3; color = Black; }
            { from_city = c.pittsburgh; to_city = c.nashville; trains = 4; color = Yellow; }
            { from_city = c.pittsburgh; to_city = c.newyork; trains = 2; color = White; }
            { from_city = c.pittsburgh; to_city = c.newyork; trains = 2; color = Green; }
            { from_city = c.boston; to_city = c.newyork; trains = 2; color = Yellow; }
            { from_city = c.boston; to_city = c.newyork; trains = 2; color = Red; }
            { from_city = c.newyork; to_city = c.washington; trains = 2; color = Orange; }
            { from_city = c.newyork; to_city = c.washington; trains = 2; color = Black; }
            { from_city = c.pittsburgh; to_city = c.washington; trains = 2; color = Grey; }
            { from_city = c.pittsburgh; to_city = c.raleigh; trains = 2; color = Grey; }
            { from_city = c.nashville; to_city = c.raleigh; trains = 3; color = Black; }
            { from_city = c.atlanta; to_city = c.charleston; trains = 2; color = Grey; }
            { from_city = c.raleigh; to_city = c.charleston; trains = 2; color = Grey; }
            { from_city = c.atlanta; to_city = c.raleigh; trains = 2; color = Grey; }
            { from_city = c.raleigh; to_city = c.washington; trains = 2; color = Grey; }
        }
        let createOtherDirection (r:route_t) = seq {
            r
            { r with from_city = r.to_city; to_city = r.from_city; }
        }
        oneWay
        |> Seq.map createOtherDirection
        |> Seq.collect (fun s -> s)
        |> Seq.groupBy (fun r -> r.from_city)
        |> Map.ofSeq
            
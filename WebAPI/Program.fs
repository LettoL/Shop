open System
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Startup

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
      .ConfigureWebHostDefaults(fun webHostBuiler ->
        webHostBuiler
          .Configure(configureApp)
          .ConfigureServices(configureServices)
          |> ignore)
      .Build()
      .Run()
    0 

module Startup

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe

let webApp =
  choose [
    route "/ping" >=> text "pong"
    route "/" >=> text "/"
  ]
  
let configureApp (app: IApplicationBuilder) =
  app.UseGiraffe webApp
  
let configureServices (services: IServiceCollection) =
  services.AddGiraffe() |> ignore
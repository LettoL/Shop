module InMemoryData.ProductData

open System.Collections
open Domain.Product



type Query = All
  
type Command = Create of ShippedProduct

let data = Hashtable()

let commandsHandler command =
  match command with
  | Create event ->
    data.Add(event.Date.ToString(), event)
    event
    
let queriesHandler query =
  match query with
  | All -> data.Values |> Seq.cast |> Array.ofSeq
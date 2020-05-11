module InMemoryData.ProductData

open System
open System.Collections

type ShippedProduct = {
  Id: int
  Date: DateTime
  ProductId: int
  Amount: int
}

type Query = All
  
type Command = Create of ShippedProduct * Hashtable

let data = Hashtable()

let commandsHandler command =
  match command with
  | Create (event, data) ->
    data.Add(event.Id, event)
    event.Id
    
let queriesHandler query =
  match query with
  | All -> data.Values |> Seq.cast |> Array.ofSeq
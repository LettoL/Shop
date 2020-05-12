module InMemoryData.SaleData

open System.Collections
open Domain.Sale

type Query =
  | All
  
type Command =
  | Create of Sale

let data = Hashtable()

let commandsHandler command =
  match command with
  | Create sale ->
    data.Add(sale.Id, sale)
    sale.Id
  
let queriesHandler query =
  match query with
  | All -> data.Values |> Seq.cast |> Array.ofSeq
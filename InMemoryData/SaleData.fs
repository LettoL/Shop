module InMemoryData.SaleData

open System.Collections

type Sale = {
  Id: int
}

type Query =
  | All
  
type Command =
  | Create of Sale * Hashtable

let data = Hashtable()

let commandsHandler command =
  match command with
  | Create (sale, data) ->
    data.Add(sale.Id, sale)
    sale.Id
  
let queriesHandler query =
  match query with
  | All -> data.Values |> Seq.cast |> Array.ofSeq
module Tests.Domain.Sale

open System
open Domain.Sale
open FsCheck.Xunit
  
[<Property>]
let ``Sum cost of products equals sum of sale`` (products: list<SoldProduct>) =
  products
  |> List.map(fun x -> x.Cost * (decimal x.Amount))
  |> List.sum = (createSale products DateTime.Now).Sum
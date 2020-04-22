module Tests.Domain.Sale

open Domain.Sale
open FsCheck.Xunit
  
[<Property>]
let ``Sum cost of products equals sum of sale`` (products: list<SoldProduct>) =
  products
  |> List.map(fun x -> x.Cost * (decimal x.Amount))
  |> List.sum = calculationCostProducts products
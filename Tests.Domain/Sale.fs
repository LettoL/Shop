module Tests.Domain.Sale

open System
open Domain.Sale
open FsCheck
open FsCheck.Xunit

let sum x y =
  x + y
  //match x with
  //| x when x <= 3 -> 10
  //| _ -> x + y

[<Property>]
let ``Reverse of reverse of a list is the original list ``(xs:list<int>) =
  List.rev(List.rev xs) = xs
  
[<Property>]
let ``Sum is shit``(x:int, y:int) =
  sum x y = x + y
  
[<Property>]
let ``Sum cost of products equals sum of sale`` (products: list<Product>) =
  products
  |> List.map(fun x -> x.Cost * (decimal x.Amount))
  |> List.sum = (createSale products DateTime.Now).Sum
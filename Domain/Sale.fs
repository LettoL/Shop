module Domain.Sale

open System

type SoldProduct = {
    ProductId: int
    Amount: int
    Cost: decimal
}

type CreatedSale = {
    Products: SoldProduct list
    Date: DateTime
    Sum: decimal
}

let createSale products date =
    
    let createdSale = {
        Products = products
        Date = date
        Sum = products
               |> List.map(fun x -> (decimal x.Amount) * x.Cost)
               |> List.sum
    }
    createdSale
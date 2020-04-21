module Domain.Sale

open System

type Product = {
    ProductId: int
    Amount: int
    Cost: decimal
}

type CreatedSale = {
    Products: Product list
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
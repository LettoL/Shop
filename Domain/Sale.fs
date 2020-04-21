module Domain.Sale

open System

type SoldProduct = {
    ProductId: int
    Amount: int
    Cost: decimal
}

type PaymentType = Cash | Cashless
type DepositedMoney = {
    Sum: decimal
    PaymentType: PaymentType
}

type CreatedSale = {
    Products: SoldProduct list
    Date: DateTime
    Sum: decimal
    DepositedMoneys: DepositedMoney list
}

let createSale products date moneys =
        
    let createdSale = {
        Products = products
        Date = date
        Sum = products
               |> List.map(fun x -> (decimal x.Amount) * x.Cost)
               |> List.sum
        DepositedMoneys = moneys
    }
    createdSale
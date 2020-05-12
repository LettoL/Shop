module Domain.Sale

open System
open Domain.Product

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

type SaleCreate = {
  Id: Guid
  Date: DateTime
  Products: SoldProduct list
  Moneys: DepositedMoney list
}

type Sale = {
  Id: Guid
  Date: DateTime
  Products: SoldProduct list
  Moneys: DepositedMoney list
  Sum: decimal
}

type CreatedSale = {
    Sale: Sale
    ShippedProducts: ShippedProduct list
    DepositedMoneys: DepositedMoney list
}

type SaleCreateError =
    | DepositedSumNotEqualCostProducts

let calculationCostProducts =
    List.sumBy(fun x -> (decimal x.Amount) * x.Cost)
    
let calculationDepositedSum (money: DepositedMoney list): decimal = 
    let result = money |> List.sumBy(fun x -> x.Sum)
    result

let createSale (command: SaleCreate): Result<CreatedSale, SaleCreateError> =
 
    let sum = command.Products |> calculationCostProducts
    let depositedSum = command.Moneys |> calculationDepositedSum
    
    if sum <> depositedSum then
      Error DepositedSumNotEqualCostProducts
    else
      let sale = {
        Id = command.Id
        Products = command.Products
        Date = command.Date
        Sum = sum
        Moneys = command.Moneys
      }
      
      let shippedProducts = command.Products |> List.map(fun x -> {
        Date = command.Date
        ProductId = x.ProductId
        Amount = x.Amount
      })
      
      let depositedMoney = command.Moneys
      
      let result = {
        Sale = sale
        ShippedProducts = shippedProducts
        DepositedMoneys = depositedMoney
      }
      Ok result
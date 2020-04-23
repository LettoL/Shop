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
    CostProducts: decimal
    DepositedMoneys: DepositedMoney list
}

type SaleCreateError =
    | DepositedSumNotEqualCostProducts

let calculationCostProducts = List.sumBy(fun x -> (decimal x.Amount) * x.Cost)
let calculationDepositedSum = List.sumBy(fun x -> x.Sum)

let createSale date products moneys =
 
    let costProducts = products |> calculationCostProducts
    let depositedSum = moneys |> calculationDepositedSum
    
    if costProducts <> depositedSum then
      Error DepositedSumNotEqualCostProducts
    else
        let createdSale = {
            Products = products
            Date = date
            CostProducts = costProducts
            DepositedMoneys = moneys
        }
        Ok createdSale
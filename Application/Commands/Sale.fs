module Application.Commands.Sale

open System
open Domain.Sale

type SaleCreate = {
  Date: DateTime
  Products: SoldProduct list
  Moneys: DepositedMoney list
}

type SaleCreated = {
  Id: int
}

type SaleCommands =
  | SaleCreate of SaleCreate
  
type SaleEvents =
  | SaleCreated of SaleCreated
  
let saleCreateHandler (command: SaleCreate): SaleCreated =
  let result = { Id = 1 }
  result
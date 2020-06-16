module Application.Commands.Sale

open System
open Domain.Sale

type SaleCreated = {
  Id: Guid
}

type SaleCommands =
  | SaleCreate of SaleCreate
  
type SaleEvents =
  | SaleCreated of SaleCreated
  

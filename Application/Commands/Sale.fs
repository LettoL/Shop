module Application.Commands.Sale

open System
open Domain.Sale
open InMemoryData

type SaleCreated = {
  Id: Guid
}

type SaleCommands =
  | SaleCreate of SaleCreate
  
type SaleEvents =
  | SaleCreated of SaleCreated
  
let saleCreateHandler (command: SaleCreate): Result<SaleCreated, SaleCreateError> =
  //создать продажу
  let createdSale = createSale command
  match createdSale with
  | Error error -> Error error
  | Ok createdSale ->
    let id = SaleData.commandsHandler(SaleData.Create createdSale.Sale)
    
    //зачислить деньги
    //отгрузить товар
    createdSale.ShippedProducts
      |> List.map(fun x -> ProductData.commandsHandler (ProductData.Create x))
      |> ignore
    
    Ok { Id = id }
  
  //let createdSale = createSale command.Date command.Products command.Moneys
  //match createdSale with
  //| Error -> Error DepositedSumNotEqualCostProducts
  //| Ok createdSale ->
  //  Console.WriteLine("asd")
  // let result = { Id = 1 }
  //  Ok result
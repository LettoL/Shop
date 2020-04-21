module Domain.Supply

open System

type CreatedSupply = {
  Date: DateTime
  ProductId: int
  Amount: int
}

let createSupply productId amount date =
  
  let createdSupply = {
    Date = date
    ProductId = productId
    Amount = amount
  }
  createdSupply
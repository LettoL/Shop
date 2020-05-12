module Domain.Product

open System

type ShippedProduct = {
  Date: DateTime
  ProductId: int
  Amount: int
}
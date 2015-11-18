﻿namespace LibASS.Tests.InventoryTests
open System
open LibASS.Contracts
open LibASS.Tests.Specification
open LibASS.Tests.TestHelpers
open Xunit

module ``When add an item to the inventory`` =

    [<Fact>]
    let ``The item should be added``() =
        let itemGuid = newGuid()
        let aggId = AggregateId itemGuid
        let itemId = ItemId itemGuid
        let book = Book {Title = Title "Magic Book"; Author = Author "JRR Tolkien"}
        let item = itemId,book
        let qty = Quantity.Create 10

        Given []
        |> When (aggId, RegisterInventoryItem (item, qty))
        |> Then ([InventoryItemRegistered(item, qty)] |> ok)
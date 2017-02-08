// Learn more about F# at http://fsharp.org
module Tests
open Xunit
open Backend2.Features
open Backend2.ViewModels

[<Fact>]

let ``Can add MessageData`` =
    let queue = SimpleQueue()
    queue.Enqueue(MessageData())
    
    Assert.False(queue.IsEmpty)


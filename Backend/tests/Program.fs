// Learn more about F# at http://fsharp.org
module Tests
open Xunit
open FsUnit

[<Fact>]
let MoneyIsZero() =
    
    Assert.Equal(4, 2 + 1);
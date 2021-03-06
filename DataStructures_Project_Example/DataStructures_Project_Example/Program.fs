﻿open System

module DataStructures = 
    // Using let to declare a variable makes the variable unchangeable unless followed by "mutable"
    let mutable numberOne = 3
    // Update the variable with <-
    numberOne <- numberOne - 2 

    // List of integers from 1 to 10
    let numList = [ 1 .. 10 ]

    // Array containing the even numbers from 0 to 200.
    let evenNum = Array.init 101 (fun n -> n * 2)

    // Sequence of strings.
    let sequence = seq { yield "hello"; yield "world"}

    // Recursive functions are built in to make looping easier
    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n-1)

    // Record types can be created containing multiple types of information.  
    type testContact = 
        { Name     : string
          Phone    : string}
              
    // This example shows how to instantiate a record type.
    let testContact = 
        { Name = "Test" 
          Phone = "(111) 222-1234"}

    // This gets the string ready to display the contact information
    let showCard (check: testContact) = 
        check.Name + " Phone: " + check.Phone

    // Stack data type creation which is included in F#
    type Stack = StackContents of float list
    let testStack = StackContents [1.0;2.0;3.0]
    // Push Function
    let push x (StackContents testStack) = StackContents (x::testStack)
    let emptyStack = StackContents []
    let push1 = push 1.0 emptyStack

    // Queues and Trees can be created from Stacks, Sequences, and Recursives

    printfn "List Contents: %A" (numList |> List.take 5)
    printfn "Seq Contents: %A" sequence
    printfn "Factorial of 5: %d" (factorial 5)
    printfn "Array Contents: %A" (evenNum |> Array.take 5)
    printfn "Record Contents: %s" (showCard testContact)
    printfn "Initialized Stack with list of floats: %A" testStack
    printfn "Initiliazed Empty Stack: %A" emptyStack
    printfn "Pushed Float to Empty Stack: %A" push1 

let keepConsoleOpen() = 
  printfn "\nPress any key to exit"
  Console.ReadKey() |> ignore

// Hold console open to view output
keepConsoleOpen()

let main argv = 
    
    printfn "%A" argv

    0 // return an integer exit code
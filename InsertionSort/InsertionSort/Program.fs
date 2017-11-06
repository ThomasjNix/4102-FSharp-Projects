open System
open System.Reflection.Emit

// Sort array function loops through and compares elements, switching elements that are out of order. 
let sortArray (inArray : int []) =
    for index1 = 1 to inArray.Length - 1 do
        let mutable index2 = 1
        while (index2 >= 0 && inArray.[index2] < inArray.[index2 - 1]) do 
            let holderValue = inArray.[index1]
            inArray.[index1] <- inArray.[index2]
            inArray.[index2] <- holderValue 
            index2 <- (index2 - 1)
    inArray  

// For testing
let someArr = [|3;7;12;7;-234;654;-12;54;-78;|]
let sortedArr = sortArray(someArr)
for elem in sortedArr do 
    Console.WriteLine elem
Console.ReadKey() |> ignore
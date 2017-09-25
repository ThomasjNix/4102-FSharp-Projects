//use the system for basic commands
open System

//function to use recursive to calc sum of all number from 1 to x
let test_recursive() = 
    printfn "*******Testing with Recursive Function Call********"

    let rec sum x =
        if x < 1 then 0
        else x + sum(x - 1)

    printfn "Sum from 1 to 10: %i" (sum 10)

//function to test the list control structure in f#
let test_list() =
    printfn "*******Testing with List Operation********"
    let myList = [0;2;3;4;5;6;7;8;9;10]
    //multiply each item in myList by 3
    let myList2 = List.map(fun x -> x * 3) myList
    printfn "Old List: %A" myList
    printfn "New List: %A" myList2

    //filter myList to only select odd number
    let myList3 = List.filter(fun x -> (x%2) > 0) myList
    printfn "Odd Number List: %A" myList3

    //filter myList to select only even number, then square it
    let myList4 = List.map (fun x -> x * x) (List.filter(fun x -> (x%2) = 0) myList)
    printfn "Filtered List: %A" myList4

    //calculate the sum of the list of numbers
    let totalSum = List.reduce(+) myList4
    printfn "Sum of above List: %i" totalSum

//function to test loops
let test_loop() =
    printfn "*******Testing with Loop Operation********"

    //for loop from 1 to 10
    for i = 1 to 10 do
        printf "%i, " i
    printfn ""

    //for loop from 10 to 1
    for i = 10 downto 1 do
        printf "%i, " i
    printfn ""

    //use list to act as loop
    [1..10] |> List.iter (printf "%i, ")
    printfn ""

//function to test match (switch)
let test_match() = 
    printfn "*******Testing with Match Operation********"

    let temp = 70

    let dp: string =
        match temp with
        | temp when temp < 20 -> "Temperature is too cold"
        | temp when ((temp >= 20) && (temp <= 80)) -> "Temperature is ideal"
        | temp when temp > 80 -> "Temperature is too hot"
        | _ -> "Unknown"
    printfn "Temp @%iF: %s" temp dp

// Keeps console open until user hits a key  
let keepConsoleOpen() = 
  printfn "\nPress any key to exit"
  Console.ReadKey() |> ignore

test_recursive()
test_list()
test_loop()
test_match()
keepConsoleOpen()
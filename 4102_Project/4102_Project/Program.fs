//this is the interface for user i/o for  survey of programming language class
//take user input as string and parse the string for commands

module Program
//use the system for basic commands
open System
open System.Runtime.DesignerServices
open System.IO

//list of possible commands
[<Literal>]
let EXIT = "exit"
let HELP = "help"
let INFO = "info"
let PRINT = "print"
let LOAD = "load"
let INSERT = "insertionsort"
let BUBBLE = "bubblesort"
let SELECT = "selectionsort"
let SAVE = "save"
let ERR_UNSUPPORT_COMMAND = "Unsupported commands. Check your syntax"
let ERR_MISSING_PARAMETERS = "Missing parameters"


//info used to store the data
let mutable myData = []
let mutable dbname = ""
let mutable dbuser = ""
let mutable dbpass = ""
let mutable fname = ""
// Keeps console open until user hits a key  
let keepConsoleOpen() = 
    printfn "\nPress any key to exit"
    Console.ReadKey() |> ignore

//print the list of supported commands in this program
let printHelp() =
    Console.WriteLine("These are possible commands available in this program. You have to load data in either by file or db, before you can perform the sort, then save")
    Console.WriteLine("info\n\tprint out the information about this program")
    Console.WriteLine("print -d\n\tprint out the current loaded data on the screen")
    Console.WriteLine("print -fname\n\tprint out the current file name info on the screen")
    Console.WriteLine("load -f fname\n\tload the data from file to internal memory prior to performing sorting")
    Console.WriteLine("load -d a;b;c\n\tload the data from CLI to internal memory prior with the format of number;number'etc prior to performing sorting")
    Console.WriteLine("save -f fname\n\tsave the current data to the following file")
    Console.WriteLine("save -f\n\tsave the current data to the curent file")
    Console.WriteLine("save -f fname\n\tsave the current data to the given file")
    Console.WriteLine("insertionsort \n\tPerform Insertion Sort on the stored data")
    Console.WriteLine("bubblesort \n\tPerform Bubble Sort on the stored data")
    Console.WriteLine("selectionsort \n\tPerform Selection Sort on the stored data")

//print the info about this project
let printInfo() =
    printfn "Welcome to 4102/5102 F# program. Type help for list of commands"
    printfn "Author: Chuong Vu, Chatao Lauj, Thomas Nix, Stephen Meadley, Michael P"
    printfn "The program will take in user commands from CLI to perform Insertion Sort, Selection sort, or Bubble Sort."
    //printfn "User will also have the option to read or write from/to text file or supported Database"

// Function to print out the value given
let printText x = printfn "%A" x

//Function to perform Insertion Sort
//data - the data to perform the sorting on. This should be a list of data
let InsertionSort() =
    printfn "Insertion Sort with original Data:\t%A\n====================" myData
    //logic to do Insertion Sorting here=
    let inArray: int[] = List.toArray(myData)
    let length: int = inArray.Length
    for index1 = 1 to length-1 do
        let cVal: int = inArray.[index1]
        let mutable pValIndex: int = index1 - 1

        while (pValIndex >= 0 && inArray.[pValIndex] > cVal) do
            inArray.[pValIndex+1] <- inArray.[pValIndex]
            pValIndex <- pValIndex - 1
        inArray.[pValIndex+1] <- cVal
    printfn "\tSorted Data: %A\n\n" inArray
    myData <- Array.toList(inArray)

//Function to perform Selection Sort
//data - the data to perform the sorting on. This should be a list of data
let SelectionSort() = 
    printfn "Selection Sort with original Data:\t%A\n====================" myData
    let arr: int[] = List.toArray(myData)
    let rec loop n (arr : 'a []) =
        if n >= arr.Length - 1 then 
            arr
            printfn "\tSorted Data: %A\n\n" arr
        else
            let mutable x, minIndex = arr.[n], n
            for i = n+1 to arr.Length - 1 do
                if arr.[i] < x then
                    x <- arr.[i]
                    minIndex <- i
            if n <> minIndex then //checks if left side is equal to right side; returns true if they're equal
                let tmp = arr.[n]
                arr.[n] <- arr.[minIndex]
                arr.[minIndex] <- tmp
            loop (n+1) arr
    loop 0 
    myData <- Array.toList(arr)

//Function to perform Bubble Sort
//data - the data to perform the sorting on. This should be a list of data
let BubbleSort() =
    printfn "Bubble Sort with original Data:\t%A\n====================" myData
    //logic to dovBubble Sorting here
    let arr: int[] = List.toArray(myData)
    let rec loop (arr : 'a []) =
        let mutable swapped = false
        for i = 0 to arr.Length - 2 do
            if arr.[i] > arr.[i+1] then
                let tmp = arr.[i]
                arr.[i] <- arr.[i+1]
                arr.[i+1] <- tmp
                //printfn "%A : Swapped %i with %i" arr arr.[i+1] arr.[i]
                swapped <- true

        if swapped = true then 
            loop arr 
        else 
            arr 
            printfn "\n\tSorted Data: %A\n\n" arr
    loop arr
    myData <- Array.toList(arr)

let loadDataFromFile file =
    fname <- file
    printfn "Loading data from file to internal memory. Filename=%s" fname
    use fstream = new StreamReader(fname)
    
    //code to load the data from file to myData
    let mutable valid = true
    while (valid) do
        let l = fstream.ReadLine()
        valid <- false
        try
            myData <- l.Split ';'
                |> Array.map int |> Array.toList
        with
            | exn -> printfn "%s" "File format Error. Make sure it is in the format of #;#;#"

let loadDataFromDatabase dname duser dpass =
    dbname <- dname
    dbuser <- duser
    dbpass <- dpass
    printfn "Load data from database: %s with username: %s and pass: %s" dbname dbuser dbpass
    //code to load the data from db to myData

let saveDataToFile() =
    if fname <> "" then
        use fstream = new StreamWriter(fname)
        let mutable value = ""
        let mutable count = 0
        for data in myData do
            count <- count + 1
            if count < myData.Length then
                value <- value + data.ToString() + ";"
            else
                value <- value + data.ToString()
        fstream.WriteLine(value)
        printfn "successfully write data to %s" fname
    else
        printfn "Please setup a file name first"

let saveDataToDb() =
    printfn "Code to save the sorted data to database"

//main function
let main() =
    printfn "Welcome to 4102/5102 F# program. Type help for list of commands"
    let mutable keeprunning = true
    while keeprunning do
        printf ">>"
        let text = Console.ReadLine()
        //split the text out to differents words
        let words = text.Split [|' '|]

        //HELP command
        if words.[0] = HELP then
            printHelp()
        //Bubble Sort
        else if words.[0] = BUBBLE then
            BubbleSort()

        //Insertion Sort
        else if words.[0] = INSERT then
            InsertionSort()

        else if words.[0] = SELECT then
            SelectionSort()

        //INFO command
        else if words.[0] = INFO then
            printInfo()
        //PRINT command
        else if words.[0] = PRINT then
            try
                if words.[1] = "-d" then
                    printText myData
                else if words.[1] = "-db" then
                    printfn "Database Name: %s, Username: %s, Password: %s" dbname dbuser dbpass
                else if words.[1] = "-f" then
                    printfn "Filename: %s" fname
                else
                    printfn "%s" ERR_UNSUPPORT_COMMAND
            with
                | exn -> printfn "%s" ERR_MISSING_PARAMETERS
        //LOAD data command
        else if words.[0] = LOAD then
            try
                if words.[1] = "-f" then
                    loadDataFromFile words.[2]
                else if words.[1] = "-db" then
                    loadDataFromDatabase words.[2] words.[3] words.[4]
                else if words.[1] = "-d" then
                     myData <- words.[2].Split ';'
                                    |> Array.map int |> Array.toList
                else
                    printfn "%s" ERR_UNSUPPORT_COMMAND
                printfn "%A" myData

            with
                | exn -> printfn "%s" ERR_MISSING_PARAMETERS
        //Exit the application
        else if words.[0] = EXIT then
            keeprunning <- false
            keepConsoleOpen()
        //save commands
        else if words.[0] = SAVE then
            try
                if words.[1] = "-f" then
                    if words.Length = 3 then
                        fname <- words.[2]
                    saveDataToFile()
                else if words.[1] = "-db" then
                    if words.Length = 5 then
                        dbname <- words.[2]
                        dbuser <- words.[3]
                        dbpass <- words.[4]
                    saveDataToDb()
            with
                | exn -> printfn "%s" ERR_MISSING_PARAMETERS
        else
            printfn "%s" ERR_UNSUPPORT_COMMAND
//main program call
main()
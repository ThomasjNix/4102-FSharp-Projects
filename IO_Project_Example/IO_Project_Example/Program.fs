open System
open System.IO


// Example of reading from and writing to the console
let getUserInput() = 

  // Ask user for name
  printf("Please enter your name: ");

  // Read in users name
  let usersName = Console.ReadLine()

  // Print the users name to the console
  printfn "Greetings, %s\n" usersName

// Example of reading from a file and printing to the console
let readFromFile(inString : string) = 
 
  // Print string sent from function call
  printfn "%s" inString

  // Read all lines from file
  let file = "Testfile.txt"
  let lineArray = File.ReadAllLines(file)

  // Loop through line array and print line
  for i = 0 to lineArray.Length - 1 do
    printfn "%s" lineArray.[i]

// Keeps console open until user hits a key  
let keepConsoleOpen() = 
  printfn "\nPress any key to exit"
  Console.ReadKey() |> ignore

// Function calls
getUserInput()
readFromFile("A haiku for your worries:")
keepConsoleOpen()



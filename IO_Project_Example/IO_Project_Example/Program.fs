open System


// Example of reading from and writing to the console
let getUserInput() = 

  // Ask user for name
  printf("Please enter your name: ");

  // Read in users name
  let usersName = Console.ReadLine()

  // Print the users name to the console 
  printfn "Greetings, %s" usersName


// Function call 
getUserInput()

// Keeps console open until user hits a key
Console.ReadKey() |> ignore
using System;

  namespace Camel
  {
    class Program
    {
      static void Main(string[] args)
      {
        // Introductory message
        Console.WriteLine("Welcome to Camel!");

        // Main game loop
        CamelGame myGame = new CamelGame();

        while (!myGame.gameOver)
        {
          // Print commands
          Console.WriteLine();
          Console.WriteLine("A. Drink from your canteen.");
          Console.WriteLine("B. Ahead moderate speed.");
          Console.WriteLine("C. Ahead full speed.");
          Console.WriteLine("D. Stop and rest.");
          Console.WriteLine("E. Status check.");
          Console.WriteLine("Q. Quit.");

          // Get user command
          Console.Write("What is your command? ");
          string userCommand = Console.ReadLine();
          Console.WriteLine();

          // Process user command
          if (userCommand == "a") {
              myGame.drinkFromCanteen();
          }
          else if (userCommand == "b") {
              myGame.aheadModSpeed();
          }
          else if (userCommand == "c") {
              myGame.aheadFullSpeed();
          }
          else if (userCommand == "d") {
              myGame.stopAndRest();
          }
          else if (userCommand == "e") {
              myGame.statusReport();
          }
          else if (userCommand == "q") {
              myGame.quitGame();
          }

          myGame.checkIfGameIsOver();
        }
      }
    }

    // ------------------------------ Game Class -------------------------------

    class CamelGame {
      // In the game, any number related to distance will be in miles.
      Random rand = new System.Random();

      readonly int distanceToTravel;
      int distanceTraveled = 0;
      int nativesDistanceFromYou;
      int drinksAvailable;
      int hydrationLevel = 100;
      int energyLevel = 100;
      public bool gameOver = false;

      public CamelGame() {
        distanceToTravel = rand.Next(30, 50);
        nativesDistanceFromYou = rand.Next(51, 60);
        drinksAvailable = rand.Next(1, 5);
      }

      public void drinkFromCanteen() {
        if (drinksAvailable > 0) {
          drinksAvailable --;
          hydrationLevel += rand.Next(10, 25);
          energyLevel += rand.Next(2, 5);
          nativesDistanceFromYou -= rand.Next(1, 3);
          Console.WriteLine("You drank from the canteen.");
        }
        else {
          Console.WriteLine("No more drinks available.");
          nativesDistanceFromYou -= rand.Next(1, 2);
          hydrationLevel -= rand.Next(2, 4);
          energyLevel -= rand.Next(1, 2);
        }
      }

      public void aheadModSpeed() {
        distanceTraveled += rand.Next(1, 4);
        nativesDistanceFromYou -= rand.Next(5, 10);
        hydrationLevel -= rand.Next(11, 18);
        energyLevel -= rand.Next(11, 18);
      }

      public void aheadFullSpeed() {
        distanceTraveled += rand.Next(5, 10);
        nativesDistanceFromYou -= rand.Next(10, 13);
        hydrationLevel -= rand.Next(15, 35);
        energyLevel -= rand.Next(15, 35);
      }

      public void stopAndRest() {
        nativesDistanceFromYou -= rand.Next(6, 8);
        energyLevel += rand.Next(7, 15);
        hydrationLevel -= rand.Next(1, 3);
      }

      public void statusReport() {
        Console.WriteLine("You need to travel " + distanceToTravel + " miles.");
        Console.WriteLine("Miles traveled: " + distanceTraveled);
        Console.WriteLine("Drinks in canteen: " + drinksAvailable);
        Console.WriteLine("The natives are " + nativesDistanceFromYou + " miles behind you.");
        if (hydrationLevel < 20) Console.WriteLine("You are very thirsty!");
        if (energyLevel < 20) Console.WriteLine("You are very tired!");
      }

      public void quitGame() { 
        Console.WriteLine("You quit the game.");
        gameOver = true;
      }

      public void checkIfGameIsOver() {
        if (distanceToTravel - distanceTraveled <= 0) {
          Console.WriteLine("You won the game!");
          gameOver = true;
        }
        else if (nativesDistanceFromYou <= 0){
          Console.WriteLine("The natives got to you. You lose.");
          gameOver = true;
        }
        else if (hydrationLevel <= 0){
          Console.WriteLine("You died of dehydration. You lose.");
          gameOver = true;
        }
      }
    }
  }

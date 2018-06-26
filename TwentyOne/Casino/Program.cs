using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino.TwentyOne
{
    class Program
    {
        static void Main(string[] args) //<-- If a method is created before making an object in that class, it must be static
        {
            //string text = File.ReadAllText(@"C:\Users\Tech Academy Student\source\repos\TheTechAcademy\Logs\log.txt");

            //DateTime yearOfBirth = new DateTime(1995, 5, 23, 8, 32, 45);
            //DateTime yearOfGraduation = new DateTime(2013, 6, 1, 16, 34, 22);
            //TimeSpan ageAtGraduation = yearOfGraduation - yearOfBirth;


            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();

            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hello {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y" || answer == "yea" || answer == "yep" || answer == "yeah" || answer == "ya")
            {
                Player player = new Player(playerName, bank); //<-- part of the constructor in Player.cs
                Game game = new TwentyOneGame();
                game += player; //<--add player the game

                player.isActivelyPlaying = true; //<-- while loop to check that player is still playing
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();
        }
    } 
}


//--------ORIGINAL MAIN CODE----------------------


//Deck deck = new Deck();


////deck.Shuffle(3);

////foreach (Card card in deck.Cards)
////{
////    Console.WriteLine(card.Face + " of " + card.Suit);
////}

////Console.WriteLine(deck.Cards.Count); // <--prints total number of cards in list "deck"
//Console.ReadLine();


//---------LAMBDA EXPRESSIONS------------------------------------

//int count = deck.Cards.Count(x => x.Face == Face.Ace); //-- => is unique to Lambda functions

//List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();

//List<int> numberList = new List<int>() { 42, 189, 60, 85, 16 };

//int sum = numberList.Where(x => x > 20).Sum();

//    Console.WriteLine(sum);




//--------ENUMS----------------------------------------
//---------enum Suit is found in Card.cs---------------

//Card card = new Card();
//card.Suit = Suit.Clubs;
//int underlyingValue = Convert.ToInt32(Suit.Diamonds);
//Console.WriteLine(underlyingValue);

//----GENERICS - MOST LIKELY FOUND IN LISTS-------------



//-------OVERLOADED OPERATORS---------------------------

//Game game = new TwentyOneGame();
//game.Players = new List<Player>();
//Player player = new Player();
//player.Name = "Nick";
//game = game + player; // could also write: game += player;
//game = game - player; // could also write: game -= player; 





//-------POLYMORPHISM--------------------------------------

//TwentyOneGame game = new TwentyOneGame(); //<-- polymorphism :: one object can morph into a higher-order class object

//List<Game> games = new List<Game>();
//TwentyOneGame game = new TwentyOneGame();
//games.Add(game);

//TwentyOneGame game = new TwentyOneGame();
//game.Players = new List<string>() { "Jesse", "Bill", "Bob" };
//game.ListPlayers();
//Console.ReadLine();


//-------INHERITANCE--------------------------------------

//TwentyOneGame game = new TwentyOneGame();
//game.Players = new List<string>() { "Jesse", "Bill", "Joe" };
//            game.ListPlayers(); // ---- SuperClass method -- calling a method from a higher-up class
//            game.Play();
//            Console.ReadLine();



//------ORGINAL FUNCTION CALL BEFORE MOVING SHUFFLE TO DECK.CS---------------

// deck = Shuffle(deck, out timesShuffled, 3); //<-- Function which calles the shuffled deck; : denotes a named parameter





//--------PRE-CONSTRUCTOR CODE ---------------------------------------

//deck.Cards = new List<Card>();

//Card cardOne = new Card(); // <-- object instatiation
//cardOne.Face = "Queen";
//cardOne.Suit = "Spades";

//deck.Cards.Add(cardOne);

//Console.WriteLine(deck.Cards[0].Face + " of " + deck.Cards[0].Suit);

//--------END PRE-CONSTRUCTOR CODE------------------------------------



//---------------ORIGINAL SHUFFLE CODE BEFORE MOVING TO DECK.CS-------------------------------------------------

//public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1) //<-- Method for shuffling the deck
//{
//    timesShuffled = 0;
//    for (int i = 0; i < times; i++)
//    {
//        timesShuffled++;
//        List<Card> TempList = new List<Card>();//<--creates a new list to store the randomized cards in
//        Random random = new Random(); //<-- creates a new random object

//        while (deck.Cards.Count > 0)//<-- while loop to randomize cards
//        {
//            int randomIndex = random.Next(0, deck.Cards.Count); //<-- creates a random index to start from
//            TempList.Add(deck.Cards[randomIndex]); //<-- Adds the card from that index to TempList
//            deck.Cards.RemoveAt(randomIndex); //<-- removes the card at that index from the list
//        }
//        deck.Cards = TempList;
//    }
//    return deck;
//}

//public static Deck Shuffle(Deck deck, int times)
//{
//    for int(i = 0; int < times; int++)
//    {
//        deck = Shuffle(Deck);
//    }
//}

//Card card = new Card() { Face = "King", Suit = "Spades" }; //<-- Initializes an object with values

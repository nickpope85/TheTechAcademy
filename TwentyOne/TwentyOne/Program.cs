using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace TwentyOne
{
    class Program
    {
        private static object sqlDbType;

        static void Main(string[] args) //<-- If a method is created before making an object in that class, it must be static
        {
            //string text = File.ReadAllText(@"C:\Users\Tech Academy Student\source\repos\TheTechAcademy\Logs\log.txt");

            //DateTime yearOfBirth = new DateTime(1995, 5, 23, 8, 32, 45);
            //DateTime yearOfGraduation = new DateTime(2013, 6, 1, 16, 34, 22);
            //TimeSpan ageAtGraduation = yearOfGraduation - yearOfBirth;

            //var newPlayer = new Player("Nick"); //<--uses the chain in PLayer.cs

            //const string casinoName = "Grand Hotel and Casino"; //<-- constant keyword




            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();

            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.Read();
                return;
            }

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");
            }



            Console.WriteLine("Hello {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y" || answer == "yea" || answer == "yep" || answer == "yeah" || answer == "ya")
            {
                Player player = new Player(playerName, bank); //<-- part of the constructor in Player.cs
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\Tech Academy Student\source\repos\TheTechAcademy\Logs\log.txt", true)) //<-- true means to append. False would create a new file
                {
                    file.WriteLine(player.Id); //<--writes current timestamp for each card to external file
                }
                Game game = new TwentyOneGame();
                game += player; //<--add player the game

                player.isActivelyPlaying = true; //<-- while loop to check that player is still playing
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        updateDBWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Something you entered was incorrect.");
                        updateDBWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured. Please contact your system administrator.");
                        updateDBWithException(ex);
                        Console.ReadLine();
                        return; //<-- return in a void method end the program
                    }
              
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();
        }
        private static void updateDBWithException(Exception ex)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame; 
                                      Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                                      TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp)
                                   VALUES (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            using (SqlConnection connection = new SqlConnection(connectionString)) //<-- using inside the Main() method is for managing and accessin external resources
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame; 
                                      Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                                      TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string queryString = @"Select Id, ExceptionType, ExceptionMessage, TimeStamp from Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
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

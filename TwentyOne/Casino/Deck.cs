using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck // <-- Classes are designs for objects
    {
    
        public Deck() //<-- constructor method name is always the same as the class name
        {
            Cards = new List<Card>(); // <-- creates the list Cards, which is used below

            for (int i=0; i < 13; i++ )
            {
                for (int j=0; j < 4; j++)
                {
                    Card card = new Card(); //<-- creates a new instance of card in class Card
                    card.Face = (Face)i; //<-- assigns the enum Face based on the enum index = i
                    card.Suit = (Suit)j; //<--assigns the enum Suit based on the enum index = j 
                    Cards.Add(card); //<--adds the new card to the list Cards
                }
            }

        }

        public List<Card> Cards {get; set;}

        public void Shuffle(int times = 1) //<-- Method for shuffling the deck
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();//<--creates a new list to store the randomized cards in
                Random random = new Random(); //<-- creates a new random object

                while (this.Cards.Count > 0)//<-- while loop to randomize cards
                {
                    int randomIndex = random.Next(0, this.Cards.Count); //<-- creates a random index to start from
                    TempList.Add(this.Cards[randomIndex]); //<-- Adds the card from that index to TempList
                    this.Cards.RemoveAt(randomIndex); //<-- removes the card at that index from the list
                }
                this.Cards = TempList; //<--"this." means this class. Is not necessary to have (could just be Cards)
            }
        }
    }
}





//----------MAKING A DECK BEFORE USING ENUMS----------------------

//List<string> Suits = new List<string>() { "Clubs", "Hearts", "Diamonds", "Spades" };
//List<string> Faces = new List<string>()
//            {"Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};

//foreach (string face in Faces)
//{
//    foreach (string suit in Suits)
//    {
//        Card card = new Card(); // <-- creates a card
//        card.Suit = suit; // <-- assigns it a suit
//        card.Face = face; // <-- assigns it a face
//        Cards.Add(card); // <-- adds it to the list Cards
//    }
//}


//-------to make each card individually---------
//Cards = new List<Card>();
//Card cardOne = new Card();
//cardOne.Face = "Two";
//cardOne.Suit = "Hearts";
//Cards.Add(cardOne);
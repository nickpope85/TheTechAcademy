using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");
            using (StreamWriter file = new StreamWriter(@"C:\Users\Tech Academy Student\source\repos\TheTechAcademy\Logs\log.txt", true)) //<-- true means to append. False would create a new file
            {
                file.WriteLine(DateTime.Now); //<--writes current timestamp for each card to external file
                file.WriteLine(card); //<--log each card dealt to external file
            }
                Deck.Cards.RemoveAt(0);



        }


    }
}

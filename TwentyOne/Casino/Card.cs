using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card //struct -- value data type which cannot inherit and non-nullable (bool, int, datetime)
    {
        //public Card() // constructor - value assigned to an object upon creation
        //{
        //    Suit = "Spades";
        //    Face = "Two";
        //}


        public Suit Suit { get; set; } 
        public Face Face { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }

    public enum Suit //<-- enums
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}


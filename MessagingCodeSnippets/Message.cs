using ScheduleUsers.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    public class Message
    {

        //Initializing Messages Model with necessary information


        [Key]
        /// <summary>
        /// ID for the Message
        /// </summary>
        public Guid MessageID { get; set; }

        /// <summary>
        /// DateTime Sent for the Message
        /// </summary>
        [Display(Name = "Date Sent")]
        public DateTime DateSent { get; set; }

        /// <summary>
        /// DateTime Read for the Message
        /// </summary>
        [Display(Name = "Date Read")]
        public DateTime? DateRead { get; set; }

        /// <summary>
        /// Message Title
        /// </summary>
        [Display(Name = "Title")]
        public string MessageTitle { get; set; }

        /// <summary>
        /// Sets the content of the Message
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Whether the message has been read or not
        /// </summary>
        [Display(Name = "Unread")]
        public bool UnreadMessage { get; set; }

        //public string SenderID { get; set; }
        //public string RecipientID { get; set; }


        public virtual ApplicationUser Sender { get; set; } // Column header: Sender_Id
        public virtual ApplicationUser Recipient { get; set; } // Coulmn header: Recipient_Id
        public virtual Event EventID { get; set; } //Column header: EventID_EventID

        public Message(Event e, string s, ApplicationDbContext db) : this()
        {

            Recipient = db.Users.Find(e.User.Id);
            EventID = e;
            Sender = db.Users.Find(s);
            DateSent = DateTime.Now;
            string state = "";
            if (e.ActiveSchedule == true)
            {
                state = "approved";
            }
            else if (e.ActiveSchedule == false)
            {
                state = "denied";
            }
            MessageTitle = "Your time off request has been " + state + ".";
            Content = Sender.FirstName + " has " + state + " your time off request from " + e.Start + " to " + e.End + ".";
        }


        public Message()
        {
            UnreadMessage = true;
            MessageID = Guid.NewGuid();
        }



    }
}

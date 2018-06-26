using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleUsers.Models;
using System.Web.Mvc;


// ViewModel to put Unread and Read messages on the same page

namespace ScheduleUsers.ViewModels
{
    public class MessageViewModel
    {

        public IQueryable<Message> unreadMessagesList { get; set; }
        public IQueryable<Message> readMessagesList { get; set; }

        // Constructor to create the lists of Unread and Read messages
        public MessageViewModel(IQueryable<Message> unreadMessages, IQueryable<Message> readMessages)
        {
            unreadMessagesList = unreadMessages;
            readMessagesList = readMessages;
        }


    }
}
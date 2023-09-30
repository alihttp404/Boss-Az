using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class Notification
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public Person FromUser { get; set; }
        public Person ToUser { get; set; }

        public Notification() { }

        public Notification(string text, Person fromUser)
        {
            ID = Guid.NewGuid();
            Text = text;
            FromUser = fromUser;
        }

        public Notification(string text, Person fromUser, Person toUser)
        {
            ID = Guid.NewGuid();
            Text = text;
            FromUser = fromUser;
            ToUser = toUser;
        }
    }
}

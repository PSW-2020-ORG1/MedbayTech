using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQService
{
    public class Message
    {
        public string Text { get; set; }

        public DateTime Timestamp { get; set; }


        public Message(string text, DateTime timestamp)
        {
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.Timestamp.ToString();
        }
    }
}

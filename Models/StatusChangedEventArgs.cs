using BotFactory.Interface;
using System;

namespace BotFactory.Models
{
    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        public string NewStatus { get; set; }

    }
}

﻿using System;

namespace WeTalk.Models.MessageModels
{
    public class MessageEdit
    {
        public string Username { get; set; }
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTimeOffset EditedTimestamp { get; set; }
    }
}

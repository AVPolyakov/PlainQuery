using System;

namespace PlainQueryExtensions.SqlServerTests
{
    public class PostInfo
    {
        public int PostId { get; set; } 
        public string? Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
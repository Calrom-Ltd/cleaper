using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Models
{
    public class Message
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string MessageText { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

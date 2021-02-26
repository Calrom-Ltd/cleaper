using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.DataContracts
{
    public class CreateMessage
    {
        public string Name { get; set; }

        public string MessageText { get; set; }
    }
}

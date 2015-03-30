using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitApp.Data
{
    public class TopicItem
    {
        public DateTime createdDate { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public Images images { get; set; }
        public string name { get; set; }
        public int talkingAbout { get; set; }
        public string url { get; set; }
    }

}

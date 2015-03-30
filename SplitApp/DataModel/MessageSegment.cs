using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitApp.Data
{

    public class Messagesegment
    {
        public bool accessible { get; set; }
        public string name { get; set; }
        public Record record { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Record
    {
        public object additionalLabel { get; set; }
        public string communityNickname { get; set; }
        public string companyName { get; set; }
        public string displayName { get; set; }
        public string firstName { get; set; }
        public string id { get; set; }
        public bool isActive { get; set; }
        public bool isInThisCommunity { get; set; }
        public string lastName { get; set; }
        public Motif motif { get; set; }
        public Subscription mySubscription { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object recordViewUrl { get; set; }
        public object reputation { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string userType { get; set; }
    }

    public class Subscription
    {
        public string id { get; set; }
        public string url { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitApp.Data
{
    public class Capabilities
    {
        public Actions associatedActions { get; set; }
        public Bookmarks bookmarks { get; set; }
        public Chatterlikes chatterLikes { get; set; }
        public Comments comments { get; set; }
        public Enhancedlink enhancedLink { get; set; }
        public Topics topics { get; set; }
    }

    public class Actions
    {
        public object[] platformActionGroups { get; set; }
    }

    public class Likesmessage
    {
        public Messagesegment[] messageSegments { get; set; }
        public string text { get; set; }
    }

    public class Like
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Likeditem
    {
        public string id { get; set; }
        public string url { get; set; }
    }


    public class Enhancedlink
    {
        public string description { get; set; }
        public Icon icon { get; set; }
        public object linkRecordId { get; set; }
        public object linkUrl { get; set; }
        public string title { get; set; }
    }

    public class Icon
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Images
    {
        public object coverImageUrl { get; set; }
        public object featuredImageUrl { get; set; }
    }


}

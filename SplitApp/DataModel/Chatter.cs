using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using Salesforce.SDK.Rest;
using Salesforce.SDK.App;
using Windows.Web.Http;

namespace SplitApp.Data
{

    public class Rootobject
    {
        private ObservableCollection<Element> _elements = new ObservableCollection<Element>();

        public string currentPageUrl { get; set; }
        public ObservableCollection<Element> elements
        {
            get { return _elements; }
        }
        public object isModifiedToken { get; set; }
        public object isModifiedUrl { get; set; }
        public object nextPageUrl { get; set; }
        public object updatesToken { get; set; }
        public object updatesUrl { get; set; }
    }

    public class Element
    {
        public Actor actor { get; set; }
        public Body body { get; set; }
        public bool canShare { get; set; }
        public Capabilities capabilities { get; set; }
        public object clientInfo { get; set; }
        public DateTime createdDate { get; set; }
        public bool _event { get; set; }
        public string feedElementType { get; set; }
        public Header header { get; set; }
        public string id { get; set; }
        public bool isDeleteRestricted { get; set; }
        public DateTime modifiedDate { get; set; }
        public object originalFeedItem { get; set; }
        public object originalFeedItemActor { get; set; }
        public Parent parent { get; set; }
        public string photoUrl { get; set; }
        public string relativeCreatedDate { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class Actor
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
        public object mySubscription { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object recordViewUrl { get; set; }
        public object reputation { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string userType { get; set; }
    }

    public class Motif
    {
        public string color { get; set; }
        public string largeIconUrl { get; set; }
        public string mediumIconUrl { get; set; }
        public string smallIconUrl { get; set; }
    }

    public class Photo
    {
        public string fullEmailPhotoUrl { get; set; }
        public string largePhotoUrl { get; set; }
        public object photoVersionId { get; set; }
        public string smallPhotoUrl { get; set; }
        public string standardEmailPhotoUrl { get; set; }
        public string url { get; set; }
    }

    public class Body
    {
        public Messagesegment[] messageSegments { get; set; }
        public string text { get; set; }
    }

    public class Associatedactions
    {
        public object[] platformActionGroups { get; set; }
    }

    public class Bookmarks
    {
        public bool isBookmarkedByCurrentUser { get; set; }
    }

    public class Chatterlikes
    {
        public bool isLikedByCurrentUser { get; set; }
        public Likesmessage likesMessage { get; set; }
        public Like myLike { get; set; }
        public ChatterPage page { get; set; }
    }

    public class ChatterPage
    {
        public string currentPageUrl { get; set; }
        public Item[] items { get; set; }
        public object nextPageUrl { get; set; }
        public object previousPageUrl { get; set; }
        public int total { get; set; }
    }

    public class Comments
    {
        public ChatterPage page { get; set; }
    }

    public class Item
    {
        public Body body { get; set; }
        public Capabilities capabilities { get; set; }
        public object clientInfo { get; set; }
        public DateTime createdDate { get; set; }
        public Feedelement feedElement { get; set; }
        public string id { get; set; }
        public bool isDeleteRestricted { get; set; }
        public Likes likes { get; set; }
        public Likeditem likedItem { get; set; }
        public object likesMessage { get; set; }
        public object moderationFlags { get; set; }
        public object myLike { get; set; }
        public Parent parent { get; set; }
        public string relativeCreatedDate { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public User user { get; set; }
    }

    public class Feedelement
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Likes
    {
        public string currentPageUrl { get; set; }
        public object[] items { get; set; }
        public object nextPageUrl { get; set; }
        public object previousPageUrl { get; set; }
        public int total { get; set; }
    }

    public class User
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
        public object mySubscription { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object recordViewUrl { get; set; }
        public object reputation { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string userType { get; set; }
    }

    public class Topics
    {
        public bool canAssignTopics { get; set; }
        public TopicItem[] items { get; set; }
    }

    public class Header
    {
        public Messagesegment[] messageSegments { get; set; }
        public string text { get; set; }
    }


    public class Reference
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Parent
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
        public object mySubscription { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object recordViewUrl { get; set; }
        public object reputation { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string userType { get; set; }
    }

    public class ChatterDataSource
    {
        private static ChatterDataSource _sampleDataSource = new ChatterDataSource();

        private ObservableCollection<Element> _feed = new ObservableCollection<Element>();
        public ObservableCollection<Element> elements
        {
            get { return this._feed; }
        }

        public ChatterDataSource()
        {
        }

        /*public static async Task<IEnumerable<Element>> GetFeedsAsync(Feed feed)
        {
            await _sampleDataSource.GetFeedDataAsync();

            return _sampleDataSource.elements;
        }*/

        public static async Task<ObservableCollection<Element>> GetFeedAsync(Feed feed)
        {
            await _sampleDataSource.GetFeedDataAsync(feed);
            // Simple linear search is acceptable for small data sets
            return _sampleDataSource.elements; //.Where((element) => group.UniqueId.Equals(uniqueId));
        }

       public static async Task<ObservableCollection<Element>> GetFeedItemAsync(Feed feed)
        {
            await _sampleDataSource.GetLiveFeedDataAsync(feed);
            // Simple linear search is acceptable for small data sets
            //var matches = _sampleDataSource.elements.Where((element) => element.id.Equals(uniqueId));
            //if (matches.Count() == 1) return matches.First();
            //return null;
            return _sampleDataSource.elements;
        }
        private async Task GetLiveFeedDataAsync(Feed feed)
        {
            //if (this._feed.Count != 0)
            //    return;

            RestResponse response = await SendRequest(feed);
            if (response.Success)
            {
                Rootobject e = JsonConvert.DeserializeObject<Rootobject>(response.AsString);
                var a = e.currentPageUrl;
                this._feed = e.elements;
            }
            else
            {
                return;
            }
        }

         private async Task<RestResponse> SendRequest(Feed feed)
        {
            RestRequest restRequest = new RestRequest(HttpMethod.Get, feed.feedElementsUrl);
            
            RestClient client = SalesforceApplication.GlobalClientManager.GetRestClient();
            RestResponse response = await client.SendAsync(restRequest);
            
            return response;
        }

        private async Task GetFeedDataAsync(Feed feed)
        {
            if (Config.LiveData)
            {
                await GetLiveFeedDataAsync(feed);
            } else
            {
                await GetSampleFeedDataAsync();
            }
        }
        private async Task GetSampleFeedDataAsync()
        {
            if (this._feed.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/chatterfeed.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            Rootobject e = JsonConvert.DeserializeObject<Rootobject>(jsonText);
            this._feed = e.elements;
        }
    }

}

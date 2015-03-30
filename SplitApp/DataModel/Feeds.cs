using Newtonsoft.Json;
using Salesforce.SDK.App;
using Salesforce.SDK.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;

namespace SplitApp.Data
{
    public class FeedsDataSource
    {
        private static FeedsDataSource _feedsDataSource = new FeedsDataSource();

        private ObservableCollection<Feed> _feed = new ObservableCollection<Feed>();
        public ObservableCollection<Feed> Feeds
        {
            get { return this._feed; }
        }

        public FeedsDataSource()
        {
        }

        public static async Task<IEnumerable<Feed>> GetFeedsAsync()
        {
            await _feedsDataSource.GetFeedDataAsync();

            return _feedsDataSource.Feeds;
        }

        public static async Task<ObservableCollection<Feed>> GetFeedsAsync(string uniqueId)
        {
            await _feedsDataSource.GetFeedDataAsync();
            // Simple linear search is acceptable for small data sets
            return _feedsDataSource.Feeds; //.Where((element) => group.UniqueId.Equals(uniqueId));
        }

        public static async Task<Feed> GetFeedsItemAsync(string uniqueId)
        {
            await _feedsDataSource.GetFeedDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _feedsDataSource.Feeds.Where((feed) => feed.feedUrl.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
        private async Task GetLiveFeedsDataAsync()
        {
            if (this._feed.Count != 0)
                return;

            RestResponse response = await SendRequest();
            if (response.Success)
            {
                RootFeedsObject e = JsonConvert.DeserializeObject<RootFeedsObject>(response.AsString);
                this._feed = e.feeds;
            }
            else
            {
                return;
            }
        }

        private async Task<RestResponse> SendRequest()
        {
            RestRequest restRequest = new RestRequest(HttpMethod.Get, "/services/data/v32.0/chatter/feeds/news/me/feed-elements/");

            RestClient client = SalesforceApplication.GlobalClientManager.GetRestClient();
            RestResponse response = await client.SendAsync(restRequest);

            return response;
        }

        private async Task GetFeedDataAsync()
        {
            if (Config.LiveData)
            {
                await GetLiveFeedsDataAsync();
            }
            else
            {
                await GetSampleFeedsDataAsync();
            }
        }
        private async Task GetSampleFeedsDataAsync()
        {
            if (this._feed.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/feeds.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            RootFeedsObject e = JsonConvert.DeserializeObject<RootFeedsObject>(jsonText);
            this._feed = e.feeds;
        }
    }

    public class RootFeedsObject
    {
        private ObservableCollection<Favorite> _favorites = new ObservableCollection<Favorite>();
        private ObservableCollection<Feed> _feeds = new ObservableCollection<Feed>();
        public ObservableCollection<Favorite> favorites {
            get
            {
                return _favorites;
            }
        }
        public ObservableCollection<Feed> feeds
        {
            get
            {
                return _feeds;
            }
        }
    }

    public class Favorite
    {
        public object community { get; set; }
        public User createdBy { get; set; }
        public string feedUrl { get; set; }
        public string id { get; set; }
        public DateTime lastViewDate { get; set; }
        public string name { get; set; }
        public string searchText { get; set; }
        public Target target { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public User user { get; set; }
    }

    public class Target
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Feed
    {
        public string feedElementsUrl { get; set; }
        public string feedType { get; set; }
        public string feedUrl { get; set; }
        public string keyPrefix { get; set; }
        public string label { get; set; }
    }


}

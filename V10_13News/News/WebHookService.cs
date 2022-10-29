using JNogueira.Discord.Webhook.Client;
using Newtonsoft.Json;

namespace V10_13News.News
{
    public class WebHookService
    {
        [JsonIgnore]
        private List<string> _webhookURL = new List<string>();
        [JsonIgnore]
        private List<string> _webhookName  = new List<string>();


        [JsonProperty("webhookURLs")]
        public List<string> WebhookURL 
        {
            get
            {
                return _webhookURL;
            } 
            set
            {
                _webhookURL = value;
            }
        }

        [JsonProperty("webhookNames")]
        public List<string> WebhookName 
        { 
            get
            {
                return _webhookName;
            }
            set
            {
                _webhookName = value;
            }
        }


        [JsonIgnore]
        public DiscordWebhookClient this[int index]
        {
            get
            {
                if (index >= _webhookName.Count || index < 0)
                    return null;
                return new DiscordWebhookClient(_webhookURL[index]);
            }
        }
        [JsonIgnore]
        public DiscordWebhookClient this[string name]
        {
            get
            {
                if (_webhookName.IndexOf(name) == -1)
                    return null;
                return new DiscordWebhookClient(_webhookURL[_webhookName.IndexOf(name)]);
            }
        }


        public event Action OnWebhooksChanged;

        public WebHookService()
        {
            
        }

        public void AddWebhook(string name,string url)
        {
            _webhookName.Add(name);
            _webhookURL.Add(url);
            OnWebhooksChanged();
        }

        public void RemoveWebhook(string name)
        {
            if (_webhookName.IndexOf(name) == -1)
                return;
            _webhookURL.RemoveAt(_webhookName.IndexOf(name));
            _webhookName.RemoveAt(_webhookName.IndexOf(name));
            OnWebhooksChanged();
        }
        public void RemoveWebhook(int index)
        {
            if (index >= _webhookName.Count || index < 0)
                return;
            _webhookURL.RemoveAt(index);
            _webhookName.RemoveAt(index);
            OnWebhooksChanged();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscordNews.MainForm;
using JNogueira.Discord.Webhook.Client;

namespace DiscordNews.MainForm
{
    public class DiscordInterface
    {
        private DiscordWebhookClient client;

        public DiscordUserOptions Options { get; set; }

        public DiscordInterface(string Url)
        {
            Options = new DiscordUserOptions();
            client = new DiscordWebhookClient(Url);
        }

        public void Send(List<DiscordMessageData> data)
        {
            foreach(var msg in data)
            {
                DiscordMessage m = new DiscordMessage(msg.Message, Options.Name, Options.ImageUrl);
                DiscordFile f = GetFile(msg.PicturePath);
                client.SendToDiscord(m, new DiscordFile[1] { f } );
            }
        }
        private static DiscordFile GetFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            if (!File.Exists(path))
                return null;
            List<byte> bytes = new List<byte>();
            long iterations = (new FileInfo(path)).Length;
            long bigIterations = iterations / 256;
            iterations -= bigIterations * 256;
            using(var Reader = new BinaryReader(File.OpenRead(path)))
            {
                for (int i = 0; i < bigIterations; i++)
                    bytes.AddRange(Reader.ReadBytes(256));
                bytes.AddRange(Reader.ReadBytes((int)iterations));
            }
            return new DiscordFile(new FileInfo(path).Name, bytes.ToArray());
        }
    }
    public class DiscordUserOptions
    {
        public string Name;
        public string ImageUrl;

        public DiscordUserOptions(string name = "C2:E8:EA:F2:EE:F0",string imageUrl = null)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}

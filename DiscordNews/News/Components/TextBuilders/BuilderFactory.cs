using JNogueira.Discord.Webhook.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using V10_13News.News;

namespace DiscordNews.News.Components.TextBuilders
{
    public static class BuilderFactory
    {
        public static Control CreateBuilder(DataMode mode,DiscordMessage msg)
        {
            switch (mode)
            {
                case DataMode.Text:
                    return new StandartText(msg);
                case DataMode.FooterImage:
                    return new Small_titled_image(msg);
                case DataMode.TitledImage:
                    return new Big_titled_image(msg);
                case DataMode.Embed:
                    return new EmbedEditor(msg);
            }
            return null;
        }
        public static bool TryParseBuilder(Control control,out DataMode? ResDM,out DiscordMessage ResMsg)
        {
            ResDM = null;
            ResMsg = null;
            if(control is IMessageBuilder)
            {
                if (control is StandartText)
                    ResDM = DataMode.Text;
                if (control is EmbedEditor)
                    ResDM = DataMode.Embed;
                if (control is Small_titled_image)
                    ResDM = DataMode.FooterImage;
                if (control is Big_titled_image)
                    ResDM = DataMode.TitledImage;
                ResMsg = (control as IMessageBuilder).Message;           
            }
            if (ResMsg == null || ResDM == null)
                return false;
            return true;
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordNews.MainForm
{
    public interface IDSTextGenerator
    {
        public virtual DiscordMessageData GetDiscordMessage() => throw new NotImplementedException();
    }

    public struct DiscordMessageData
    {
        public string Message { get; set; }
        public string PicturePath { get; set; }
        public DiscordMessageData(string Msg) { Message = Msg; PicturePath = ""; }
        public DiscordMessageData(string Data,bool IsPicture) { Message = IsPicture ? "" : Data; PicturePath = IsPicture ? Data : ""; }
        public DiscordMessageData(string Msg, string Pict) { Message = Msg; PicturePath = Pict; }
    }
}

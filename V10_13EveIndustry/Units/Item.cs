using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using V10_13EveIndustry.Converters;
using Newtonsoft.Json;

namespace V10_13EveIndustry.Units
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        public Item(string name)
        {
            Name = name;
            Count = 1;
            Cost = 0;
        }

        public static Item FromRowData(string d)
        {
            var f = Parser.Parse(d);
            try
            {
                Item res = new Item(f[1]);
                res.Count = int.Parse(f[2]);
                res.Cost = int.Parse(f[3]) / res.Count;
                return res;
            }
            catch(Exception ex)
            { }
            return null;
        }
    }
}

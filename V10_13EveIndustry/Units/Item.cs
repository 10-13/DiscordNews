using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }
    }
}

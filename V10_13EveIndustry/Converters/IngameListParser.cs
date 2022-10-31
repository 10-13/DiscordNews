using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using V10_13EveIndustry.Units;

namespace V10_13EveIndustry.Converters
{
    public static class Parser
    {
        public static List<string> Parse(string data, char Devider = '\t')
        {
            List<string> list = new List<string>();
            while(data.IndexOf(Devider) > -1)
            {
                list.Add(data.Substring(0, data.IndexOf(Devider)));
                data = data.Substring(data.IndexOf(Devider) + 1);
            }
            return list;
        }
    }
}

/*
ID Названия Количество	Оценка стоимости 
1	Гражданского образца Рельсотрон с нарезным стволом Small	1	1500.0 
2	MK7 Рельсотрон Medium с нарезным стволом	2	63552.66 
3	Federation Navy Короткоствольный рельсотрон Small	1	289545.0 

ID	Названия	Количество	Оценка стоимости 
1	Гражданского образца Рельсотрон с нарезным стволом Small	1	1500.0 
2	MK7 Рельсотрон Medium с нарезным стволом	1	31776.33 
3	Federation Navy Короткоствольный рельсотрон Small	1	289545.0 

*/

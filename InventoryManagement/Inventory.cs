
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace InventoryManagement
{
    public class Inventory
    {
        static void Main()
        {
            var data = JsonConvert.DeserializeObject<JToken>("[ { \"name\": \"A\", \"price\": 100, \"stock\": 5 }, { \"name\": \"B\", \"price\": 200, \"stock\": 3 }, { \"name\": \"C\", \"price\": 50, \"stock\": 10 } ]");
            JToken result = SortInventoryByKey(data, "stock", true);
            Console.WriteLine(result);
        }


        public static JToken SortInventoryByKey(JToken data, String key, bool Ascending)
        {

            var sortedList = data.OrderBy(x => x.SelectToken(key)).ToList();
            if (!Ascending)
            {
                sortedList.Reverse();
            }
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}

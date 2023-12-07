using ConsumeRestApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsumeRestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Get all items
            var response = client.GetAsync("fooditems").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringoutcome = response.Content.ReadAsStringAsync().Result;
                List<FoodItem> listFoodItems = JsonConvert.DeserializeObject<List<FoodItem>>(stringoutcome);
                foreach (var fooditem in listFoodItems)
                {
                    Console.WriteLine("Food ID: " + fooditem.Id + " Food name: " + fooditem.Name + "\n");
                }
            }

            // Get one item
            response = client.GetAsync("fooditems/1").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringoutcome = response.Content.ReadAsStringAsync().Result;
                FoodItem foodItem = JsonConvert.DeserializeObject<FoodItem>(stringoutcome);
                Console.WriteLine("Get single item:   Food ID: " + foodItem.Id + " Food name: " + foodItem.Name + "\n");
            }


            // Make post call to api
            FoodItem foodItem1 = new FoodItem() { Name = "IceCream", Id = 3 };
            var jsonObject = JsonConvert.SerializeObject(foodItem1);
            HttpContent httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            response = client.PostAsync("fooditems", httpContent).Result;
            if(response.IsSuccessStatusCode)
            {
                var stringoutcome = response.Content.ReadAsStringAsync().Result;
                FoodItem foodItem = JsonConvert.DeserializeObject<FoodItem>(stringoutcome);
                Console.WriteLine("post operation:   Food ID: " + foodItem.Id + " Food name: " + foodItem.Name + "\n");
            }
            Console.ReadLine();
        }
    }
}

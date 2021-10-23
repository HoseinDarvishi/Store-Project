using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Administration.Pages
{
   public class IndexModel : PageModel
   {
      public List<Chart> UsersRep;
      public List<Chart> ArticleRep;

      public void OnGet()
      {
         UsersRep = new List<Chart>
         {
            new Chart
            {
               Label = "Apple",
               Data = new List<int>{200 , 300 , 100 , 200},
               BackgroundColor =new[]{"#ffcdb2" },
               BorderColor = "#bbbb"
            },
            new Chart
            {
               Label = "Samsung",
               Data = new List<int>{1000 , 500 , 900 , 1400},
               BackgroundColor =new[] {"#ffc8dd" },
               BorderColor = "#bbbb"
            },
            new Chart
            {
               Label = "Total",
               Data = new List<int>{1200 , 800 , 1000 , 1600},
               BackgroundColor =new[]{"#0077b6" },
               BorderColor = "#bbbb"
            }
         };

         ArticleRep = new List<Chart>
         {
            new Chart
            {
               Label = "Total",
               Data = new List<int>{1200 , 800 , 1000},
               BackgroundColor =new[]{"#0077b6" , "#0077b6","#ffc8dd"},
               BorderColor = "#bbbb"
            }
         };
      }
   }

   public class Chart 
   {
      [JsonProperty(PropertyName="label")]
      public string Label { get; set; }

      [JsonProperty(PropertyName= "data")]
      public List<int> Data { get; set; }

      [JsonProperty(PropertyName= "backgroundColor")]
      public string[] BackgroundColor { get; set; }

      [JsonProperty(PropertyName= "borderColor")]
      public string BorderColor { get; set; }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrelloWPF.Models;

namespace TrelloWPF
{
    public static class DB
    {
        static public IEnumerable<object> GetTasks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55498/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/TaskApi/All").Result;

            if (response.IsSuccessStatusCode)
            {
                var tasks = response.Content.ReadAsAsync<IEnumerable<object>>().Result;
                return tasks;
                //grdEmployee.ItemsSource = employees;

            }
            else
            {
                string s = response.StatusCode + response.ReasonPhrase;
            }

            return new List<Tasks>();
        }


    }
}

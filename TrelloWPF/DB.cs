using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ToDoListDLL;


namespace TrelloWPF
{
    public static class DB
    {
        static String Uri = "https://todolistwebapi20180823030718.azurewebsites.net/";

        static public Users GetCurrentUser(string id, string pwd) 
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(DB.Uri)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"api/UserConnexion/Connect/{id}/{pwd}").Result;

            if (response.IsSuccessStatusCode)
            {
                Users user = response.Content.ReadAsAsync<Users>().Result;             
                if (user != null)
                { 
                    return user as Users;
                }
            }
            return null;
        }

        static public IEnumerable<Tasks> GetTasks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);         
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/TaskApi/All").Result;

            if (response.IsSuccessStatusCode)
            {
                var tasks = response.Content.ReadAsAsync<IEnumerable<Tasks>>().Result.ToList();
                return tasks;
            }

            return new List<Tasks>();
        }

        static public async void AddTask(Tasks tasks)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //StringContent content = new StringContent(JsonConvert.SerializeObject(tasks), Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("api/TaskApi/ADD/{task}", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadAsStringAsync();
            //}

            HttpResponseMessage response = await client.PostAsJsonAsync("api/TaskApi/ADD/%7Btask%7D", tasks);

            if (response.IsSuccessStatusCode)
            {
                Tasks t = response.Content.ReadAsAsync<Tasks>().Result;
            }
        }

        static public void EditTask(Tasks tasks)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PutAsJsonAsync("api/TaskApi/EDIT/{task}", tasks);
        }

        static public void DeleteTask(Tasks tasks)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.DeleteAsync($"api/TaskApi/DEL/{tasks}");
        }
    }
}

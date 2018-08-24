using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDoListDLL;


namespace TrelloWPF
{
    public static class DB
    {
        static String Uri = "https://todolistwebapi20180823030718.azurewebsites.net/";
        public static Users CurrentUser;

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
                    DB.CurrentUser = user as Users;
                    return user as Users;
                }
            }
            return null;
        }

        static public IEnumerable<object> GetTasks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);         
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");

            HttpResponseMessage response = client.GetAsync("api/TaskApi/All").Result;

            if (response.IsSuccessStatusCode)
            {
                var tasks = response.Content.ReadAsAsync<IEnumerable<Tasks>>().Result.ToList();
                return tasks;
            }
            else
            {
                string s = response.StatusCode + response.ReasonPhrase;
            }

            return new List<Tasks>();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloWPF.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string TaskState { get; set; }
        public DateTime DeadLine { get; set; }
        public string Note { get; set; }
        public int IdUserCreator { get; set; }
        public List<Users> Contributors { get; set; }

        public Tasks() {
        }
    }
}

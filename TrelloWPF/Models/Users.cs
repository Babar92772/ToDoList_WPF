using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloWPF.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }

        public Users() {
        }
    }
}

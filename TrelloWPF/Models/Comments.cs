using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloWPF.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Deadline { get; set; }
        public virtual int IdUser { get; set; }
        public virtual int IdTask { get; set; }

        public Comments() {
        }
    }
}

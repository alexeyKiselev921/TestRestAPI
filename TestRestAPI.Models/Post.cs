using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long AuthorId { get; set; }
        public DateTime Date { get; set; }
    }
}

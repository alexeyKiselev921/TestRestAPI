using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public long AuthorId { get; set; }
        public DateTime Date { get; set; }
        public long PostId { get; set; }
    }
}

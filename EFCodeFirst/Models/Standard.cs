using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    public class Standard
    {
        public Standard()
        {

        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
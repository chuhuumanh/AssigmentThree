using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_A.Models
{
    public class StudentWarning
    {
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
        [Key, Column(Order = 2)]
        public int ActionId { get; set; }
        public string Note { get; set; }
    }
}
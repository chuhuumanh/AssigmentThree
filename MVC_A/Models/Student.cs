using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_A.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Id sinh viên")]
        public int Id { get; set; }
        [DisplayName("Id lớp học")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        [DisplayName("Mã sinh viên")]
        public string Code { get; set; }
        [DisplayName("Tên sinh viên")]
        public string Name { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public ICollection<Warning> Warnings { get; set; }
    }
}
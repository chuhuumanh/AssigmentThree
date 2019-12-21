using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using MVC_A.Models;

namespace MVC_A.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel(int id, int classId, string code, string name, string phone, string email)
        {
            Id = id;
            ClassId = classId;
            Code = code;
            Name = name;
            Phone = phone;
            Email = email;
            GetClass();
        }
        [DisplayName("Id sinh viên")]
        public int Id { get; set; }
        [DisplayName("Id lớp học")]
        public int ClassId { get; set; }
        [DisplayName("Mã sinh viên")]
        public string Code { get; set; }
        [DisplayName("Tên sinh viên")]
        public string Name { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Tên lớp")]
        public string ClassName { get; set; }

        public void GetClass()
        {
            if (ClassId > 0)
            {
                using (MyContext db = new MyContext())
                {
                    this.ClassName = db.Classes.Find(this.ClassId) != null ? db.Classes.Find(this.ClassId).Name : String.Empty;
                }
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using MVC_A.Models;

namespace MVC_A.ViewModels
{
    public class EditStudentViewModel
    {
        public EditStudentViewModel(int id, int classId, string code, string name, string phone, string email)
        {
            Id = id;
            ClassId = classId;
            Code = code;
            Name = name;
            Phone = phone;
            Email = email;
            GetClasses();
        }

        public EditStudentViewModel()
        {
            GetClasses();   
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
        public IEnumerable<Class> Classes { get; set; }

        public void GetClasses()
        {
            using (MyContext db = new MyContext())
            {
                Classes = db.Classes.ToList().AsEnumerable();
            }
        }
    }
}
﻿

namespace StudentPortal.Models
{
    public class AddStudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool Subscribed { get; set; }
    }
}

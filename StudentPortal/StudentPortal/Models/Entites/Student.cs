﻿using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entites
{
    public class Student
    {
        [Key] public int Id { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool Subscribed { get; set; }

    }
}

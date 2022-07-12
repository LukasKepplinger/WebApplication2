﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

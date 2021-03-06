﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    // Model template
    public class Customers
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }    
    }
}
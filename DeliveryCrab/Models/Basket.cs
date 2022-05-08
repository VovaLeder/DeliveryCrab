﻿using System.ComponentModel.DataAnnotations.Schema;
namespace DeliveryCrab.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public string? Productname { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
    }
}

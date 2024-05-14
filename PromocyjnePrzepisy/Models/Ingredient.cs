﻿using System.Text.Json.Serialization;
namespace PromocyjnePrzepisy.Models
{
    public class Ingredient
    {
        [JsonPropertyName("name")]
        public string Name { get; }
        public List<Product> Products = new List<Product>();
        public bool HasDiscounts { get { return Products.Count > 0; } }
        public Ingredient(string name, List<Product>? products)
        {
            if (products != null) Products = products;
            Name = name;
        }
    }
}
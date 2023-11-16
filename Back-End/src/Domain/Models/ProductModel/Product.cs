using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.CategoryModel
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string IdCategory { get; set; } = "";
        public string urlImage { get; set; } //Imagem do Produto
        public int  Amount { get; set; }
        public  decimal Price {get; set;}     
    }
}
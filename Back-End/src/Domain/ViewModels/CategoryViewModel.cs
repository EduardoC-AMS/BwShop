using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } 
        public bool IsActive { get; set; }   
    }
}
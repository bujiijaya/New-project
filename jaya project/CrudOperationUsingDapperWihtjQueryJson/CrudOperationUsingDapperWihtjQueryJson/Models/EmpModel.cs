using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CrudOperationUsingDapperWihtjQueryJson.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        [Required]
        public string Name {get; set; }
        [Required]

        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
    
}
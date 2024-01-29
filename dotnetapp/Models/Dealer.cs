using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
   public class Dealer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime RegistrationDate {get; set;}
     public string AutoPartName { get; set; }
      public string Manufacturer { get; set; }
       public string MobileNumber { get; set; }
        public string Email { get; set; }
         public string Description { get; set; }
}
}
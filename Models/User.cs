using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FavoriteLanguage { get; set; }
        public string MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
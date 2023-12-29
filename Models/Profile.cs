using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ProfileService.Models
{
[Table("ProfileView")]
    public class Profiles
    {
        [Key]
        [Column("Users")]
        public string Email {get; set;} = string.Empty;

        [NotMapped]
        public bool Valid{get; set;}

        public DateTime DoB {get; set;}
        public decimal Lat {get; set;} = decimal.Zero;
        public decimal Long {get; set;} = decimal.Zero;
        public string Title {get; set;} = string.Empty;

    }

}
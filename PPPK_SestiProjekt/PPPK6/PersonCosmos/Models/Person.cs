using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonCosmos.Models
{
    public class Person
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [Display(Name ="First name")]
        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [Range(1, 120, ErrorMessage ="Age must be value between 1 and 120!")]
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [Display(Name = "Are you married?")]
        [JsonProperty(PropertyName = "married")]
        public bool IsMarried { get; set; }
    }
}
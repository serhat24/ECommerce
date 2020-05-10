using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Model.Models.Entities
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }
        public bool Status { get; set; }
        public bool Removed { get; set; }
    }
}

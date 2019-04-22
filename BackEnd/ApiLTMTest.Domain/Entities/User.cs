using ApiLTMTest.Domain.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiLTMTest.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [Required]
        public string Password { get; set; }

    }
}

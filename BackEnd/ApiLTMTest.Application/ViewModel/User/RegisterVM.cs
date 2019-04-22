using ApiLTMTest.Application.Util.Functions;
using ApiLTMTest.Domain.Enums;
using System;

namespace ApiLTMTest.Application.ViewModel
{
    public class RegisterVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime JoinDate
        {
            get
            {
                return DateTime.Now;
            }
        }
        public string Password { get; set; }

    }
}

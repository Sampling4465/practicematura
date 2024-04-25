using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    // TODO: Rich DomainModel implementieren
    public class InnolabUser : BaseInterface<int>
    {

#pragma warning disable CS8618
        protected InnolabUser() { }

#pragma warning restore CS8618
        public int Id { get; private set; }

        public InnolabUser(string email, string lastName, string firstName)
        {
            Email = email;
            LastName = lastName;
            FirstName = firstName;
        }

        [Required]
        public string Email { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }


    }
}

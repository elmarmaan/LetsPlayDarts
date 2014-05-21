using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Account
    {
        public Account()
        {
            IsAdmin = false;
        }
        public long Id { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}

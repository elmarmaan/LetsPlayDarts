using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        public long Id { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

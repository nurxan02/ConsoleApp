using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp
{
    [Serializable]
    internal class Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Surname} {Age}";
        }
    }
}

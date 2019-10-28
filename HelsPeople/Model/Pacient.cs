using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.Model
{
    public class Pacient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }
        

        //TODO
        // Add Additional contacts 
    }
}

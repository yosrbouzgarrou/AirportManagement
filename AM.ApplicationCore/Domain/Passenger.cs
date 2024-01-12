using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }//cle primaire selon les convensions par defaut de ORM 
        [Display(Name = "Date of Birth"),DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7,ErrorMessage = "un champ de 7 caractères")]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [MinLength(3,ErrorMessage ="Min length 3"),MaxLength(25, ErrorMessage ="Max length 25")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public FullName FullName { get; set; }
        //[Range(10000000,99999999)]
        [RegularExpression(@"^[0-9]{8}$",ErrorMessage ="invalid phone number")]
        public int TelNumber { get; set; }
        // prop de navigation
        public virtual List<Flight> Flights { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        //Méthodes
        //public bool CheckProfile(string firstName,string lastName)
        //{
        //    /*if(firstName == this.FirstName || lastName == this.LastName)
        //    {
        //        return true;    
        //    }
        //    return false;*/
        //    return firstName==FirstName && lastName==LastName;
        //}
        //public bool CheckProfile(string firstName, string lastName,string emailAddress)
        //{
        //    return firstName == FirstName && lastName == LastName && emailAddress==EmailAddress;
        //}
        public bool CheckProfile(string firstName, string lastName, string? emailAddress=null)
        {
            if(emailAddress==null)
                return firstName == FullName.FirstName && lastName == FullName.LastName;
            return firstName == FullName.FirstName && lastName == FullName.LastName && emailAddress == EmailAddress;
        }

        public virtual string PassengerType()
        {
            return "I am a passenger";
        }



        
        

    }
}

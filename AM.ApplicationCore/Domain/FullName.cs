using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]//entite sans cle primaire
    public class FullName
    {
        public string FirstName { get; set; }
        //[Required]//Obligatoire : not Null
        public string LastName { get; set; }    
    }
}

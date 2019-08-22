using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataObjects.Data
{
    public class Charge
    {

        public int Id { get; set; }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public decimal Summ { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public int AdministratorId { get; set; }
    }

    public class ChargeExtended : Charge
    {

       public string GroupName { get; set; }
    }
}

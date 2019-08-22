using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataObjects.Data
{
    public class AbonementIncome
    {
        public int  Id { get; set; }

        public int ClientId { get; set; }
        public int AbonementId { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public decimal Summ { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeleteDate { get; set; }

        public string DeleteReason { get; set; } 
    }

    public class AbonementIncomeExtended : AbonementIncome
    {
        public string ClientName { get; set; }

        public string AbonementName { get; set; }

        public string UserName { get; set; }
    }
}

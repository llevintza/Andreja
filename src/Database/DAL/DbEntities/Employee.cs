using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{

    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("EmployeeId")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [Column("EmployeeNum", Order = 1, TypeName = "nvarchar")]
        [MaxLength(16)]
        public string EmployeeNumber { get; set; }

        public DateTime EmployedDate { get; set; }

        public DateTime? TerminatedDate { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

    }
}

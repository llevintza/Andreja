using System;

namespace DTO
{
    public class Employee
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string EmployeeNumber { get; set; }

        public DateTime EmployedDate { get; set; }

        public DateTime? TerminatedDate { get; set; }
    }
}

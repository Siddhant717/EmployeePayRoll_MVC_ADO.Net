using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StudentAdmissionService.Models
{
    public class StudentAdmission
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }
}

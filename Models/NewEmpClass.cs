using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCCrudApplication.Models
{
    public class NewEmpClass
    {
        [Key]
        public int Empid { get; set; }


        [Required(ErrorMessage ="Enter Employee Name")]
        [Display (Name ="Employee Name")]
        public String EmpName { get; set; }



        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]



        public String Email { get; set; }




        [Required(ErrorMessage = "Enter Employee Age")]
        [Display(Name = "Employee Age")]
        [Range(20,80)]

        public int Age { get; set; }


        [Required(ErrorMessage = "Enter Salary")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }


    }
}

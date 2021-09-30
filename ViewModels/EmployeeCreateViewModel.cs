using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrudApplication.ViewModels
{
    public class EmployeeCreateViewModel
    {


        [Required(ErrorMessage = "Enter Employee Name")]
        [Display(Name = "Employee Name")]
        public String EmpName { get; set; }



        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]



        public String Email { get; set; }




        [Required(ErrorMessage = "Enter Employee Age")]
        [Display(Name = "Employee Age")]
        [Range(20, 80)]

        public int Age { get; set; }


        [Required(ErrorMessage = "Enter Salary")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }


        //[Column(TypeName = "nvarchar(100)")]
        //public  string ImageName { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}

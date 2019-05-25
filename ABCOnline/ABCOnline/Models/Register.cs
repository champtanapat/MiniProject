using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCOnline.Models
{
    public class Registers
    {
        public int Id { get; set; }
        public int age { get; set; }

        [Display(Name = "FistName")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string firstName { get; set; }


        [Display(Name = "LastName")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string lastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string address { get; set; }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string birthday { get; set; }
    }
}
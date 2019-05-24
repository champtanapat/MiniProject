using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCOnline.Models
{
    public class Member
    {
        [Display(Name = "Fist Name")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string firstName { get; set; }


        [Display(Name = "Last Name")]

        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string lastName { get; set; }


        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string address { get; set; }


        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string age { get; set; }



        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบถ้วน")]
        public string birthday { get; set; }
    }
}
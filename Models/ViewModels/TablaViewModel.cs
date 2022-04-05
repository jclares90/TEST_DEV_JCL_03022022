using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST_DEV_JCL_03022022.Models.ViewModels
{
    public class TablaViewModel
    {
        public int id { get; set; }
        public DateTime fecharegitro { get; set; }
        public DateTime fechaactualizacion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "apellido paterno")]
        public string apaterno { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "apellido materno")]
        public string amaterno { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "rfc")]
        public string rfc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "fecha de nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime fechanacimiento { get; set; }
        public string usuarioadd { get; set; }
        public string estatus { get; set; }
    }
}
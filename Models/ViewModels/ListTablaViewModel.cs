using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_DEV_JCL_03022022.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int id { get; set; }
        public DateTime fecharegitro { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string nombre { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public string rfc { get; set; }
        public string fechanacimiento { get; set; }
        public string usuarioadd { get; set; }
        public string estatus { get; set; }
    }
}
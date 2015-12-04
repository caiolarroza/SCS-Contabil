using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSCONTABIL2
{
    class Saldo
    {
        
        public int SalQtd { get; set; }
        public decimal SalVun { get; set; }
        public decimal SalVto { get; set; }
        public string salProd { get; set; }
        public DateTime dataSal { get; set; }
        public string SalDat { get; set; }
        public int ProQtd { get; set; }
        public DateTime dataPro { get; set; }
        public string ProDat { get; set; }
        public string ProNom { get; set; }
        public decimal ProVto { get; set; }
        public decimal ProVun { get; set; }
        public decimal ProFre { get; set; }
        public decimal ProIcms { get; set; }
        public string VenPro { get; set; }
        public int VenQtd { get; set; }
        public DateTime dataVen { get; set; }
        public decimal VenVun { get; set; }
        public decimal VenVto { get; set; }
        public string VenDat { get; set; }

    }
}

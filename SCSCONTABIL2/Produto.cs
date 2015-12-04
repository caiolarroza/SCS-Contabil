using System;

namespace SCSCONTABIL2
{
    class Produto
    {
        public int ProCod { get; set; }
        public String ProNom { get; set; }
        public int ProFor { get; set; }
        public decimal ProPco { get; set; }
        public DateTime data { get; set; }
        public String ProDat { get; set; }
        public int ProQtd { get; set; }
        public decimal ProPcoTot { get; set; }
        public decimal ProFre { get; set; }
        public decimal ProIcms { get; set; }
        public int SalQtd { get; set; }

    }
}

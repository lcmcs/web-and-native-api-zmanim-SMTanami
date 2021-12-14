using System;
using System.Collections.Generic;
using System.Text;

namespace PDFGenerator
{ 
    public interface IZmanimGetter
    {
        DateTime GetSunrise(DateTime date);

        public DateTime GetSofShema(DateTime date);

        public DateTime GetZmanTefillah(DateTime date);

        public DateTime GetChatzot(DateTime date);

        public DateTime GetMGedolah(DateTime date);

        public DateTime GetMKetana(DateTime date);

        public DateTime GetPlag(DateTime date);

        DateTime GetSunset(DateTime date);
    }
}

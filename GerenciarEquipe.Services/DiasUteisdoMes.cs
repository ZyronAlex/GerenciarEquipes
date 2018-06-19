using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Services
{
    public static class DiasMes
    {
        public static int diasUteis(DateTime mes)
        {
            int diasdomes = DateTime.DaysInMonth(mes.Year, mes.Month);
            int dias = 0;

            for (int i = 1; i <= diasdomes; i++)
            {
                if (isDiaUtil(new DateTime(mes.Year, mes.Month, i)))
                    dias++;
            }
            return dias;
        }
        public static bool isDiaUtil(DateTime dia)
        {
            return !(dia.DayOfWeek == DayOfWeek.Saturday || dia.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Multi : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 1d;
            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    foreach (String s in arg.ToString().Split(','))
                        res = res * Convert.ToDouble(s.Trim().Replace('.', ','));
                }
                else
                {
                    return 0d;
                }

            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca wynik mnożenia argumentów.";
        }

        public string[] getExamples()
        {
            return new string[] {
                "iloczyn(2,3)",
                "iloczyn(A1:B3)",
                "iloczyn(3, 90, 4, 2)",
                "iloczyn(3.2, 8, 4.5, 312.599, 12.0, 3)"
            };
        }
    }
}

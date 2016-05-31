using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    interface IFunction
    {
        Object run(Object[] args);
        string getHelp();
        string[] getExamples();
    }
}

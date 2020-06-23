using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DietApplication.Print
{
    interface IPrint
    {
        Status Print(FlowDocument document); //pg 996
    }

    class Print : IPrint
    {
        public Print()
        {

        }

        Status IPrint.Print(FlowDocument document)
        {
            throw new NotImplementedException();
        }
    }
}

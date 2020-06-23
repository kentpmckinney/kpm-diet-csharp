using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DietApplication.Report
{
    interface IReport
    {
        FlowDocument Create(string reportName);
    }

    class Report : IReport
    {
        FlowDocument IReport.Create(string reportName)
        {
            throw new NotImplementedException();
        }
    }
}

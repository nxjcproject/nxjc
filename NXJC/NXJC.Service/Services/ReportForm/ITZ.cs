using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXJC.Service.Messages.ReportForm;

namespace NXJC.Service.Services.ReportForm
{
    public interface ITZ
    {
        TZResponse GetTZ(TZRequest request);
        //TZResponse GetTZByKeyId(TZRequest request);
        //IDictionary<int, string> GetTableNameList();
    }
}

using SFN_DATA.ENTITY;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.IBLL
{
    public interface ILogicielBll
    {
      
        JsonLogiciel GetLogicielByCode(string code);
        Reponse UpdateLogiciel(JsonLogiciel json);
    }
}

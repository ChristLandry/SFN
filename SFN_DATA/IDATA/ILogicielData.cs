using SFN_DATA.ENTITY;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.IDATA
{
    public interface ILogicielData
    {
        EntityLogiciel GetLogicielByCode(string code);
        Reponse UpdateLogiciel(EntityLogiciel entityLogiciel);
    }
}

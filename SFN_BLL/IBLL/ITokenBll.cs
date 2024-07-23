using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.IBLL
{
    public interface ITokenBll
    {
        object GetToken(JsonLogiciel _JsonLogiciel);
    }
}

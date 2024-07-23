using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.BLL
{
    public interface IDecrypte
    {
        string EncryptStringAES(string plainText, string sharedSecret);
        string DecryptStringAES(string cipherText, string sharedSecret);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Helpers
{
    public interface IMahoaHelper
    {
        string Mahoa(string source);
    }
    public class MahoaHelper : IMahoaHelper
    {
        public string Mahoa(string source)
        {
            string hash = "";
            using (var mdSHash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytes = mdSHash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return hash;
        }
    }
}

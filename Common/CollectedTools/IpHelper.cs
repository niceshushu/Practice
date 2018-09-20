using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Common.CollectedTools
{
    public class IpHelper
    {
        public static bool IsLocalIp(string ipAddress)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                if (ipAddress.StartsWith("192.168.") || ipAddress.StartsWith("127.") || ipAddress.StartsWith("10."))
                {
                    return true;
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace S_KYA_Core.Model
{
    public abstract class BaseSession
    {
        DateTime mExpiresTime;

        [JsonConverter(typeof(TimestampConverter))]
        public DateTime ExpiresTime { get { return mExpiresTime; } set { SetExpiresTime(value); } }

        public void SetExpiresTime(DateTime aExpiresTime)
        {
            mExpiresTime = aExpiresTime;
        }

        [JsonIgnore]
        public abstract string ServerID { get; }
    }
}

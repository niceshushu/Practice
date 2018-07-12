using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Core.Model
{
    /// <summary>
    /// Json返回类
    /// </summary>
    public class Mod_Com_Json
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string StatuCode { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 附带信息
        /// </summary>
        public object Data { get; set; }
    }
}

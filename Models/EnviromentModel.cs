using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 环境项
    /// </summary>
    internal class EnviromentModel
    {
        /// <summary>
        /// 环境项名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 环境项数值
        /// </summary>
        public int ItemValue { get; set; }
    }
}

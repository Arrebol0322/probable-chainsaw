using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 设备项
    /// </summary>
    class EquipmentModel
    {
        /// <summary>
        /// 设备项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 设备项数据
        /// </summary>
        public string ItemValue { get; set; }
    }
}

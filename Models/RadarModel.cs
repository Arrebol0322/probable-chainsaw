using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 雷达项
    /// </summary>
    public class RadarModel
    {
        /// <summary>
        /// 项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 项数据
        /// </summary>
        public double ItemValue { get; set; }
    }
}

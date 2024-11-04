using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 车间详情
    /// </summary>
    class WorkShopModel
    {
        /// <summary>
        /// 车间名
        /// </summary>
        public string WorkshopName { get; set; }

        /// <summary>
        /// 作业中的机台数
        /// </summary>
        public int WorkingNumber { get; set; }

        /// <summary>
        /// 等待的机台数
        /// </summary>
        public int WaitingNumber { get; set; }

        /// <summary>
        /// 故障数
        /// </summary>
        public int BreakdownNumber { get; set; }

        /// <summary>
        /// 停机数
        /// </summary>
        public int HaltNumber { get; set; }

        /// <summary>
        /// 机台总数
        /// </summary>
        public int TotalityNumber
        {
            get { return WorkingNumber + WaitingNumber + BreakdownNumber + HaltNumber; }
        }
    }
}

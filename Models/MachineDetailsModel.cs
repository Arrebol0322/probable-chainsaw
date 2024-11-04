using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    internal class MachineDetailsModel
    {
        /// <summary>
        /// 机台号
        /// </summary>
        public int MachinNumber { get; set; }

        /// <summary>
        /// 机台状态
        /// </summary>
        public string MachinState { get; set; }

        /// <summary>
        /// 已完成数量
        /// </summary>
        public int DoneNumber { get; set; }

        /// <summary>
        /// 目标数量
        /// </summary>
        public int TargetNumber { get; set; }

        /// <summary>
        /// 工单号
        /// </summary>
        public string WorkOderNumber { get; set; }

        /// <summary>
        /// 机台状态显示的颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 已完成数量百分比
        /// </summary>
        public double Percent
        {
            get { return DoneNumber *100/ TargetNumber; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 人力项
    /// </summary>
    class VacancyModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string ItemName{ get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string ItemPost{ get; set; }
        /// <summary>
        /// 缺岗次数
        /// </summary>
        public int ItemNumber { get; set; }
    }
}

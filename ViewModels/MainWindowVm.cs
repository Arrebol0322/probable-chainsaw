using Microsoft.VisualBasic;
using ProductMonitor.Models;
using ProductMonitor.MyUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    internal class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 初始化环境监控数据
        /// </summary>
        public MainWindowVm()
        {
            #region 初始化环境监控数据
            EnviromentModelList = new List<EnviromentModel>();
            EnviromentModelList.Add(new EnviromentModel { ItemName = "光照(Lux)", ItemValue = 124 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "噪音(db)", ItemValue = 56 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "温度(℃)", ItemValue = 81 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "湿度(%)", ItemValue = 44 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "PM2.5(m³)", ItemValue = 21 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "硫化氢(PPM)", ItemValue = 16 });
            EnviromentModelList.Add(new EnviromentModel { ItemName = "氮气(PPM)", ItemValue = 19 });
            #endregion

            #region 初始化报警数据
            AlarmModelList = new List<AlarmModel>();
            AlarmModelList.Add(new AlarmModel { Number = "01", WarningMessage = "设备温度过高", Time = "2023-10-13 18:30", Duration = 5 });
            AlarmModelList.Add(new AlarmModel { Number = "02", WarningMessage = "车间温度过高", Time = "2023-11-13 11:30", Duration = 27 });
            AlarmModelList.Add(new AlarmModel { Number = "03", WarningMessage = "设备转速过快", Time = "2023-12-13 08:30", Duration = 7 });
            AlarmModelList.Add(new AlarmModel { Number = "04", WarningMessage = "设备气压偏低", Time = "2024-01-13 15:30", Duration = 2 });
            #endregion

            #region 初始化设备监控数据
            EquipmentModelList = new List<EquipmentModel>();
            EquipmentModelList.Add(new EquipmentModel { ItemName = "电能(Kw·h)", ItemValue = "60.8" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "电压(V)", ItemValue = "390" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "电流(A)", ItemValue = "5" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "压差(kpa)", ItemValue = "13" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "温度(℃)", ItemValue = "36" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "震动(mm/s)", ItemValue = "4.1" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "转速(r/min)", ItemValue = "2600" });
            EquipmentModelList.Add(new EquipmentModel { ItemName = "气压(kpa)", ItemValue = "0.5" });
            #endregion

            #region 初始化雷达数据 
            RadarList = new List<RadarModel>();
            RadarList.Add(new RadarModel { ItemName = "排烟风机", ItemValue = 80 });
            RadarList.Add(new RadarModel { ItemName = "客梯", ItemValue = 20.19 });
            RadarList.Add(new RadarModel { ItemName = "供水机", ItemValue = 50.25 });
            RadarList.Add(new RadarModel { ItemName = "喷淋水泵", ItemValue = 10 });
            RadarList.Add(new RadarModel { ItemName = "稳压设备", ItemValue = 30.87 });
            #endregion

            #region 初始化人力数据
            VacancyList = new List<VacancyModel>();
            VacancyList.Add(new VacancyModel { ItemName = "张晓婷", ItemPost = "技术员", ItemNumber = 52 });
            VacancyList.Add(new VacancyModel { ItemName = "李晓", ItemPost = "操作员", ItemNumber = 32 });
            VacancyList.Add(new VacancyModel { ItemName = "王克俭", ItemPost = "统计员", ItemNumber = 82 });
            VacancyList.Add(new VacancyModel { ItemName = "杨过", ItemPost = "技术员", ItemNumber = 112 });
            VacancyList.Add(new VacancyModel { ItemName = "陈家栋", ItemPost = "操作员", ItemNumber = 52 });
            #endregion

            #region 初始化车间详情数据
            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel { WorkshopName = "贴片车间", WorkingNumber = 30, WaitingNumber = 10, BreakdownNumber = 5, HaltNumber = 5 });
            WorkShopList.Add(new WorkShopModel { WorkshopName = "封装车间", WorkingNumber = 28, WaitingNumber = 9, BreakdownNumber = 5, HaltNumber = 2 });
            WorkShopList.Add(new WorkShopModel { WorkshopName = "焊接车间", WorkingNumber = 22, WaitingNumber = 7, BreakdownNumber = 3, HaltNumber = 4 });
            WorkShopList.Add(new WorkShopModel { WorkshopName = "贴片车间", WorkingNumber = 21, WaitingNumber = 6, BreakdownNumber = 1, HaltNumber = 5 });
            #endregion

            #region 初始化机台数据            
            MachineDetailsList = new List<MachineDetailsModel>();
            for (int i = 0; i < 25; i++)
            {
                //使用随机数赋值目标产量和已完成产量
                Random random = new Random();
                int targetNumber = random.Next(300, 1000);
                int doneNumber = random.Next(0, targetNumber);
                string machinState = null;
                switch (random.Next(1, 5))
                {
                    case 1:
                        machinState = "作业中";
                        MachineDetailsList.Add(new MachineDetailsModel { MachinNumber = i + 1, MachinState = machinState, DoneNumber = doneNumber, TargetNumber = targetNumber, WorkOderNumber = "HH145374316" ,Color="LightGreen"});
                        break;
                    case 2:
                        machinState = "等待中";
                        MachineDetailsList.Add(new MachineDetailsModel { MachinNumber = i + 1, MachinState = machinState, DoneNumber = doneNumber, TargetNumber = targetNumber, WorkOderNumber = "HH145374316", Color = "Orange" });
                        break;
                    case 3:
                        machinState = "故障中";
                        MachineDetailsList.Add(new MachineDetailsModel { MachinNumber = i + 1, MachinState = machinState, DoneNumber = doneNumber, TargetNumber = targetNumber, WorkOderNumber = "HH145374316", Color = "Red" });
                        break;
                    case 4:
                        machinState = "停机中";
                        MachineDetailsList.Add(new MachineDetailsModel { MachinNumber = i + 1, MachinState = machinState, DoneNumber = doneNumber, TargetNumber = targetNumber, WorkOderNumber = "HH145374316", Color = "Gray" });
                        break;
                    default:
                        break;
                }               
            }
            #endregion
        }

        /// <summary>
        /// 监控用户控件
        /// </summary>
        private UserControl _monitorUserControl;
        public UserControl MonitorUserControl
        {
            get
            {
                if (_monitorUserControl == null)
                {
                    _monitorUserControl = new MonitorUC();
                }
                return _monitorUserControl;
            }
            set
            {
                _monitorUserControl = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUserControl"));
                }
            }
        }

        #region 时间 日期
        /// <summary>
        /// 时间 小时:分钟
        /// </summary>
        public string TimeStr
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }

        /// <summary>
        /// 日期 年:月:日
        /// </summary>
        public string DateStr
        {
            get { return DateTime.Now.ToString("yyyy:MM:dd"); }
        }

        /// <summary>
        /// 星期
        /// </summary>
        public string WeekStr
        {
            get
            {
                string dayOfWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                return dayOfWeek;
            }
        }
        #endregion

        #region 生产计数(此处使用固定数值)

        /// <summary>
        /// 机台总数
        /// </summary>
        private string _machineCount = "0527";
        public string MachineCount
        {
            get { return _machineCount; }
            set
            {
                _machineCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(MachineCount));
                }
            }
        }

        /// <summary>
        /// 生产总数
        /// </summary>
        private string _totalOutput = "1593";
        public string TotalOutput
        {
            get { return _totalOutput; }
            set
            {
                _totalOutput = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(TotalOutput));
                }
            }
        }

        /// <summary>
        /// 不良数
        /// </summary>
        private string _defectQuantity = "23";
        public string DefectQuantity
        {
            get
            {
                return _defectQuantity;
            }
            set
            {
                _defectQuantity = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(DefectQuantity));
                }
            }
        }
        #endregion

        #region 环境监控属性
        /// <summary>
        /// 环境监控数据
        /// </summary>
        private List<EnviromentModel> _enviromentModelList;

        /// <summary>
        /// 环境监控数据
        /// </summary>
        public List<EnviromentModel> EnviromentModelList
        {
            get { return _enviromentModelList; }
            set
            {
                _enviromentModelList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnviromentModelsList"));
                }
            }
        }
        #endregion

        #region 报警属性
        private List<AlarmModel> _alarmModelList;
        public List<AlarmModel> AlarmModelList
        {
            get { return _alarmModelList; }
            set
            {
                _alarmModelList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AlarmModelList"));
                }
            }
        }

        #endregion

        #region 设备监控属性
        private List<EquipmentModel> _equipmentModelList;
        public List<EquipmentModel> EquipmentModelList
        {
            get { return _equipmentModelList; }
            set
            {
                _equipmentModelList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EquipmentModel"));
                }
            }
        }
        #endregion

        #region 雷达数据属性
        /// <summary>
        /// 雷达
        /// </summary>
        private List<RadarModel> _RadarList;

        /// <summary>
        /// 雷达
        /// </summary>
        public List<RadarModel> RadarList
        {
            get { return _RadarList; }
            set
            {
                _RadarList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
                }
            }
        }

        #endregion

        #region 人力数据属性
        private List<VacancyModel> _vacancyList;
        public List<VacancyModel> VacancyList
        {
            get { return _vacancyList; }
            set
            {
                _vacancyList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VacancyList"));
                }
            }
        }
        #endregion

        #region 车间详情属性
        private List<WorkShopModel> _workShopList;
        public List<WorkShopModel> WorkShopList
        {
            get { return _workShopList; }
            set
            {
                _workShopList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(" WorkShopList"));
                }
            }
        }
        #endregion

        #region 机台数据属性
        private List<MachineDetailsModel> _machineDetailsList;
        public List<MachineDetailsModel> MachineDetailsList
        {
            get { return _machineDetailsList; }
            set
            {
                _machineDetailsList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineDetailsList"));
                }
            }
        }
        #endregion
    }
}

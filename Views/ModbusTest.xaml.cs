using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductMonitor.Views
{
    /// <summary>
    /// ModbusTest.xaml 的交互逻辑
    /// </summary>
    public partial class ModbusTest : Window
    {
        public ModbusTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成校验码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="poly"></param>
        /// <param name="crcInit"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private List<byte> CRC16(List<byte> value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            if (value == null || !value.Any())
            {
                throw new ArgumentException("");
            }

            //运算
            ushort crc = crcInit;
            for (int i = 0; i < value.Count; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }

            byte hi = (byte)((crc & 0xFF00) >> 8);//高位置
            byte lo = (byte)(crc & 0x00FF);//低位置

            List<byte> buffer = new List<byte>();
            buffer.AddRange(value);
            buffer.Add(lo);
            buffer.Add(hi);

            return buffer;
        }

        /// <summary>
        /// 读取线圈：功能码01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnReadCoilStatus(object sender, RoutedEventArgs e)
        {
            #region 自己组装报文
            ushort startCoilAddress = 0;    //线圈起始地址
            ushort coilsNumber = 8;     //读取线圈长度
            //List<byte> command = new List<byte>();
            //command.Add(0x01);      //从机地址
            //command.Add(0x01);      //功能码
            //command.Add(BitConverter.GetBytes(startCoilAddress)[1]);    //起始地址高八位
            //command.Add(BitConverter.GetBytes(startCoilAddress)[0]);    //起始地址低八位
            //command.Add(BitConverter.GetBytes(coilsNumber)[1]);     //线圈数量高八位
            //command.Add(BitConverter.GetBytes(coilsNumber)[0]);     //线圈数量低八位
            //command = CRC16(command);   //添加校验码

            //SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

            //serialPort.Open();      //打开串口
            //serialPort.Write(command.ToArray(), 0, command.Count);
            //Task.Run(async () =>
            //{
            //    await Task.Delay(100);      //增加延时，以获取完整包
            //    byte[] receiveBytes = new byte[serialPort.BytesToRead];
            //    serialPort.Read(receiveBytes, 0, receiveBytes.Length);      //读取返回的响应报文，容易丢包，可使用多线程解决

            //    List<byte> receiveBytesList = new List<byte>(receiveBytes);
            //    receiveBytesList.RemoveRange(0, 3);     //移除前三个字节：地址、功能码、字节数
            //    receiveBytesList.RemoveRange(receiveBytesList.Count - 2, 2);        //移除校验码
            //    receiveBytesList.Reverse();

            //    var respStrList = receiveBytesList.Select(m => Convert.ToString(m, 2)).ToList();
            //    var result = "";
            //    foreach (string item in respStrList)
            //    {
            //        result += item.PadLeft(8, '0');
            //    }

            //    //字符串反转
            //    result = new string(result.ToArray().Reverse<char>().ToArray());
            //    result = result.Length > coilsNumber ? result.Substring(0, coilsNumber) : result;

            //    MessageBox.Show(result);
            //});
            #endregion

            #region 使用第三方库(NModbus)
            using (SerialPort port_01 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One))
            {
                port_01.Open();
                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port_01);
                bool[] result = master.ReadCoils(1, startCoilAddress, coilsNumber);
                MessageBox.Show(string.Join(",", result));
            }
            #endregion
        }

        public void BtnReadHoldRegiter(object sender, RoutedEventArgs e)
        {
            #region 自己组装报文
            ushort startAddrss = 0;
            ushort regiterNumber = 10;
            //List<byte> command = new List<byte>();
            //command.Add(0x01);
            //command.Add(0x03);
            //command.Add(BitConverter.GetBytes(startAdrss)[1]);
            //command.Add(BitConverter.GetBytes(startAdrss)[0]);
            //command.Add(BitConverter.GetBytes(regiterNumber)[1]);
            //command.Add(BitConverter.GetBytes(regiterNumber)[0]);
            //command = CRC16(command);

            //SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            //Task.Run(async () =>
            //{
            //    serialPort.Open();
            //    serialPort.Write(command.ToArray(), 0, command.Count);
            //    await Task.Delay(100);
            //    byte[] buffer = new byte[serialPort.BytesToRead];
            //    serialPort.Read(buffer, 0, buffer.Length);
            //    List<byte> receiveList = new List<byte>(buffer);
            //    receiveList.RemoveRange(0, 3);
            //    receiveList.RemoveRange(receiveList.Count - 2, 2);

            //    //单精度
            //    byte[] bytes = new byte[2];
            //    int[] result = new int[regiterNumber];
            //    for (int i = 0; i < regiterNumber; i++)
            //    {
            //        bytes[0] = receiveList[i * 2 + 1];
            //        bytes[1] = receiveList[i * 2];
            //        result[i] = BitConverter.ToInt16(bytes);
            //    }
            //    MessageBox.Show(string.Join(",", result));

            //    //float
            //    //    byte[] data = new byte[4];
            //    //    for (int i = 0; i < readLen / 2; i++)
            //    //    {
            //    //        data[0] = respList[i * 4 + 3];
            //    //        data[1] = respList[i * 4 + 2];
            //    //        data[2] = respList[i * 4 + 1];
            //    //        data[3] = respList[i * 4];

            //    //        //根据两个字节转成实际数字
            //    //        var result = BitConverter.ToSingle(data);
            //});
            #endregion

            #region 使用第三方库
            using (SerialPort serialPort=new SerialPort("COM1",9600,Parity.None,8,StopBits.One)) 
            { 
                serialPort.Open();
                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                ushort[] result = master.ReadHoldingRegisters(1,startAddrss,regiterNumber);
                MessageBox.Show(string.Join (",", result));
            }
            #endregion
        }
    }
}

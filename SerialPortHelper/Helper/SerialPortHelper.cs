using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialPortHelper.Helper
{
    /// <summary>
    /// 串口助手通用类
    /// </summary>
    public class SerialPortHelper
    {
        #region 相关属性

        private SerialPort serialPort=null;
        /// <summary>
        /// 创建一个串口操作对象
        /// </summary>
        public SerialPort SerialPort
        {
            get { return serialPort; }
        }

        /// <summary>
        /// 获取计算机上可用的串口列表
        /// </summary>
        public string[] PortNames
        {
            get { return SerialPort.GetPortNames(); }
        }

        private AlgorithmHelper algorithmHelper = null;
        /// <summary>
        /// 进制转换对象
        /// </summary>
        public AlgorithmHelper AlgorithmHelper
        {
            get { return algorithmHelper; }
        }


        #endregion

        /// <summary>
        /// 构造方法中初始化相关数据
        /// </summary>
        public SerialPortHelper()
        {
            this.serialPort = new SerialPort();
            this.algorithmHelper = new AlgorithmHelper();

            //串口基本参数初始化
            this.serialPort.BaudRate = 9600;        //波特率默认为9600
            this.serialPort.Parity = Parity.None;   //校验位默认为None
            this.serialPort.DataBits = 8;           //数据位默认为8位
            this.serialPort.StopBits = StopBits.One;//停止位默认为1位
        }


        #region 打开或关闭串口
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="status">操作状态：1打开、 0关闭</param>
        /// <returns>返回当前串口打开的状态True或False</returns>
        public bool OpenSerialPort(string portName, int status)
        {
            if (status == 1)
            {
                this.serialPort.PortName = portName;//只有串口没打开的时候才能设置名称
                this.serialPort.Open();
            }
            else
            {
                this.serialPort.Close();
            }

            return this.serialPort.IsOpen;//返回串口的打开状态
        }
        #endregion

        #region 发送数据
        
        /// <summary>
        /// 发送数据（16进制或字符串)
        /// </summary>
        /// <param name="data">要发送的数据</param>
        /// <param name="format">发送的格式</param>
        public void SendData(string data, SendFormat format)
        {
            if (this.serialPort.IsOpen == false)
            {
                throw new Exception("请打开相关串口！");
            }
            else
            {
                byte[] byteData;
                if (format == SendFormat.Hex)//如果是16进制
                {
                    if (IsIllegalHex(data))
                    {
                        byteData = algorithmHelper.From16ToBytes(data);//将16进制字符串转换成byte[]数组
                    }
                    else
                    {
                        throw new Exception("数据不是16进制格式！");
                    }
                }
                else
                {
                    byteData = algorithmHelper.StringToBytes(data,false);
                }
                //发送数据 （数据， 从0开始，结束位置）
                this.serialPort.Write(byteData, 0, byteData.Length);
            }
        } 

        /// <summary>
        /// 判断是否为非法16进制字符串
        /// </summary>
        /// <param name="hex">16进制字符串</param>
        /// <returns>true:正确 false:错误</returns>
        private bool IsIllegalHex(string hex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(hex, @"([^A-Fa-f0-9]|\S+?)+");
        }

        #endregion

        #region 串口接收数据

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] ReceiveData()
        {
            //定义一个接收数组，获取接收缓冲区数据的字节数
            byte[] byteData = new byte[this.serialPort.BytesToRead];

            //读取数据
            this.serialPort.Read(byteData, 0, serialPort.BytesToRead);
            return byteData;
        } 
        #endregion

    }

    /// <summary>
    /// 发生格式选择
    /// </summary>
    public enum SendFormat
    {
        Hex,//16进制
        String
    }
}
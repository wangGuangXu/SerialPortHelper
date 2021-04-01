using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace SerialPortHelper
{
    /// <summary>
    /// 串口相关文档：https://blog.csdn.net/p1279030826/article/details/86599435
    /// Modbus官网：https://www.modbustools.com/download.html
    /// Modbus测试工具ModbusPoll与Modbus Slave使用方法: https://blog.csdn.net/byxdaz/article/details/77979114
    /// modbus slave和modbus poll使用说明: https://blog.csdn.net/hanhui22/article/details/108344006?utm_medium=distribute.pc_relevant_download.none-task-blog-baidujs-1.nonecase&depth_1-utm_source=distribute.pc_relevant_download.none-task-blog-baidujs-1.nonecase
    /// </summary>
    public partial class Form1 : Form
    {
        //创建串口操作助手对象
        private SerialPortHelper.Helper.SerialPortHelper serialPortHelper = new SerialPortHelper.Helper.SerialPortHelper();

        #region 构造函数
        public Form1()
        {
            InitializeComponent();

            //串口基本操作初始化
            this.cboBaudRate.SelectedIndex = 5;//波特率默认为9600
            this.cboCheckBit.SelectedIndex = 0;//校验位默认为NONE
            this.cboDataBits.SelectedIndex = 2;//数据位默认为8
            this.cboStopBit.SelectedIndex = 0;//停止位默认为1

            //获取计算机的串口
            if (this.serialPortHelper.PortNames.Length == 0)
            {
                MessageBox.Show("当前计算机没有可用的端口");
                this.btnOpenPort.Enabled = false;//禁用打开串口按钮
            }
            else
            {
                //将串口添加到串口下拉框列表
                this.cboComList.Items.AddRange(this.serialPortHelper.PortNames);
                this.cboComList.SelectedIndex = 0;
            }
            //串口对象委托和串口接收数据关联
            this.serialPortHelper.SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived);
        } 
        #endregion

        #region 串口设置

        //波特率设置
        private void cboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPortHelper.SerialPort.BaudRate = Convert.ToInt32(this.cboBaudRate.Text);
        }

        //设置奇偶校验
        private void cboCheckBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCheckBit.Text == "EVEN")
            {
                this.serialPortHelper.SerialPort.Parity = Parity.Even;
            }
            else if (cboCheckBit.Text == "ODD")
            {
                this.serialPortHelper.SerialPort.Parity = Parity.Odd;
            }
            else if (cboCheckBit.Text == "NONE")
            {
                this.serialPortHelper.SerialPort.Parity = Parity.None;
            }

        }

        //数据位
        private void cboDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPortHelper.SerialPort.DataBits = Convert.ToInt32(cboDataBits.Text);
        }

        //停止位
        private void cboStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStopBit.Text=="1")
            {
                this.serialPortHelper.SerialPort.StopBits = StopBits.One;
            }
            else if (cboStopBit.Text=="2")
            {
                this.serialPortHelper.SerialPort.StopBits = StopBits.Two;
            }
        }

        #endregion

        #region 打开与关闭串口
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnOpenPort.Text == "打开串口")
                {
                    this.serialPortHelper.OpenSerialPort(this.cboComList.Text.Trim(), 1);
                    lblSerialPortStatus.Text = "串口已打开";
                    lblSerialPortStatusShow.BackColor = Color.Green;
                    btnOpenPort.Text = "关闭串口";
                }
                else
                {
                    this.serialPortHelper.OpenSerialPort(this.cboComList.Text.Trim(), 0);
                    lblSerialPortStatus.Text = "串口未打开";
                    lblSerialPortStatusShow.BackColor = Color.Red;
                    btnOpenPort.Text = "打开串口";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("端口操作异常：" + ex.Message);
            }
        }

        #endregion

        #region 发送数据
        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (this.txtSender.Text.Trim().Length < 1)
            {
                MessageBox.Show("发送内容不能为空", "提示信息");
                return;
            }

            //开始发送
            if (SendData(txtSender.Text.Trim()))
            {
                txtSender.Clear();
            }
        } 
        private bool SendData(string data)
        {
            try
            {
                if (cb16Send.Checked)
                {
                    this.serialPortHelper.SendData(data, Helper.SendFormat.Hex);//发送16进制数
                }
                else
                {
                    this.serialPortHelper.SendData(data, Helper.SendFormat.String);//发送字符串
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送数据错误"+ex.Message, "错误提示");
                return false;
            }
            return true;
        }


        #endregion

        #region 接收数据

        //串口接收数据
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReceiveData(this.serialPortHelper.ReceiveData());
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口接收数据出现异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="bytes"></param>
        private void ReceiveData(byte[] bytes)
        {
            string data = string.Empty;

            this.serialPortHelper.SerialPort.NewLine = " ";
            
            if (cb16Recive.Checked)
            {
                //16进制接收
                data = this.serialPortHelper.AlgorithmHelper.BytesTo16(bytes, Helper.EnumHex.Blank);
            }
            else
            {
                data = this.serialPortHelper.AlgorithmHelper.BytesToString(bytes, Helper.EnumHex.None);
            }

            //显示到文本框中,因为接收数据是一个独立线程，所有必须通过跨线程访问可视化控件来完成展示
            this.txtReciver.BeginInvoke(new Action<string>(s =>
            {
                this.txtReciver.Text += " " + s;
            }), data);

            //屏蔽跨线程访问可视化控件引发的异常，不建议使用
            //Control.CheckForIllegalCrossThreadCalls=false
        }

        #endregion

        #region 清空数据
        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtReciver.Clear();
            txtSender.Clear();
        }
        #endregion

        private void cboComList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
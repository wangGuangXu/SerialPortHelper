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
    public partial class Form1 : Form
    {
        //创建串口操作助手对象
        private SerialPortHelper.Helper.SerialPortHelper serialPortHelper = new SerialPortHelper.Helper.SerialPortHelper();

        public Form1()
        {
            InitializeComponent();

            //串口基本操作初始化
            this.cboBaudRate.SelectedIndex = 5;//波特率默认为9600
            this.cboCheckBit.SelectedIndex = 0;//校验位默认为NONE
            this.cboDataBits.SelectedIndex = 2;//数据位默认为8
            this.cboStopBit.SelectedIndex = 0;//停止位默认为1

            //获取计算机的串口
            if (this.serialPortHelper.PortNames.Length==0)
            {
                MessageBox.Show("当前计算机没有可用的端口","警告信息");
                this.btnOpen.Enabled = false;//禁用打开串口按钮
            }
            else
            {
                //将串口添加到串口下拉框列表
                this.cboComList.Items.AddRange(this.serialPortHelper.PortNames);
                this.cboComList.SelectedIndex = 0;
            }
        }

    }
}
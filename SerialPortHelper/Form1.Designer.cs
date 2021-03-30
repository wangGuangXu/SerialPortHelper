
namespace SerialPortHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStopBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCheckBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboComList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReciver = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.cb16Send = new System.Windows.Forms.CheckBox();
            this.cb16Recive = new System.Windows.Forms.CheckBox();
            this.lblSerialPortStatusShow = new System.Windows.Forms.Label();
            this.lblSerialPortStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboStopBit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboDataBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCheckBit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboComList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // cboStopBit
            // 
            this.cboStopBit.FormattingEnabled = true;
            this.cboStopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboStopBit.Location = new System.Drawing.Point(88, 146);
            this.cboStopBit.Name = "cboStopBit";
            this.cboStopBit.Size = new System.Drawing.Size(121, 20);
            this.cboStopBit.TabIndex = 9;
            this.cboStopBit.SelectedIndexChanged += new System.EventHandler(this.cboStopBit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "停止位";
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(88, 116);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 20);
            this.cboDataBits.TabIndex = 7;
            this.cboDataBits.SelectedIndexChanged += new System.EventHandler(this.cboDataBits_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据位";
            // 
            // cboCheckBit
            // 
            this.cboCheckBit.FormattingEnabled = true;
            this.cboCheckBit.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.cboCheckBit.Location = new System.Drawing.Point(88, 84);
            this.cboCheckBit.Name = "cboCheckBit";
            this.cboCheckBit.Size = new System.Drawing.Size(121, 20);
            this.cboCheckBit.TabIndex = 5;
            this.cboCheckBit.SelectedIndexChanged += new System.EventHandler(this.cboCheckBit_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "校验位";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.cboBaudRate.Location = new System.Drawing.Point(88, 55);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 20);
            this.cboBaudRate.TabIndex = 3;
            this.cboBaudRate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // cboComList
            // 
            this.cboComList.BackColor = System.Drawing.SystemColors.Window;
            this.cboComList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComList.FormattingEnabled = true;
            this.cboComList.Location = new System.Drawing.Point(88, 26);
            this.cboComList.Name = "cboComList";
            this.cboComList.Size = new System.Drawing.Size(121, 20);
            this.cboComList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReciver);
            this.groupBox2.Location = new System.Drawing.Point(263, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // txtReciver
            // 
            this.txtReciver.Location = new System.Drawing.Point(25, 18);
            this.txtReciver.Multiline = true;
            this.txtReciver.Name = "txtReciver";
            this.txtReciver.Size = new System.Drawing.Size(416, 75);
            this.txtReciver.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSender);
            this.groupBox3.Location = new System.Drawing.Point(265, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据【可以是中文字符串】";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(25, 17);
            this.txtSender.Multiline = true;
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(415, 39);
            this.txtSender.TabIndex = 0;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(158, 219);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(95, 40);
            this.btnOpenPort.TabIndex = 3;
            this.btnOpenPort.Text = "打开串口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(265, 217);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(95, 40);
            this.btnSendData.TabIndex = 4;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(378, 219);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(95, 40);
            this.btnClearData.TabIndex = 5;
            this.btnClearData.Text = "清空数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            // 
            // cb16Send
            // 
            this.cb16Send.AutoSize = true;
            this.cb16Send.Location = new System.Drawing.Point(511, 224);
            this.cb16Send.Name = "cb16Send";
            this.cb16Send.Size = new System.Drawing.Size(204, 16);
            this.cb16Send.TabIndex = 6;
            this.cb16Send.Text = "十六进制发送【发送前需要校验】";
            this.cb16Send.UseVisualStyleBackColor = true;
            // 
            // cb16Recive
            // 
            this.cb16Recive.AutoSize = true;
            this.cb16Recive.Location = new System.Drawing.Point(511, 243);
            this.cb16Recive.Name = "cb16Recive";
            this.cb16Recive.Size = new System.Drawing.Size(204, 16);
            this.cb16Recive.TabIndex = 7;
            this.cb16Recive.Text = "十六进制接收【接收后直接转换】";
            this.cb16Recive.UseVisualStyleBackColor = true;
            // 
            // lblSerialPortStatusShow
            // 
            this.lblSerialPortStatusShow.BackColor = System.Drawing.Color.Red;
            this.lblSerialPortStatusShow.Location = new System.Drawing.Point(24, 233);
            this.lblSerialPortStatusShow.Name = "lblSerialPortStatusShow";
            this.lblSerialPortStatusShow.Size = new System.Drawing.Size(20, 20);
            this.lblSerialPortStatusShow.TabIndex = 8;
            this.lblSerialPortStatusShow.Text = "    ";
            // 
            // lblSerialPortStatus
            // 
            this.lblSerialPortStatus.AutoSize = true;
            this.lblSerialPortStatus.Location = new System.Drawing.Point(50, 236);
            this.lblSerialPortStatus.Name = "lblSerialPortStatus";
            this.lblSerialPortStatus.Size = new System.Drawing.Size(65, 12);
            this.lblSerialPortStatus.TabIndex = 9;
            this.lblSerialPortStatus.Text = "串口未打开";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 277);
            this.Controls.Add(this.lblSerialPortStatus);
            this.Controls.Add(this.lblSerialPortStatusShow);
            this.Controls.Add(this.cb16Recive);
            this.Controls.Add(this.cb16Send);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口调试助手";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboComList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStopBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCheckBit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReciver;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.CheckBox cb16Send;
        private System.Windows.Forms.CheckBox cb16Recive;
        private System.Windows.Forms.Label lblSerialPortStatusShow;
        private System.Windows.Forms.Label lblSerialPortStatus;
    }
}


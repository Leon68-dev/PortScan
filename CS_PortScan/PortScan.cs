using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;


namespace portscan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PortScan : System.Windows.Forms.Form
	{
        public Thread thr1;
        public Thread thr2;
        public string m_hostName = null;
        private System.Windows.Forms.TrackBar trckTimeOut;
		private System.Windows.Forms.ProgressBar prsScan;
		private System.Windows.Forms.ListBox lstRezScan;
		private System.Windows.Forms.TextBox txtPortEnd;
		private System.Windows.Forms.TextBox txtPortBeg;
		private System.Windows.Forms.Label lblPorts;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.Button btnScanStop;
		private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtScanHost;
        private System.Windows.Forms.Label lblScanPort;
        private Label lblTimeOut;
        private GroupBox groupBox1;
        private IContainer components;
        private string host = string.Empty;
        
        public PortScan()
		{
			InitializeComponent();
			
            this.setBtnRun(true);
            this.trckTimeOut_ValueChanged(null, null);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.prsScan = new System.Windows.Forms.ProgressBar();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trckTimeOut = new System.Windows.Forms.TrackBar();
            this.btnScanStop = new System.Windows.Forms.Button();
            this.lstRezScan = new System.Windows.Forms.ListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtPortEnd = new System.Windows.Forms.TextBox();
            this.txtPortBeg = new System.Windows.Forms.TextBox();
            this.txtScanHost = new System.Windows.Forms.TextBox();
            this.lblPorts = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblScanPort = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // prsScan
            // 
            this.prsScan.Location = new System.Drawing.Point(5, 338);
            this.prsScan.Name = "prsScan";
            this.prsScan.Size = new System.Drawing.Size(590, 22);
            this.prsScan.Step = 1;
            this.prsScan.TabIndex = 21;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTimeOut.Location = new System.Drawing.Point(483, 60);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(109, 16);
            this.lblTimeOut.TabIndex = 24;
            this.lblTimeOut.Text = "Timeout (msec) : ";
            this.lblTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trckTimeOut);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(538, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(57, 233);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // trckTimeOut
            // 
            this.trckTimeOut.AllowDrop = true;
            this.trckTimeOut.BackColor = System.Drawing.SystemColors.Control;
            this.trckTimeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trckTimeOut.LargeChange = 25;
            this.trckTimeOut.Location = new System.Drawing.Point(3, 18);
            this.trckTimeOut.Maximum = 2000;
            this.trckTimeOut.Minimum = 25;
            this.trckTimeOut.Name = "trckTimeOut";
            this.trckTimeOut.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trckTimeOut.Size = new System.Drawing.Size(51, 212);
            this.trckTimeOut.SmallChange = 5;
            this.trckTimeOut.TabIndex = 10;
            this.trckTimeOut.TickFrequency = 250;
            this.trckTimeOut.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trckTimeOut.Value = 25;
            this.trckTimeOut.ValueChanged += new System.EventHandler(this.trckTimeOut_ValueChanged);
            // 
            // btnScanStop
            // 
            this.btnScanStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScanStop.Location = new System.Drawing.Point(350, 40);
            this.btnScanStop.Name = "btnScanStop";
            this.btnScanStop.Size = new System.Drawing.Size(90, 27);
            this.btnScanStop.TabIndex = 20;
            this.btnScanStop.Text = "Стоп";
            this.btnScanStop.Click += new System.EventHandler(this.btnScanStop_Click);
            // 
            // lstRezScan
            // 
            this.lstRezScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstRezScan.ItemHeight = 17;
            this.lstRezScan.Location = new System.Drawing.Point(5, 87);
            this.lstRezScan.Name = "lstRezScan";
            this.lstRezScan.Size = new System.Drawing.Size(528, 225);
            this.lstRezScan.TabIndex = 19;
            // 
            // btnScan
            // 
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScan.Location = new System.Drawing.Point(250, 40);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(90, 27);
            this.btnScan.TabIndex = 18;
            this.btnScan.Text = "Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtPortEnd
            // 
            this.txtPortEnd.Location = new System.Drawing.Point(158, 41);
            this.txtPortEnd.Name = "txtPortEnd";
            this.txtPortEnd.Size = new System.Drawing.Size(77, 22);
            this.txtPortEnd.TabIndex = 17;
            this.txtPortEnd.Text = "512";
            // 
            // txtPortBeg
            // 
            this.txtPortBeg.Location = new System.Drawing.Point(62, 41);
            this.txtPortBeg.Name = "txtPortBeg";
            this.txtPortBeg.Size = new System.Drawing.Size(58, 22);
            this.txtPortBeg.TabIndex = 16;
            this.txtPortBeg.Text = "1";
            // 
            // txtScanHost
            // 
            this.txtScanHost.Location = new System.Drawing.Point(62, 10);
            this.txtScanHost.Name = "txtScanHost";
            this.txtScanHost.Size = new System.Drawing.Size(533, 22);
            this.txtScanHost.TabIndex = 14;
            this.txtScanHost.Text = "127.0.0.1";
            // 
            // lblPorts
            // 
            this.lblPorts.BackColor = System.Drawing.SystemColors.Control;
            this.lblPorts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPorts.Location = new System.Drawing.Point(5, 46);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(158, 18);
            this.lblPorts.TabIndex = 15;
            this.lblPorts.Text = "Порты с                        по";
            // 
            // lblHost
            // 
            this.lblHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHost.Location = new System.Drawing.Point(10, 15);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(33, 18);
            this.lblHost.TabIndex = 13;
            this.lblHost.Text = "Хост";
            // 
            // lblScanPort
            // 
            this.lblScanPort.AutoSize = true;
            this.lblScanPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblScanPort.Location = new System.Drawing.Point(5, 317);
            this.lblScanPort.Name = "lblScanPort";
            this.lblScanPort.Size = new System.Drawing.Size(13, 16);
            this.lblScanPort.TabIndex = 23;
            this.lblScanPort.Text = "  ";
            this.lblScanPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortScan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(604, 375);
            this.Controls.Add(this.prsScan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.txtScanHost);
            this.Controls.Add(this.lblScanPort);
            this.Controls.Add(this.btnScanStop);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lstRezScan);
            this.Controls.Add(this.txtPortBeg);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.txtPortEnd);
            this.Controls.Add(this.lblPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PortScan";
            this.Text = "Сетевые инструменты";
            this.Closed += new System.EventHandler(this.FMain_Closed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckTimeOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new PortScan());
		}

		private void FMain_Closed(object sender, System.EventArgs e)
		{
			FMainClosed();
		}
        
		private void FMainClosed()
		{
			if(closeThread)
			{
				try
				{
					thr2.Abort(); 
					setBtnRun(true);
					setCtrlRun(false);
				}
				catch{}

				try
				{
					thr1.Abort(); 
					setBtnRun(true);
					setCtrlRun(false);
				}
				catch{}
			}


		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////
		//Функции сканирования портов
		///////////////////////////////////////////////////////////////////////////////////////////////////////////
		#region scan

        private bool closeThread = false;
		private int curPort = 0;
        
		private void btnScan_Click(object sender, System.EventArgs e)
		{
            thr1 = new Thread(new ThreadStart(scanPorts));
            thr1.Start();
            closeThread = true;
        }

        private void btnScanStop_Click(object sender, System.EventArgs e)
		{
			if(!this.btnScan.Enabled)
			{
				FMainClosed();
				this.lstRezScan.Items.Add("Сканирование прервано пользователем!");
				this.lstRezScan.Refresh();
				setCtrlRun(false);
				
				blockCtrl(true);
				setBtnRun(true);
				
				closeThread = false;
			}
		}
        
        private void scanPorts()
        {
            setCtrlRun(false);

            if (this.txtScanHost.Text.Length == 0)
            {
                MessageBox.Show("Ошибка ввода хоста!");
                this.txtScanHost.Focus();
                return;
            }

            host = hostName();

            if (this.txtPortBeg.Text.Length == 0)
            {
                MessageBox.Show("Ошибка ввода стартового порта!");
                this.txtPortBeg.Focus();
                return;
            }

            if (this.txtPortEnd.Text.Length == 0)
            {
                this.txtPortEnd.Text = this.txtPortBeg.Text;
            }

            int pBeg = int.Parse(this.txtPortBeg.Text);
            int pEnd = int.Parse(this.txtPortEnd.Text);
            int timeOut = getTrckTimeOutMethod();

            this.clearLstRezScanMethod();
            this.addLstRezScanMethod("Сканирование...");
            this.refLstRezScanMethod();

            setBtnRun(false);
            blockCtrl(false);

            //setLblScanPortMethod("Подключение к " + this.m_hostName + " порт 23(Telnet)");
            //curPort = 23;
            //makeScan();
            Application.DoEvents();

            //setLblScanPortMethod("Подключение к " + this.m_hostName + " для сканирования");            
            
            //FScan.socketOpen(currHostName, 21);//FTP
            //FScan.socketOpen(currHostName, 23);//Telnet
            //FScan.socketOpen(currHostName, 25);//SMTP
            //FScan.socketOpen(currHostName, 53);//Named
            //FScan.socketOpen(currHostName, 79);//FingerD
            //FScan.socketOpen(currHostName, 80);//HTTPD
            //FScan.socketOpen(currHostName, 110);//POP3
            //FScan.socketOpen(currHostName, 139);//Win32 Open Sharing
            //FScan.socketOpen(currHostName, 143);//IMAPD
            //FScan.socketOpen(currHostName, 12345);//NetBus
            //FScan.socketOpen(currHostName, 31337);//Back Orifice

            double step = (double)100 / (pEnd - pBeg + 1);
            double stepClc = 0;

            Thread.Sleep(1000);

            for (int i = pBeg; i <= pEnd; i++)
            {
                curPort = i;
                thr2 = new Thread(new ThreadStart(makeScan));
                thr2.Start();
                Application.DoEvents();
                Thread.Sleep(timeOut);
                stepClc += step;
                setPrsScanMethod((int)stepClc);
            }

            addLstRezScanMethod("Сканирование завершено!");
            refLstRezScanMethod();

            setBtnRun(true);
            blockCtrl(true);
            setCtrlRun(false);
        }
		
		private void blockCtrl(bool val)
		{
			//this.txtScanHost.Enabled = val; 
            setTxtScanHostMethod(val);
			//this.txtPortBeg.Enabled = val;
            setTxtPortBegMethod(val);
			//this.txtPortEnd.Enabled = val; 
            setTxtPortEndEnabled(val);
		}
        
		private void setBtnRun(bool val)
		{
			if(val)
			{
                //this.btnScan.Enabled = true;
                setBtnScanEnable(true);
                //this.btnScanStop.Enabled = false;
                setBtnScanStopEnabled(false);

                setTrckTimeOutEnabled(true);
			}
			else
			{
                //this.btnScan.Enabled = false;
                setBtnScanEnable(false);
				//this.btnScanStop.Enabled = true;
                setBtnScanStopEnabled(true);

                setTrckTimeOutEnabled(false);
			}

			//this.trckTimeOut.Enabled = this.btnScan.Enabled;
		}
        
		private void setCtrlRun(bool val)
		{
			if(!val)
			{
                setTextLblScanPort("");
                setPrsScanMethod(0);
			}
		}
        
        delegate void setTrckTimeOut(bool val);
        private void setTrckTimeOutEnabled(bool val)
        {
            if (this.trckTimeOut.InvokeRequired)
            {
                setTrckTimeOut d = new setTrckTimeOut(setTrckTimeOutEnabled);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.trckTimeOut.Enabled = val;
            }
        }
        
        delegate void setBtnScan(bool val);
        private void setBtnScanEnable(bool val)
        {
            if (this.btnScan.InvokeRequired)
            {
                setBtnScan d = new setBtnScan(setBtnScanEnable);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.btnScan.Enabled = val;
            }
        }

        delegate void setBtnScanStop(bool val);
        private void setBtnScanStopEnabled(bool val)
        {
            if (this.btnScanStop.InvokeRequired)
            {
                setBtnScanStop d = new setBtnScanStop(setBtnScanStopEnabled);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.btnScanStop.Enabled = val;
            }
        }

        delegate void setText(string text);
        private void setTextLblScanPort(string text)
        {
            if (this.lblScanPort.InvokeRequired)
            {
                setText d = new setText(setTextLblScanPort);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblScanPort.Text = text;
            }
        }

        public delegate void clearLstRezScan();
        public void clearLstRezScanMethod()
        {
            if (this.lstRezScan.InvokeRequired)
            {
                clearLstRezScan d = new clearLstRezScan(clearLstRezScanMethod);
                this.Invoke(d);
            }
            else
            {
                lstRezScan.Items.Clear();
            }

        }

        public delegate void addLstRezScan(string val);
        public void addLstRezScanMethod(string val)
        {
            if (this.lstRezScan.InvokeRequired)
            {
                addLstRezScan d = new addLstRezScan(addLstRezScanMethod);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                lstRezScan.Items.Add(val);
            }
        }

        public delegate void refLstRezScan();
        public void refLstRezScanMethod()
        {
            if (this.lstRezScan.InvokeRequired)
            {
                refLstRezScan d = new refLstRezScan(refLstRezScanMethod);
                this.Invoke(d);
            }
            else
            {
                lstRezScan.Refresh();
            }
        }

        public delegate void setTxtScanHost(bool val);
        public void setTxtScanHostMethod(bool val)
        {
            if (this.txtScanHost.InvokeRequired)
            {
                setTxtScanHost d = new setTxtScanHost(setTxtScanHostMethod);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                txtScanHost.Enabled = val; 
            }
        }

        public delegate void setTxtPortBeg(bool val);
        public void setTxtPortBegMethod(bool val)
        {
            if (this.txtPortBeg.InvokeRequired)
            {
                setTxtPortBeg d = new setTxtPortBeg(setTxtPortBegMethod);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                txtPortBeg.Enabled = val;
            }
        }

        public delegate void setTxtPortEnd(bool val);
        public void setTxtPortEndEnabled(bool val)
        {
            if (this.txtPortEnd.InvokeRequired)
            {
                setTxtPortEnd d = new setTxtPortEnd(setTxtPortEndEnabled);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                txtPortEnd.Enabled = val;
            }
        }

        public delegate void setLblScanPort(string val);
        public void setLblScanPortMethod(string val)
        {
            if (this.lblScanPort.InvokeRequired)
            {
                setLblScanPort d = new setLblScanPort(setLblScanPortMethod);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                lblScanPort.Text = val;
            }
        }

        public delegate int getTrckTimeOut();
        public int getTrckTimeOutMethod()
        {
            if (this.trckTimeOut.InvokeRequired)
            {
                getTrckTimeOut d = new getTrckTimeOut(getTrckTimeOutMethod);
                return (Convert.ToInt32(this.Invoke(d)));
            }
            else
            {
                return (trckTimeOut.Value);
            }
        }

        public delegate void setPrsScan(int val);

        public void setPrsScanMethod(int val)
        {
            if (this.prsScan.InvokeRequired)
            {
                setPrsScan d = new setPrsScan(setPrsScanMethod);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                prsScan.Value = val;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //myDelegate = new AddListItem(AddListItemMethod);    //В конструкторе

        //public delegate void AddListItem(String myString);
        //public AddListItem myDelegate;

        //public void AddListItemMethod(String myString)
        //{
        //    lstRezScan.Items.Add(myString);
        //}

        //this.Invoke(myDelegate, new Object[] {myString});     //реализация в нужном месте обработки
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Сканирование 
        /// вызывается в отдельном потоке
        /// </summary>

        
        private void makeScan()
		{
            if (makeScan(host, curPort))
            {
                this.addLstRezScanMethod(string.Format("{0} порт открыт", curPort.ToString()));
            }
            setLblScanPortMethod(string.Format("порт {0}", curPort.ToString()));
        }

        private bool makeScan(
            string host,
            int port)
        {
            try
            {
                using (TcpClient connec = new TcpClient(host, port))
                {
                    connec.SendTimeout = 1000;
                    connec.ReceiveTimeout = 1000;
                    connec.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

		private void trckTimeOut_ValueChanged(object sender, System.EventArgs e)
		{
            this.lblTimeOut.Text = "Timeout (msec) : " + this.trckTimeOut.Value.ToString();
        }

        private string hostName()
        {
            return LAny.cSysScan.getHostName(this.txtScanHost.Text.ToLower()).ToLower();
        }

		#endregion scan

    }
}
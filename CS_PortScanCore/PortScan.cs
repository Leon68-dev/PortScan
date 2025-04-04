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
using System.Threading.Tasks;
using System.Diagnostics;


namespace portscan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PortScan : System.Windows.Forms.Form
	{
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
        private Label label1;
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
            prsScan = new ProgressBar();
            lblTimeOut = new Label();
            groupBox1 = new GroupBox();
            trckTimeOut = new TrackBar();
            btnScanStop = new Button();
            lstRezScan = new ListBox();
            btnScan = new Button();
            txtPortEnd = new TextBox();
            txtPortBeg = new TextBox();
            txtScanHost = new TextBox();
            lblPorts = new Label();
            lblHost = new Label();
            lblScanPort = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)trckTimeOut).BeginInit();
            SuspendLayout();
            // 
            // prsScan
            // 
            prsScan.Location = new Point(6, 415);
            prsScan.Name = "prsScan";
            prsScan.Size = new Size(688, 29);
            prsScan.Step = 1;
            prsScan.TabIndex = 21;
            // 
            // lblTimeOut
            // 
            lblTimeOut.AutoSize = true;
            lblTimeOut.FlatStyle = FlatStyle.System;
            lblTimeOut.Location = new Point(913, 55);
            lblTimeOut.Name = "lblTimeOut";
            lblTimeOut.Size = new Size(123, 20);
            lblTimeOut.TabIndex = 24;
            lblTimeOut.Text = "Timeout (msec) : ";
            lblTimeOut.TextAlign = ContentAlignment.MiddleRight;
            lblTimeOut.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(trckTimeOut);
            groupBox1.FlatStyle = FlatStyle.System;
            groupBox1.Location = new Point(963, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(66, 304);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // trckTimeOut
            // 
            trckTimeOut.AllowDrop = true;
            trckTimeOut.BackColor = SystemColors.Control;
            trckTimeOut.Dock = DockStyle.Fill;
            trckTimeOut.LargeChange = 25;
            trckTimeOut.Location = new Point(3, 23);
            trckTimeOut.Maximum = 2000;
            trckTimeOut.Minimum = 25;
            trckTimeOut.Name = "trckTimeOut";
            trckTimeOut.Orientation = Orientation.Vertical;
            trckTimeOut.Size = new Size(60, 278);
            trckTimeOut.SmallChange = 5;
            trckTimeOut.TabIndex = 10;
            trckTimeOut.TickFrequency = 250;
            trckTimeOut.TickStyle = TickStyle.Both;
            trckTimeOut.Value = 25;
            trckTimeOut.ValueChanged += trckTimeOut_ValueChanged;
            // 
            // btnScanStop
            // 
            btnScanStop.FlatStyle = FlatStyle.System;
            btnScanStop.Location = new Point(743, 53);
            btnScanStop.Name = "btnScanStop";
            btnScanStop.Size = new Size(105, 36);
            btnScanStop.TabIndex = 20;
            btnScanStop.Text = "Стоп";
            btnScanStop.Click += btnScanStop_Click;
            // 
            // lstRezScan
            // 
            lstRezScan.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lstRezScan.ItemHeight = 17;
            lstRezScan.Location = new Point(6, 96);
            lstRezScan.Name = "lstRezScan";
            lstRezScan.Size = new Size(685, 310);
            lstRezScan.TabIndex = 19;
            // 
            // btnScan
            // 
            btnScan.FlatStyle = FlatStyle.System;
            btnScan.Location = new Point(292, 53);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(105, 36);
            btnScan.TabIndex = 18;
            btnScan.Text = "Scan";
            btnScan.Click += btnScan_Click;
            // 
            // txtPortEnd
            // 
            txtPortEnd.Location = new Point(184, 55);
            txtPortEnd.Name = "txtPortEnd";
            txtPortEnd.Size = new Size(90, 27);
            txtPortEnd.TabIndex = 17;
            txtPortEnd.Text = "512";
            // 
            // txtPortBeg
            // 
            txtPortBeg.Location = new Point(72, 55);
            txtPortBeg.Name = "txtPortBeg";
            txtPortBeg.Size = new Size(68, 27);
            txtPortBeg.TabIndex = 16;
            txtPortBeg.Text = "1";
            // 
            // txtScanHost
            // 
            txtScanHost.Location = new Point(72, 13);
            txtScanHost.Name = "txtScanHost";
            txtScanHost.Size = new Size(622, 27);
            txtScanHost.TabIndex = 14;
            txtScanHost.Text = "127.0.0.1";
            // 
            // lblPorts
            // 
            lblPorts.BackColor = SystemColors.Control;
            lblPorts.FlatStyle = FlatStyle.System;
            lblPorts.Location = new Point(6, 61);
            lblPorts.Name = "lblPorts";
            lblPorts.Size = new Size(60, 24);
            lblPorts.TabIndex = 15;
            lblPorts.Text = "Порты с                        по";
            // 
            // lblHost
            // 
            lblHost.FlatStyle = FlatStyle.System;
            lblHost.Location = new Point(12, 20);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(38, 24);
            lblHost.TabIndex = 13;
            lblHost.Text = "Хост";
            // 
            // lblScanPort
            // 
            lblScanPort.AutoSize = true;
            lblScanPort.FlatStyle = FlatStyle.System;
            lblScanPort.Location = new Point(6, 423);
            lblScanPort.Name = "lblScanPort";
            lblScanPort.Size = new Size(17, 20);
            lblScanPort.TabIndex = 23;
            lblScanPort.Text = "  ";
            lblScanPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Control;
            label1.FlatStyle = FlatStyle.System;
            label1.Location = new Point(146, 61);
            label1.Name = "label1";
            label1.Size = new Size(29, 24);
            label1.TabIndex = 26;
            label1.Text = "по";
            // 
            // PortScan
            // 
            AutoScaleBaseSize = new Size(7, 20);
            ClientSize = new Size(699, 450);
            Controls.Add(label1);
            Controls.Add(prsScan);
            Controls.Add(groupBox1);
            Controls.Add(lblTimeOut);
            Controls.Add(txtScanHost);
            Controls.Add(lblScanPort);
            Controls.Add(btnScanStop);
            Controls.Add(lblHost);
            Controls.Add(lstRezScan);
            Controls.Add(txtPortBeg);
            Controls.Add(btnScan);
            Controls.Add(txtPortEnd);
            Controls.Add(lblPorts);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PortScan";
            Text = "Сетевые инструменты";
            Closed += FMain_Closed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)trckTimeOut).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
					setBtnRun(true);
					setCtrlRun(false);
				}
				catch{}

				try
				{
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
            _ = scanPortsAsync();
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
        
        private async Task scanPortsAsync()
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

            //for (int i = pBeg; i <= pEnd; i++)
            //{
            //    Thread.Sleep(timeOut);
            //    curPort = i;
            //    thr2 = new Thread(new ThreadStart(makeScan));
            //    thr2.IsBackground = true;
            //    thr2.Priority = ThreadPriority.Highest;
            //    thr2.Start();
            //    Application.DoEvents();
            //    stepClc += step;
            //    setPrsScanMethod((int)stepClc);
            //}

            var tasks = new Task[pEnd - pBeg + 1];
            int index = 0;

            SemaphoreSlim semaphore = new SemaphoreSlim(50);

            for (int port = pBeg; port <= pEnd; port++)
            {
                int currentPort = port;
                await semaphore.WaitAsync();

                tasks[index++] = Task.Run(async () =>
                {
                    try
                    {
                        await ScanPort(host, currentPort);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });

                stepClc += step;
                setPrsScanMethod((int)stepClc);
            }

            addLstRezScanMethod("Сканирование завершено!");
            refLstRezScanMethod();

            setBtnRun(true);
            blockCtrl(true);
            setCtrlRun(false);
        }

        private async Task ScanPort(string host, int port)
        {
            using (var client = new TcpClient())
            {
                try
                {
                    var connectTask = client.ConnectAsync(host, port);
                    var timeoutTask = Task.Delay(1000); // 1-second timeout
                    var completed = await Task.WhenAny(connectTask, timeoutTask);

                    if (completed == connectTask && client.Connected)
                    {
                        this.addLstRezScanMethod(string.Format("{0} порт открыт", port.ToString()));
                        Debug.WriteLine(string.Format("{0} порт открыт", port.ToString()));
                    }
                }
                catch
                {
                    // Ignore connection errors
                }
            }
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
            //if (this.lstRezScan.InvokeRequired)
            //{
            //    addLstRezScan d = new addLstRezScan(addLstRezScanMethod);
            //    this.Invoke(d, new object[] { val });
            //}
            //else
            //{
            //    lstRezScan.Items.Add(val);
            //}

            _ = Invoke(() => lstRezScan.Items.Add(val));
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
            try
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
            catch { }

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
            //setLblScanPortMethod(string.Format("порт {0}", curPort.ToString()));

            Debug.WriteLine(string.Format("порт {0}", curPort.ToString()));
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
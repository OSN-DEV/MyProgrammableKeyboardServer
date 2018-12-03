using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyProgamableKeyboardServer {
    public partial class Main : Form {

        #region Declaration
        private KeyRequestWatcher _requestWather;
        private SendKeys _sendKeys;
        #endregion

        #region Constructor
        public Main() {
            InitializeComponent();
        }
        #endregion

        #region Form Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e) {
            this._requestWather = new KeyRequestWatcher();
            this._requestWather.SendKeysEvent += this.RequestWatcher_SendKeyEvent;
            this._requestWather.ExceptionEvent += this.RequestWatcher_ExceptionEvent;
            this._sendKeys = new SendKeys();
            this.cUrl.Text = "";
            this.cPortNo.Text = Properties.Settings.Default.PortNo;
            this.ShowInTaskTray(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            this.cNotify.Visible = false;
            if (null != this._requestWather && this._requestWather.IsStart) {
                this._requestWather.Start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Activated(object sender, EventArgs e) {
            this.ReflectCurrentStatus();
        }
        #endregion

        #region Control Event
        /// <summary>
        /// start click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cStart_Click(object sender, EventArgs e) {
            if (this._requestWather.Start()) {
                this.ReflectCurrentStatus();
                this.cStop.Focus();
            }
        }

        /// <summary>
        /// stop click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cStop_Click(object sender, EventArgs e) {
            if (this._requestWather.Stop()) {
                this.ReflectCurrentStatus();
                this.cStart.Focus();
            }
        }

        /// <summary>
        /// apply click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cApply_Click(object sender, EventArgs e) {
            Properties.Settings.Default.PortNo = this.cPortNo.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// close click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cClose_Click(object sender, EventArgs e) {
            this.ShowInTaskTray(true);
        }

        /// <summary>
        /// show setting menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTasktrayMenuSetting_Click(object sender, EventArgs e) {
            this.ShowInTaskTray(false);
        }

        /// <summary>
        /// quit application click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTasktrayMenuExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTasktrayMenuStart_Click(object sender, EventArgs e) {
            this.cStart.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTasktrayMenuStop_Click(object sender, EventArgs e) {
            this.cStop.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTasktrayMenu_Opening(object sender, CancelEventArgs e) {
            this.cTasktrayMenuStart.Enabled = !this._requestWather.IsStart;
            this.cTasktrayMenuStop.Enabled = !this.cTasktrayMenuStart.Enabled;
        }
        #endregion

        #region Custom Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RequestWatcher_SendKeyEvent(object sender, KeyRequestWatcher.RequestWatcherEventArgs args) {
            this._sendKeys.Send(args.SendKeys[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RequestWatcher_ExceptionEvent(object sender, KeyRequestWatcher.RequestWatcherEventArgs args) {
            MessageBox.Show("exception occurred." + '\n' + args.ex.Message);
        }
        #endregion

        #region Private Method
        /// <summary>
        /// set task tray
        /// </summary>
        /// <param name="IsShow">true:show in task tray, false:otherwise</param>
        private void ShowInTaskTray(bool IsShow) {
            // the call order of ShowInTaskbar affect window anmation.
            if (IsShow) {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = !IsShow;
            } else {
                this.ShowInTaskbar = !IsShow;
                this.WindowState = FormWindowState.Normal;
            }
            this.cNotify.Visible = IsShow;
        }

        /// <summary>
        /// reflect current status to form
        /// </summary>
        private void ReflectCurrentStatus() {
            this.cUrl.Text = this._requestWather.DisplayUrl;
            this.cStart.Enabled = !this._requestWather.IsStart;
            this.cStop.Enabled = !this.cStart.Enabled;
        }
        #endregion

    }
}

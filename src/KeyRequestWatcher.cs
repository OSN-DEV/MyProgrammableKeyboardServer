using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace MyProgamableKeyboardServer {

    /// <summary>
    /// handling send key post request
    /// </summary>
    class KeyRequestWatcher {

        private readonly BackgroundWorker _worker = null;
        private HttpListener _listener = null;
        private bool _isCanceling = false;
        private string _url = "";

        private static class Const {
            public const string BaseUrl = "http://{0}:{1}/mpk/";
        }

        #region Event Declaration
        /// <summary>
        /// 
        /// </summary>
        public class RequestWatcherEventArgs : EventArgs {
            /// <summary>
            /// request key list
            /// </summary>
            public List<string> SendKeys { set; get; }

            /// <summary>
            /// exception object
            /// </summary>
            public Exception ex { set; get; }

            public RequestWatcherEventArgs() {

            }
            public RequestWatcherEventArgs(List<string> sendKeys) {
                this.SendKeys = sendKeys;
            }
            public RequestWatcherEventArgs(Exception ex) {
                this.ex = ex;
            }
        }

        /// <summary>
        /// call when receve request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void SendKeysEventHandler(object sender, RequestWatcherEventArgs args);
        public event SendKeysEventHandler SendKeysEvent;

        /// <summary>
        /// call when exception occurr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        public delegate void ExceptionHandler(object sender, RequestWatcherEventArgs args);
        public event ExceptionHandler ExceptionEvent;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public KeyRequestWatcher() {
            this._worker = new BackgroundWorker();
            this._worker.DoWork += DoWork;
            this._worker.RunWorkerCompleted += RunWorkerCompleted;
            this._worker.ProgressChanged += ProgressChanged;
            this._worker.WorkerReportsProgress = true;
            this._worker.WorkerSupportsCancellation = true;
            this.DisplayUrl ="";
        }
        #endregion


        #region BackgroundWorker Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(object sender, DoWorkEventArgs e) {
            try {
                this._listener = new HttpListener();
                this._listener.Prefixes.Add(this._url);

                TextReader reader = new StreamReader("RemoteControlPage.htm");
                byte[] htmlString = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());

                this._listener.Start();
                while (!this._worker.CancellationPending) {
                    HttpListenerContext context = this._listener.GetContext();
                    if ("post" == context.Request.HttpMethod.ToLower()) {
                        var body = new StreamReader(context.Request.InputStream).ReadToEnd();
                        this._worker.ReportProgress(1, this.GetValue(body));     // raise ProgressChanged event()
                    }
                    context.Response.ContentLength64 = htmlString.Length;
                    context.Response.OutputStream.Write(htmlString, 0, htmlString.Length);
                    context.Response.Close();
                }
            } catch(Exception ex) {
                if (this._isCanceling) {
                    // NOP
                } else {
                    this.RaiseExceptionEvent(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.DisplayUrl = "";
            this.IsStart = false;
            this._listener = null;
            this._isCanceling = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.RaiseSendKeysEvent((List<string>)e.UserState);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// start listen
        /// </summary>
        /// <returns>true:success, false:otherwise</returns>
        public bool Start() {
            bool result = false;
            try {
                string port = Properties.Settings.Default.PortNo;
                this._url = Const.BaseUrl.Replace("{1}", port);
                if ("80" == port) {
                    port = "";
                } else {
                    port = ":" + port;
                }

                IPAddress[] localIAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress address in localIAddresses) {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        this.DisplayUrl = this._url.Replace("{0}", address.ToString()) + "\n" +
                            "OR" + "\n" +
                            this._url.Replace("{0}", Dns.GetHostName());
                        this._url = this._url.Replace("{0}", "+");
                        break;
                    }
                }

                this._worker.RunWorkerAsync();
                this.IsStart = true;
                result = true;
            } catch (Exception ex) {
                this.RaiseExceptionEvent(ex);
            }
            return result;
        }

        /// <summary>
        /// stop listen
        /// </summary>
        /// <returns>true:success, false:otherwise</returns>
        public bool Stop() {
            bool result = false;

            try {
                this._worker.CancelAsync();
                this._isCanceling = true;
                if (null != this._listener) {
                    this._listener.Close();
                }

                this.IsStart = false;
                this.DisplayUrl = "";
                result = true;
            } catch (Exception ex) {
                this.RaiseExceptionEvent(ex);
            }
            return result;
        }
        #endregion

        #region Public Property
        public bool IsStart {
            private set;
            get;
        }

        public String DisplayUrl {
            private set;
            get;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// get request parameter from body
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private List<string> GetValue(string body) {
            List<string> result = new List<string>();
            string[] reqParams = body.Split('&');
            foreach (var reqParam in reqParams) {
                var keypair = reqParam.Split('=');
                if (2 == keypair.Length) {
                    result.Add(keypair[0]);
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// raise exception event
        /// </summary>
        /// <param name="ex"></param>
        private void RaiseExceptionEvent(Exception ex) {
            if (null != this.ExceptionEvent) {
                this.ExceptionEvent(this, new RequestWatcherEventArgs(ex));
            }
        }

        /// <summary>
        /// raise sendkeys event
        /// </summary>
        /// <param name="keys"></param>
        private void RaiseSendKeysEvent(List<string> keys) {
            if (null != this.SendKeysEvent && 0 < keys.Count) {
                this.SendKeysEvent(this, new RequestWatcherEventArgs(keys));
            }
        }
        #endregion

    }
}

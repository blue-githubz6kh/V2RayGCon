﻿using System;
using System.Windows.Forms;

namespace V2RayGCon.Views.WinForms
{
    public partial class FormLog : Form
    {
        #region Sigleton
        static readonly VgcApis.BaseClasses.AuxSiWinForm<FormLog> auxSiForm =
            new VgcApis.BaseClasses.AuxSiWinForm<FormLog>();
        static public FormLog GetForm() => auxSiForm.GetForm();
        static public void ShowForm() => auxSiForm.ShowForm();
        #endregion

        Services.Settings setting;

        VgcApis.UserControls.RepaintController repaintCtrl;
        long updateTimeStamp = DateTime.Now.Ticks;
        Timer updateLogTimer = new Timer { Interval = 500 };
        VgcApis.Libs.Tasks.Bar bar = new VgcApis.Libs.Tasks.Bar();

        public FormLog()
        {
            setting = Services.Settings.Instance;

            InitializeComponent();

            this.FormClosed += (s, e) =>
            {
                if (updateLogTimer != null)
                {
                    updateLogTimer.Stop();
                    updateLogTimer.Tick -= UpdateLog;
                    updateLogTimer.Dispose();
                }
            };

            Misc.UI.SetFormLocation<FormLog>(this, Models.Datas.Enums.FormLocations.BottomLeft);
            VgcApis.Misc.UI.AutoSetFormIcon(this);
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            repaintCtrl = new VgcApis.UserControls.RepaintController(rtBoxLogger);
            updateLogTimer.Tick += UpdateLog;
            updateLogTimer.Start();

            // throw new NullReferenceException("for debugging");
        }

        #region private methods

        private void ScrollToBottom()
        {
            rtBoxLogger.SelectionStart = rtBoxLogger.Text.Length;
            rtBoxLogger.ScrollToCaret();
        }

        void UpdateLog(object sender, EventArgs args)
        {
            if (!bar.Install())
            {
                return;
            }

            var timestamp = setting.GetLogTimestamp();

            if (updateTimeStamp == timestamp)
            {
                bar.Remove();
                return;
            }

            try
            {
                repaintCtrl.DisableRepaintEvent();
                rtBoxLogger.Text = setting.GetLogContent();
                ScrollToBottom();
                updateTimeStamp = timestamp;
                repaintCtrl.EnableRepaintEvent();
            }
            catch { }
            finally
            {
                bar.Remove();
            }
        }
        #endregion
    }
}

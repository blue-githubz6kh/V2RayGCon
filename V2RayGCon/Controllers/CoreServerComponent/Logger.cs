﻿namespace V2RayGCon.Controllers.CoreServerComponent
{
    sealed public class Logger :
        VgcApis.BaseClasses.ComponentOf<CoreServerCtrl>,
        VgcApis.Interfaces.CoreCtrlComponents.ILogger
    {
        VgcApis.Libs.Sys.QueueLogger qLogger = new VgcApis.Libs.Sys.QueueLogger();
        Services.Settings setting;

        public Logger(Services.Settings setting)
        {
            this.setting = setting;
        }

        #region public methods
        public void Log(string message)
        {
            qLogger.Log(message);
            try
            {
                setting.SendLog($"[{coreInfo.GetShortName()}] {message}");
            }
            catch { }
        }

        CoreStates coreInfo;
        public override void Prepare()
        {
            coreInfo = GetParent().GetChild<CoreStates>();
        }

        Views.WinForms.FormSingleServerLog logForm = null;
        readonly object formLogLocker = new object();
        public void ShowFormLog()
        {
            lock (formLogLocker)
            {
                if (logForm == null)
                {
                    var title = coreInfo.GetSummary();
                    VgcApis.Misc.UI.Invoke(() =>
                    {
                        logForm = Views.WinForms.FormSingleServerLog.CreateLogForm(title, qLogger);
                        logForm.FormClosed += (s, a) => logForm = null;
                        logForm.Show();
                    });
                }
                VgcApis.Misc.UI.Invoke(() => logForm.Activate());
            }
        }
        #endregion

        #region private methods

        #endregion

        #region protected methods
        protected override void CleanupAfterChildrenDisposed()
        {
            VgcApis.Misc.UI.CloseFormIgnoreError(logForm);
            qLogger.Dispose();
        }
        #endregion
    }
}

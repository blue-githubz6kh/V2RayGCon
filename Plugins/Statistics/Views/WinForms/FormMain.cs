﻿using System;
using System.Windows.Forms;

namespace Statistics.Views.WinForms
{
    public partial class FormMain : Form
    {
        Services.Settings settings;
        VgcApis.Interfaces.Services.IServersService vgcServers;
        Controllers.FormMainCtrl formMainCtrl;

        public static FormMain CreateForm(
            Services.Settings settings,
            VgcApis.Interfaces.Services.IServersService vgcServers)
        {
            FormMain form = null;
            VgcApis.Misc.UI.Invoke(() =>
            {
                form = new FormMain(settings, vgcServers);
            });

            return form;
        }

        FormMain(
            Services.Settings settings,
            VgcApis.Interfaces.Services.IServersService vgcServers)
        {
            this.settings = settings;
            this.vgcServers = vgcServers;
            InitializeComponent();

            VgcApis.Misc.UI.DoubleBuffered(lvStatsTable, true);

            this.FormClosing += (s, a) => formMainCtrl?.Cleanup();
            VgcApis.Misc.UI.AutoSetFormIcon(this);
            formMainCtrl = InitFormMainCtrl();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.Name + " v" + Properties.Resources.Version;
            formMainCtrl.Run();
        }

        #region private methods
        Controllers.FormMainCtrl InitFormMainCtrl()
        {
            var ctrl = new Controllers.FormMainCtrl(
                settings,

                lvStatsTable,

                resetToolStripMenuItem,
                resizeByTitleToolStripMenuItem,
                resizeByContentToolStripMenuItem);
            return ctrl;
        }
        #endregion

        #region UI event


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

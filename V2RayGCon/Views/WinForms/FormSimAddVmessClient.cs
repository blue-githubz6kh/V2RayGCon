﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace V2RayGCon.Views.WinForms
{
    public partial class FormSimAddVmessClient : Form
    {

        #region Sigleton
        static FormSimAddVmessClient _instant;
        public static FormSimAddVmessClient GetForm()
        {
            if (_instant == null || _instant.IsDisposed)
            {
                VgcApis.Misc.UI.Invoke(
                    () =>
                    {
                        _instant = new FormSimAddVmessClient();
                        _instant.Show();
                    });
            }
            return _instant;
        }
        #endregion

        Services.Settings setting;
        Services.ShareLinkMgr slinkMgr;

        FormSimAddVmessClient()
        {
            InitializeComponent();
            Fill(cboxKCP, Models.Datas.Table.kcpTypes);

            setting = Services.Settings.Instance;
            slinkMgr = Services.ShareLinkMgr.Instance;

            VgcApis.Misc.UI.AutoSetFormIcon(this);

            this.FormClosed += (s, a) =>
            {
                setting.LazyGC();
            };
        }

        void Fill(ComboBox cbox, Dictionary<int, string> table)
        {
            cbox.Items.Clear();
            foreach (var item in table)
            {
                cbox.Items.Add(item.Value);
            }
            cbox.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            // using vmess:// v1  do not need fix
            var vmess = new Models.Datas.Vmess();

            vmess.add = tboxHost.Text;
            vmess.port = tboxPort.Text;
            vmess.aid = tboxAID.Text;
            vmess.id = tboxUID.Text;
            vmess.ps = tboxAlias.Text;

            if (rbtnWS.Checked)
            {
                vmess.net = "ws";
                vmess.host = tboxWSPath.Text;
            }

            if (rbtnKCP.Checked)
            {
                vmess.net = "kcp";
                var index = Math.Max(0, cboxKCP.SelectedIndex);
                vmess.type = Models.Datas.Table.kcpTypes[index];
            }

            if (rbtnTCP.Checked)
            {
                vmess.net = "tcp";
            }

            if (chkboxTLS.Checked)
            {
                vmess.tls = "tls";
            }

            slinkMgr.ImportLinkWithOutV2cfgLinks(vmess.ToVmessLink());
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkConfigEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormConfiger.ShowConfig();
        }

        private void btnGenUserID_Click(object sender, EventArgs e)
        {
            tboxUID.Text = Guid.NewGuid().ToString();
        }

        private void tboxPort_TextChanged(object sender, EventArgs e)
        {
            VgcApis.Misc.UI.MarkInvalidPortWithColorRed(tboxPort);
        }

        private void tboxUID_TextChanged(object sender, EventArgs e)
        {
            VgcApis.Misc.UI.MarkInvalidGuidWithColorRed(tboxUID);
        }
    }
}

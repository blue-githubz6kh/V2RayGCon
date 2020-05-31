﻿using System.Collections.Generic;

namespace V2RayGCon.Models.Datas
{
    class UserSettings
    {
        #region public properties
        public string DebugLogFilePath { get; set; }
        public bool isEnableDebugFile { get; set; }

        public int QuickSwitchServerLatency { get; set; }
        public bool isAutoPatchSubsInfo { get; set; }

        // FormOption->Defaults->Mode
        public ImportSharelinkOptions ImportOptions = null;

        // FormOption->Defaults->Speedtest
        public SpeedTestOptions SpeedtestOptions = null;

        // FormDownloadCore
        public bool isDownloadWin32V2RayCore { get; set; } = true;
        public List<string> V2RayCoreDownloadVersionList = null;

        public bool isSupportSelfSignedCert { get; set; }

        public int ServerPanelPageSize { get; set; }
        public bool isEnableStat { get; set; } = false;
        public bool isUseV4Format { get; set; }
        public bool CfgShowToolPanel { get; set; }
        public bool isPortable { get; set; }
        public bool isCheckUpdateWhenAppStart { get; set; }
        public bool isUpdateUseProxy { get; set; }

        // v2ray-core v4.23.1 multiple config file supports
        public string MultiConfItems { get; set; }

        public string ImportUrls { get; set; }
        public string DecodeCache { get; set; }
        public string SubscribeUrls { get; set; }

        public string PluginInfoItems { get; set; }
        public string PluginsSetting { get; set; }

        public string Culture { get; set; }
        public string CoreInfoList { get; set; }
        public string PacServerSettings { get; set; }
        public string SysProxySetting { get; set; }
        public string ServerTracker { get; set; }
        public string WinFormPosList { get; set; }

        public int MaxConcurrentV2RayCoreNum { get; set; }
        #endregion


        public UserSettings()
        {
            Normalized();

            DebugLogFilePath = @"";
            isEnableDebugFile = false;

            QuickSwitchServerLatency = 0;

            isSupportSelfSignedCert = false;

            isAutoPatchSubsInfo = false;

            ServerPanelPageSize = 8;

            MaxConcurrentV2RayCoreNum = 20;

            isCheckUpdateWhenAppStart = false;

            isUpdateUseProxy = true;
            isUseV4Format = true;
            CfgShowToolPanel = true;
            isPortable = true;

            MultiConfItems = string.Empty;
            ImportUrls = string.Empty;
            DecodeCache = string.Empty;
            SubscribeUrls = string.Empty;

            PluginInfoItems = "[{\"filename\":\"ProxySetter\",\"isUse\":true}]";
            PluginsSetting = string.Empty;

            Culture = string.Empty;
            CoreInfoList = string.Empty;
            PacServerSettings = string.Empty;
            SysProxySetting = string.Empty;
            ServerTracker = string.Empty;
            WinFormPosList = string.Empty;

        }

        #region public methods
        public void Normalized()
        {
            V2RayCoreDownloadVersionList = V2RayCoreDownloadVersionList ?? new List<string>();
            ImportOptions = ImportOptions ?? new ImportSharelinkOptions();
            SpeedtestOptions = SpeedtestOptions ?? new SpeedTestOptions();
        }
        #endregion
    }
}

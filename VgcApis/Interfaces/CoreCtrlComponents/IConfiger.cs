﻿using Newtonsoft.Json.Linq;
using System;

namespace VgcApis.Interfaces.CoreCtrlComponents
{
    public interface IConfiger
    {
        JObject GetFinalConfig();

        string GetConfig();

        void SetConfig(string newConfig);

        bool IsSuitableToBeUsedAsSysProxy(bool isGlobal, out bool isSocks, out int port);

        void UpdateSummary();

        void GetterInfoForNotifyIconf(Action<string> next);
    }
}

﻿using System.Collections.Generic;

namespace VgcApis.Interfaces.Lua
{
    public interface ILuaWeb
    {
        /// <summary>
        /// 从字符串中提取出Base64编码的内容
        /// </summary>
        /// <param name="text">一段字符串</param>
        /// <param name="minLen">Base64内容最小长度</param>
        /// <returns>Base64编码的内容</returns>
        List<string> ExtractBase64String(string text, int minLen);

        /// <summary>
        /// 从字符串中提取出Base64编码的内容
        /// </summary>
        /// <param name="text">一段字符串</param>
        /// <returns>Base64编码的内容</returns>
        List<string> ExtractBase64String(string text);

        /// <summary>
        /// 从字符串中提取出全部v2cfg://...链接
        /// </summary>
        /// <param name="text">一段字符串</param>
        /// <returns>v2cfg://...链接</returns>
        List<string> ExtractV2cfgLinks(string text);

        /// <summary>
        /// 从字符串中提取出全部vmess://...链接
        /// </summary>
        /// <param name="text">一段字符串</param>
        /// <returns>vmess://...链接</returns>
        List<string> ExtractVmessLinks(string text);

        /// <summary>
        /// 从字符串中提取出全部ss://...链接
        /// </summary>
        /// <param name="text">一段字符串</param>
        /// <returns>ss://...链接</returns>
        List<string> ExtractSsLinks(string text);

        /// <summary>
        /// 下载url网页的内容
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <returns>指定网址的内容</returns>
        string Fetch(string url);

        /// <summary>
        /// 下载url网页的内容
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <param name="proxyPort">代理端口</param>
        /// <param name="milliSeconds">超时</param>
        /// <returns>指定网址的内容</returns>
        string Fetch(string url, int milliSeconds);

        /// <summary>
        /// 下载url网页的内容
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <param name="proxyPort">代理端口</param>
        /// <param name="milliSeconds">超时</param>
        /// <returns>指定网址的内容</returns>
        string Fetch(string url, int proxyPort, int milliSeconds);

        // Download("http://baidu.com", "d:\index.html")
        /// <summary>
        /// 下载url网页并存成文件
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <param name="filename">保存的文件名</param>
        /// <returns>是否下载成功</returns>
        bool Download(string url, string filename);

        /// <summary>
        /// 下载url网页并存成文件
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <param name="filename">保存的文件名</param>
        /// <param name="millSeconds">超时</param>
        /// <returns>是否下载成功</returns>
        bool Download(string url, string filename, int millSeconds);

        /// <summary>
        /// 下载url网页并存成文件
        /// </summary>
        /// <param name="url">一个网址</param>
        /// <param name="filename">保存的文件名</param>
        /// <param name="proxyPort">代理端口</param>
        /// <param name="millSeconds">超时</param>
        /// <returns>是否下载成功</returns>
        bool Download(string url, string filename, int proxyPort, int millSeconds);

        // the first running http server's port number
        /// <summary>
        /// 获取当前运行的服务器的代理端口号
        /// </summary>
        /// <returns>代理端口号</returns>
        int GetProxyPort();

        // patch short href to full href 
        // e.g. url = "http://baidu.com/" href = "/index.html" result = "http://baidu.com/index.html"
        string PatchHref(string url, string href);

        /// <summary>
        /// 向url发送post请求
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="text">请求内容</param>
        /// <returns>服务器回复内容</returns>
        string Post(string url, string text);

        /// <summary>
        /// 向url发送post请求
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="text">请求内容</param>
        /// <param name="timeout">超时</param>
        /// <returns>服务器回复内容</returns>
        string Post(string url, string text, int timeout);

        // using bing.com to search sth.
        string Search(string keywords, int first, int proxyPort);

        bool Tcping(string url, int milSec);

        bool Tcping(string url, int milSec, int proxyPort);

        /// <summary>
        /// 带超时的下载测试
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="timeout">超时</param>
        /// <param name="kib">下载数据大小</param>
        /// <returns>下载时长</returns>
        long TimedDownloadTesting(string url, int timeout, int kib);

        /// <summary>
        /// 带超时的下载测试
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="timeout">超时</param>
        /// <param name="kib">下载数据大小</param>
        /// <param name="proxyPort">代理端口</param>
        /// <returns>下载时长</returns>
        long TimedDownloadTesting(string url, int timeout, int kib, int proxyPort);

        // direct connect
        /// <summary>
        /// 更新订阅
        /// </summary>
        /// <returns>获得新服务器数量</returns>
        int UpdateSubscriptions();

        // through proxy
        /// <summary>
        /// 通过代理更新订阅
        /// </summary>
        /// <param name="proxyPort">代理端口</param>
        /// <returns>获得新服务器数量</returns>
        int UpdateSubscriptions(int proxyPort);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apps.Common;
using Apps.DAL;
using Apps.IBLL;
using Apps.Models;
using Microsoft.Practices.Unity;
using Apps.Models.Sys;

namespace Apps.Web.Core
{
    public static class LogHandler
    {
 /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="oper">操作人</param>
        /// <param name="mes">操作信息</param>
        /// <param name="result">结果</param>
        /// <param name="type">类型</param>
        /// <param name="module">操作模块</param>
        public static void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {
            SysConfigModel siteConfig = new Apps.BLL.SysConfigBLL().loadConfig(Utils.GetXmlMapPath("Configpath"));
            //后台管理日志开启
            if (siteConfig.logstatus == 1)
            {
                ValidationErrors errors = new ValidationErrors();
                SysLog entity = new SysLog();
                entity.Id = ResultHelper.NewId;
                entity.Operator = oper;
                entity.Message = mes;
                entity.Result = result;
                entity.Type = type;
                entity.Module = module;
                entity.CreateTime = ResultHelper.NowTime;
                using (SysLogRepository logRepository = new SysLogRepository(new DBContainer()))
                {
                    logRepository.Create(entity);
                }
            }
            else
            {
                return;
            }
        }
    }
}
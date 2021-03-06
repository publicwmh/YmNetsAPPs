﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2013-04-22 10:41:47 by App
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using System.Transactions;
using Apps.Models.Sys;
using Apps.IBLL;
using Apps.BLL.Core;
using Apps.Locale;

namespace Apps.BLL
{
    public partial class SysSampleBLL
    {

        public override List<SysSampleModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysSample> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
                                a => a.Id.Contains(queryStr)
                                || a.Name.Contains(queryStr)


                                || a.Photo.Contains(queryStr)
                                || a.Note.Contains(queryStr)

                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //启用通用列头过滤
            if (!string.IsNullOrWhiteSpace(pager.filterRules))
            {
                List<DataFilterModel> dataFilterList = JsonHandler.DeserializeJsonToObject<List<DataFilterModel>>(pager.filterRules).Where(f => !string.IsNullOrWhiteSpace(f.value)).ToList();
                queryData = LinqHelper.DataFilter<SysSample>(queryData, dataFilterList);
            }


           
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.Models.Sys;
using Apps.MIS.IBLL;
using Apps.MIS.IDAL;
using Microsoft.Practices.Unity;
using Apps.Common;
using Apps.BLL.Core;

namespace Apps.MIS.BLL
{
	public class Virtual_MIS_Article_CategoryBLL 
	{
		[Dependency]
        public IMIS_Article_CategoryRepository m_Rep { get; set; }

		public DBContainer db = new DBContainer();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public virtual List<MIS_Article_CategoryModel> GetList(ref GridPager pager,string queryStr)
        {

            IQueryable<MIS_Article_Category> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
										a => (a.Id!=null&&a.Id.Contains(queryStr))
															
														||  (a.Name!=null&&a.Name.Contains(queryStr))
														||  (a.ParentId!=null&&a.ParentId.Contains(queryStr))
														
														||  (a.ImgUrl!=null&&a.ImgUrl.Contains(queryStr))
														||  (a.BodyContent!=null&&a.BodyContent.Contains(queryStr))
														
														
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<MIS_Article_CategoryModel> modelList = (from r in queryData
                                              select new MIS_Article_CategoryModel
                                              {
                                                 													 Id = r.Id,
                                                  													 ChannelId = r.ChannelId,
                                                  													 Name = r.Name,
                                                  													 ParentId = r.ParentId,
                                                  													 Sort = r.Sort,
                                                  													 ImgUrl = r.ImgUrl,
                                                  													 BodyContent = r.BodyContent,
                                                  													 CreateTime = r.CreateTime,
                                                  													 Enable = r.Enable,
                                                  
                                              }).ToList();
            return modelList;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Create(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article_Category();
                					entity.Id = model.Id;
                    					entity.ChannelId = model.ChannelId;
                    					entity.Name = model.Name;
                    					entity.ParentId = model.ParentId;
                    					entity.Sort = model.Sort;
                    					entity.ImgUrl = model.ImgUrl;
                    					entity.BodyContent = model.BodyContent;
                    					entity.CreateTime = model.CreateTime;
                    					entity.Enable = model.Enable;
                    
                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.add("插入失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.DeleteFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Edit(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.add(Suggestion.Disable);
                    return false;
                }
                					entity.Id = model.Id;
                    					entity.ChannelId = model.ChannelId;
                    					entity.Name = model.Name;
                    					entity.ParentId = model.ParentId;
                    					entity.Sort = model.Sort;
                    					entity.ImgUrl = model.ImgUrl;
                    					entity.BodyContent = model.BodyContent;
                    					entity.CreateTime = model.CreateTime;
                    					entity.Enable = model.Enable;
                    


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.EditFail);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public virtual bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public virtual MIS_Article_CategoryModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article_Category entity = m_Rep.GetById(id);
                MIS_Article_CategoryModel model = new MIS_Article_CategoryModel();
                					 model.Id = entity.Id;
                    					 model.ChannelId = entity.ChannelId;
                    					 model.Name = entity.Name;
                    					 model.ParentId = entity.ParentId;
                    					 model.Sort = entity.Sort;
                    					 model.ImgUrl = entity.ImgUrl;
                    					 model.BodyContent = entity.BodyContent;
                    					 model.CreateTime = entity.CreateTime;
                    					 model.Enable = entity.Enable;
                    
                return model;
            }
            else
            {
                return null;
            }
        }
	}
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHS.Common.Http;
using XHS.IService.XHS;
using XHS.Models.XHS.ApiOutputModel.NodeDetail;
using XHS.Models.XHS.ApiOutputModel.UserPosted;
using XHS.Models.XHS.InputModel;

namespace XHS.Service.XHS
{
    /// <summary>
    /// 小红书服务
    /// </summary>
    public class XhsSpiderService : IXhsSpiderService
    {
        /// <summary>
        /// 获取笔记详情
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeDetailModel GetNodeDetail(string nodeid)
        {
            NodeDetailModel nodeDetailModel = new NodeDetailModel();
            try
            {
                string url = $"/api/sns/web/v1/feed?source_note_id={nodeid}";
                var result = HttpClientHelper.DoPost(url);
                if (!string.IsNullOrEmpty(result))
                {
                    nodeDetailModel = JsonConvert.DeserializeObject<NodeDetailModel>(result);
                }
            }
            catch (Exception ex)
            {
            }
            return nodeDetailModel;
        }

        /// <summary>
        /// 分页查询用户所有笔记接口
        /// TODO:这里后面迭代要改掉，先测试接口是否能调用成功
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserPostedModel UserPosted(UserPostedInputModel model)
        {
            UserPostedModel userPostedModel= new UserPostedModel();

            if (model!=null)
            {
                try
                {
                    string url = $"/api/sns/web/v1/user_posted?num={model.num}&cursor=&user_id={model.user_id}";
                    var result = HttpClientHelper.DoPost(url);
                    if (!string.IsNullOrEmpty(result))
                    {
                        userPostedModel = JsonConvert.DeserializeObject<UserPostedModel>(result);
                    }
                }
                catch (Exception ex)
                {
                }
                
            }
            return userPostedModel;
        }


    }
}

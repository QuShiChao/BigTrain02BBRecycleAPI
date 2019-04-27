using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using IDAL;
using Model; 
using Newtonsoft.Json;
using System.Text;
using DAL;
using BBRecycle_Service.Models;
using BBRecycle_Service.Common;

namespace BBRecycle_Service.Controllers
{
    public class BBRecyleAPIController : ApiController
    {
        //private readonly Opetate<AdminInfo> dal = new AutoFacData<AdminInfo>().AutoFac();
        #region 管理员操作
        //添加管理员
        [HttpPost]
        public int AddAdmin(AdminInfo admin)
        {
            return GetBll<AdminInfo>.createDal().Add(admin);
        }
        //获取管理员集合
        [HttpGet]
        public HttpResponseMessage GetAdmin()
        {
            string key = "admin";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(GetBll<AdminInfo>.createDal().Get());
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除管理员集合
        [HttpDelete]
        public int DelAdmin(int id)
        {
            return GetBll<AdminInfo>.createDal().Del(id);
        }
        //修改管理员集合
        [HttpPut]
        public int UpdAdmin(AdminInfo admin)
        {
            return GetBll<AdminInfo>.createDal().Upd(admin);
        }
        #endregion
        #region 用户操作
        //添加用户
        [HttpPost]
        public int AddUser(UserInfo user)
        {
            return GetBll<UserInfo>.createDal().Add(user);
        }
        //获取用户信息
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            string key = "user";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(GetBll<UserInfo>.createDal().Get());
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除用户
        [HttpDelete]
        public int DelUser(int id)
        {
            return GetBll<UserInfo>.createDal().Del(id);
        }
        //修改用户
        [HttpPut]
        public int UpdUser(UserInfo user)
        {
            return GetBll<UserInfo>.createDal().Upd(user);
        }
        #endregion
        #region 回收员操作
        //添加回收员
        public int AddCollector(CollectorInfo collector)
        {
            return GetBll<CollectorInfo>.createDal().Add(collector);
        }
        //获取回收员信息
        public HttpResponseMessage GetCollector()
        {
            string key = "collector";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(GetBll<CollectorInfo>.createDal().Get());
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除回收员
        public int DelCollector(int id)
        {
            return GetBll<CollectorInfo>.createDal().Del(id);
        }
        //修改回收员
        public int UpdCollector(CollectorInfo collector)
        {
            return GetBll<CollectorInfo>.createDal().Upd(collector);
        }
        #endregion
        #region 类别操作
        //添加类别
        public int AddCategory(Category category)
        {
            return GetBll<Category>.createDal().Add(category);
        }
        //获取类别信息
        public HttpResponseMessage GetCategory()
        {
            string key = "cate";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(GetBll<Category>.createDal().Get());
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除类别
        public int DelCategory(int id)
        {
            return GetBll<Category>.createDal().Del(id);
        }
        //修改类别
        public int UpdCategory(Category category)
        {
            return GetBll<Category>.createDal().Upd(category);
        }
        #endregion
        #region 物品操作
        //添加物品
        public int AddRec(Recycles recycles)
        {
            return GetBll<Recycles>.createDal().Add(recycles);
        }
        //获取物品信息
        public HttpResponseMessage GetRec()
        {
            string key = "recycle";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetRecyclesAndCate", null));
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除物品
        public int DelRec(int id)
        {
            return GetBll<Recycles>.createDal().Del(id);
        }
        //修改物品
        public int UpdUser(Recycles recycles)
        {
            return GetBll<Recycles>.createDal().Upd(recycles);
        }
        #endregion
        #region 订单操作
        //添加用户
        public int AddOrder(OrderInfo order)
        {
            return GetBll<OrderInfo>.createDal().Add(order);
        }
        //获取用户信息
        public HttpResponseMessage GetOrder()
        {
            string key = "order";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetOUCC", null));
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除用户
        public int DelOrder(int id)
        {
            return GetBll<OrderInfo>.createDal().Del(id);
        }
        //修改用户
        public int UpdUser(OrderInfo order)
        {
            return GetBll<OrderInfo>.createDal().Upd(order);
        }
        #endregion
        #region 交易记录操作
        //添加交易信息
        public int AddDeal(DealRecord deal)
        {
            return GetBll<DealRecord>.createDal().Add(deal);
        }
        //获取交易信息
        public HttpResponseMessage GetDeal()
        {
            string key = "deal";
            //读库存缓存
            var db = RedisHelper.GetRedisDB();
            if (!db.KeyExists(key))
            {
                string json = JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetDOU", null));
                RedisHelper.SetString(key, json);
            }
            string result = RedisHelper.GetString(key);
            ResultMsg resultMsg = null;
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = result;
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(resultMsg), Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除交易信息
        public int DelDeal(int id)
        {
            return GetBll<DealRecord>.createDal().Del(id);
        }
        //修改交易信息
        public int UpdDeal(DealRecord deal)
        {
            return GetBll<DealRecord>.createDal().Upd(deal);
        }
        #endregion
    }
}

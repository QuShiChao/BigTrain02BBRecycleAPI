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
        public List<AdminInfo> GetAdmin()
        {
            return GetBll<AdminInfo>.createDal().Get();
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
        public int AddUser(UserInfo user)
        {
            return GetBll<UserInfo>.createDal().Add(user);
        }
        //获取用户信息
        public List<UserInfo> GetUser()
        {
            return GetBll<UserInfo>.createDal().Get();
        }
        //删除用户
        public int DelUser(int id)
        {
            return GetBll<UserInfo>.createDal().Del(id);
        }
        //修改用户
        public int UpdUser(UserInfo user)
        {
            return GetBll<UserInfo>.createDal().Upd(user);
        }
        #endregion
        #region 回收员操作
        //添加用户
        public int AddCollector(CollectorInfo collector)
        {
            return GetBll<CollectorInfo>.createDal().Add(collector);
        }
        //获取用户信息
        public List<CollectorInfo> GetCollector()
        {
            return GetBll<CollectorInfo>.createDal().Get();
        }
        //删除用户
        public int DelCollector(int id)
        {
            return GetBll<CollectorInfo>.createDal().Del(id);
        }
        //修改用户
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
        public List<Category> GetCategory()
        {
            return GetBll<Category>.createDal().Get();
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
            string json= JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetRecyclesAndCate",null));
            HttpResponseMessage obj =new HttpResponseMessage(HttpStatusCode.OK){Content=new StringContent(json,Encoding.UTF8,"text/json") };
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
            string json = JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetOUCC", null));
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "text/json") };
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
                string json = JsonConvert.SerializeObject(SqlDbHelper.Get("p_GetDOU", null));
            HttpResponseMessage obj = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "text/json") };
            return obj;
        }
        //删除用户
        public int DelDeal(int id)
        {
            return GetBll<DealRecord>.createDal().Del(id);
        }
        //修改用户
        public int UpdDeal(DealRecord deal)
        {
            return GetBll<DealRecord>.createDal().Upd(deal);
        }
        #endregion
    }
}

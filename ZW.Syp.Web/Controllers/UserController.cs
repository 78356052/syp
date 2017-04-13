using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZW.Syp.Web.Controllers
{
    public class UserController : Controller
    {
        IBLL.IUserService u = new BLL.UserService();
        // GET: User
        public ActionResult Index()
        {
            //u.UpdateEntity(new Model.User() { Id=1,UserName = "zhangsan", Password = "1234567", CreateTime = DateTime.Now });
            u.AddEntity(new Model.User() { UserName = "lisi", Password = "123456", CreateTime = DateTime.Now });
            //u.AddEntity(new Model.User() { UserName = "wangwu", Password = "123456", CreateTime = DateTime.Now });
            //var userinfo = u.LoadEntities(t => t.Id == 1);
            //ViewData.Model = userinfo;
            //u.DeleteEntity(new Model.User() { Id = 2 });
            return View();
        }
    }
}
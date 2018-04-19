using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 精通ASP.NETmvc5.单元测试
{
    public class AdminController:Controller
    {
        private IUserRepostory repository;
        public AdminController(IUserRepostory repo )
        {
            repository = repo;
        }
        public ActionResult ChangeLoginName(string oldname,string newname )
        {
            User user = repository.FetchByLoginName(oldname);
            user.LoginName = newname;
            repository.SubmitChanges();
            return View();
        }
    }
    public class User
    {
        public string LoginName { get; set; }
    }
    public interface IUserRepostory
    {
        void Add( User user );
        User FetchByLoginName( string loginname );
        void SubmitChanges();
    }
    public class DefaultUserRepository : IUserRepostory
    {
        public void Add( User user )
        {
            throw new NotImplementedException();
        }

        public User FetchByLoginName( string loginname )
        {
            return new User() { LoginName = loginname };
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
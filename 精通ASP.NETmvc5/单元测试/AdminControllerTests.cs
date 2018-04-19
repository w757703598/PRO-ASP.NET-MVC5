using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace 精通ASP.NETmvc5.单元测试
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            //准备
            User user = new User() { LoginName = "wql" };
            FakeRepository re = new FakeRepository();
            re.Add(user);
            AdminController target = new AdminController(re);
            string oldname = user.LoginName;
            string newname = "joe";
            //动作（尝试相应的操作）
            target.ChangeLoginName(oldname, newname);
            //断言（验证结果）
            Assert.AreEqual(newname, user.LoginName);
            Assert.IsTrue(re.DidSubmitChanges);
        }
    }

    class FakeRepository : IUserRepostory
    {
        public List<User> users = new List<User>();
        public bool DidSubmitChanges = false;
        public void Add(User user )
        {
            users.Add(user);
        }
        public User FetchByLoginName ( string loginame )
        {
            return users.First(m => m.LoginName == loginame);
        }
        public void SubmitChanges()
        {
            DidSubmitChanges = true;
        }
    }
}
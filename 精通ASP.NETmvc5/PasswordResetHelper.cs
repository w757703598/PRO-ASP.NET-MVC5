using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 精通ASP.NETmvc5
{
    public class PasswordResetHelper
    {
        private IEmailSender mysender;
        //依赖项注入：通过构造器注入称为构造器注入
        public PasswordResetHelper(IEmailSender senderparam )
        {
            mysender = senderparam;
        }
        public void ResetPassword()
        {
            
            //IEmailSender mysender = new MyEmailSender();//实例创建
            mysender.SendEmail();



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Service
{
    public  class SqlDataClass
    {
        public  string GetUserInfo(int UserId)
        {
            string GetUserByToken = @"select distinct UserID,ProjectID,UserLogin,UserType,DatabaseName,ProgramName,SQLServerName
            , SQLUserName, SQLPassword, DisplayCompanyName,ProgramName,PrjURL,PrjLogo,PrjKey from VwUserDetails WHERE UserId = " + UserId+" and IsActive = 1";

            return GetUserByToken;
        }
         
        
    }
}

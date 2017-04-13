using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZW.Syp.IBLL;
using ZW.Syp.Model;

namespace ZW.Syp.BLL
{
    public class UserService : BaseService<User>,IUserService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserDal;
        }


    }
}

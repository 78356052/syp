using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZW.Syp.DAL;
using ZW.Syp.IDAL;
using ZW.Syp.Model;

namespace ZW.Syp.DALFactory
{
    /// <summary>
    /// 数据会话层，负责数据操作类实例的创建。其实就是一个工厂类
    /// </summary>
    public class DBSession:IDBSession
    {
        //DbContext db = new LuxEntities();
        public DbContext Db
        {
            get {
                return DBContextFactory.CreateDbContext();
            }
        }
        private IUserDal _userDal;
        public IUserDal UserDal
        {
            get
            {
                if (_userDal == null)
                {
                    _userDal = DALAbstractFactory.CreateUserDal();
                }
                return _userDal;
            }
            set
            {
                _userDal = value;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges()>0;
        }
    }
}

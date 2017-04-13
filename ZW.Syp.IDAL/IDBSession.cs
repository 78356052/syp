using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZW.Syp.IDAL
{
    public interface IDBSession
    {
        IUserDal UserDal { get; set; }
        bool SaveChanges();
    }
}

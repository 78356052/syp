using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZW.Syp.DALFactory;
using ZW.Syp.IDAL;

namespace ZW.Syp.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IDBSession DbSession
        {
            get { return DBSessionFactory.CreateDbSession(); }
        }

        public IBaseDal<T> CurrentDal { get; set; }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            this.CurrentDal.AddEntity(entity);
            this.DbSession.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            this.CurrentDal.DeleteEntity(entity);
            return this.DbSession.SaveChanges();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentDal.LoadEntities(whereLambda);
        }
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            return this.CurrentDal.LoadPageEntities<s>(pageIndex,pageSize,out totalCount,whereLambda,orderLambda,isAsc);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            this.CurrentDal.UpdateEntity(entity);
            return this.DbSession.SaveChanges();
        }
    }
}

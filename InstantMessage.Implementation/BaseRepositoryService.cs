using InstantMessage.DataModel.InstantMessageDB;
using InstantMessage.Interface;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessage.Service
{
    public class BaseRepositoryService<T> : IBaseRepository<T> where T : class, new()
    {
        public BaseRepositoryService(ImDbContext db)
        {
            _db = db;
        }
        private readonly ImDbContext _db;
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值</returns>
        public async Task<bool> Insert(T entity)
        {
            bool result = false;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值</returns>
        public bool InsertSync(T entity)
        {
            bool result = false;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        public async Task<T> InsertReturnEntity(T entity)
        {
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return entity;
        }

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        public T InsertReturnEntitySync(T entity)
        {
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return entity;
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Insert(List<T> list)
        {
            bool result = false;
            //验证新增数据不为空
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加集合（无实现）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void InsertNoTran(List<T> list)
        {

        }

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值</returns>
        public async Task<bool> Insert<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值</returns>
        public bool InsertSync<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        public async Task<T1> InsertReturnEntity<T1>(T1 entity) where T1 : class, new()
        {
            T1 result = null;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        public T1 InsertReturnEntitySync<T1>(T1 entity) where T1 : class, new()
        {
            T1 result = null;
            //验证新增数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Insert<T1>(List<T1> list) where T1 : class, new()
        {
            bool result = false;
            //验证新增数据不为空
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 添加集合（无实现）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void InsertNoTran<T1>(List<T1> list) where T1 : class, new()
        {

        }

        /// <summary>
        /// 修改（异步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public async Task<bool> Update(T entity)
        {
            bool result = false;
            //验证数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改（同步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public bool UpdateSync(T entity)
        {
            bool result = false;
            //验证数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改集合
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public async Task<bool> Update(List<T> list)
        {
            bool result = false;
            //验证数据不为空
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改集合（无实现）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public void UpdateNoTran(List<T> list)
        {

        }

        /// <summary>
        /// 修改（异步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public async Task<bool> Update<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            //验证数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改（同步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public bool UpdateSync<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            //验证数据不为空
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改集合（异步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public async Task<bool> Update<T1>(List<T1> list) where T1 : class, new()
        {
            bool result = false;
            //验证数据不为空
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 修改集合（同步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public void UpdateNoTran<T1>(List<T1> list) where T1 : class, new()
        {
            //验证数据不为空
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                    throw ex;
                }
            }

        }

        /// <summary>
        /// 保存（新增或修改）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public bool Save(T entity)
        {
            bool result = false;
            return result;
        }

        /// <summary>
        /// 保存集合（新增或修改）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        public bool Save(List<T> list)
        {
            bool result = false;
            return result;
        }

        /// <summary>
        /// 保存集合（新增或修改）（无实现）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        public void SaveNoTran(List<T> list)
        {

        }

        /// <summary>
        /// 保存（新增或修改）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public bool Save<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            return result;
        }

        /// <summary>
        /// 保存集合（新增或修改）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        public bool Save<T1>(List<T1> list) where T1 : class, new()
        {
            bool result = false;
            return result;
        }

        /// <summary>
        /// 保存集合（新增或修改）（无实现）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        public void SaveNoTran<T1>(List<T1> list) where T1 : class, new()
        {

        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        public async Task<bool> Delete(T entity)
        {
            bool result = false;
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        public bool DeleteSync(T entity)
        {
            bool result = false;
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Delete(List<T> list)
        {
            bool result = false;
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除集合（同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteSync(List<T> list)
        {
            bool result = false;
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Deleted;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        public async Task<bool> Delete<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        public bool DeleteSync<T1>(T1 entity) where T1 : class, new()
        {
            bool result = false;
            if (entity != null)
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Delete<T1>(List<T1> list) where T1 : class, new()
        {
            bool result = false;
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 删除集合（同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteSync<T1>(List<T1> list) where T1 : class, new()
        {
            bool result = false;
            if (list.Count > 0)
            {
                try
                {
                    _db.Entry(list).State = EntityState.Deleted;
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    _log.Error("**********DAL***********" + ex.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        public async Task<T> Query(Expression<Func<T, bool>> expression)
        {
            T result = default;
            try
            {
                result = await _db.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        public async Task<T1> Query<T1>(Expression<Func<T1, bool>> expression) where T1 : class, new()
        {
            T1 result = default;
            try
            {
                result = await _db.Set<T1>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        public async Task<List<T>> QueryList(Expression<Func<T, bool>> expression, int skip = 0, int take = 0)
        {
            List<T> result = new List<T>();
            try
            {
                if (take > 0)
                {
                    result = await _db.Set<T>().Where(expression).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    result = await _db.Set<T>().Where(expression).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        public async Task<List<T1>> QueryList<T1>(Expression<Func<T1, bool>> expression, int skip = 0, int take = 0) where T1 : class, new()
        {
            List<T1> result = new List<T1>();
            try
            {
                if (take > 0)
                {
                    result = await _db.Set<T1>().Where(expression).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    result = await _db.Set<T1>().Where(expression).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 查询集合数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<int> QueryListCount(Expression<Func<T, bool>> expression = null)
        {
            int listCount = 0;
            try
            {
                listCount = await _db.Set<T>().Where(expression).CountAsync();
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return listCount;
        }

        /// <summary>
        /// 查询集合数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<int> QueryListCount<T1>(Expression<Func<T1, bool>> expression = null) where T1 : class, new()
        {
            int listCount = 0;
            try
            {
                listCount = await _db.Set<T1>().Where(expression).CountAsync();
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }

            return listCount;
        }

        /// <summary>
        /// 查询sql语句(集合)
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据列表</returns>
        public async Task<List<T>> SqlQueryList(string sql)
        {
            List<T> result = new List<T>();
            await Task.Delay(1);
            return result;
        }
        /// <summary>
        /// 查询sql语句返回单个字段
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetSqlScalar(string sql)
        {
            object result = new object();
            return result;
        }
        /// <summary>
        /// 新增 sql语句方式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteCommand(string sql, params object[] parameters)
        {
            bool result = false;
            try
            {
                int count = 0;
                if (parameters.Length > 0)
                {
                    count = _db.Database.ExecuteSqlCommand(sql, parameters);

                }
                else
                {
                    count = _db.Database.ExecuteSqlCommand(sql);
                }
                if (count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                _log.Error("**********DAL***********" + ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// 开始事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        public void BeginTran()
        {
            _db.Database.BeginTransactionAsync();
        }
        /// <summary>
        /// 提交事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        public void CommitTran()
        {
            _db.Database.CommitTransaction();
        }
        /// <summary>
        /// 回滚事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        public void RollbackTran()
        {
            _db.Database.RollbackTransaction();
        }
    }
}

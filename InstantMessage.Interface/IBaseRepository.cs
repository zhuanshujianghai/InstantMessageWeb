using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessage.Interface
{
    /// <summary>
    /// 基础数据库仓库接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        Task<bool> Insert(T entity);

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        bool InsertSync(T entity);

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        Task<T> InsertReturnEntity(T entity);

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        T InsertReturnEntitySync(T entity);

        /// <summary>
        /// 添加集合（包含事务）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">实体数据集合</param>
        /// <returns></returns>
        Task<bool> Insert(List<T> list);

        /// <summary>
        /// 添加集合（不包含事务、同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">实体数据集合</param>
        /// <returns></returns>
        void InsertNoTran(List<T> list);

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        Task<bool> Insert<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        bool InsertSync<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        Task<T1> InsertReturnEntity<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 添加（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        T1 InsertReturnEntitySync<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 添加集合（包含事务）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">实体数据集合</param>
        /// <returns></returns>
        Task<bool> Insert<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 添加集合（不包含事务、同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">实体数据集合</param>
        /// <returns></returns>
        void InsertNoTran<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 修改（异步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        Task<bool> Update(T entity);

        /// <summary>
        /// 修改（同步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        bool UpdateSync(T entity);

        /// <summary>
        /// 修改集合（包含事务）
        /// </summary>
        /// <param name="list">实体数据集合</param>
        /// <returns>布尔值（修改结果）</returns>
        Task<bool> Update(List<T> list);

        /// <summary>
        /// 修改集合（不包含事务、同步）
        /// </summary>
        /// <param name="list">实体数据集合</param>
        /// <returns>布尔值（修改结果）</returns>
        void UpdateNoTran(List<T> list);

        /// <summary>
        /// 修改（异步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        Task<bool> Update<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 修改（同步）
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        bool UpdateSync<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 修改集合（包含事务）
        /// </summary>
        /// <param name="list">实体数据集合</param>
        /// <returns>布尔值（修改结果）</returns>
        Task<bool> Update<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 修改集合（不包含事务、同步）
        /// </summary>
        /// <param name="list">实体数据集合</param>
        /// <returns>布尔值（修改结果）</returns>
        void UpdateNoTran<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 保存（新增或修改、同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        bool Save(T entity);

        /// <summary>
        /// 保存集合（新增或修改）（包含事务、同步）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        bool Save(List<T> list);

        /// <summary>
        /// 保存集合（新增或修改）（不包含事务、同步）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        void SaveNoTran(List<T> list);

        /// <summary>
        /// 保存（新增或修改、同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        bool Save<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 保存集合（新增或修改）（包含事务、同步）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        bool Save<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 保存集合（新增或修改）（不包含事务、同步）
        /// </summary>
        /// <param name="list">数据实体集合</param>
        /// <returns></returns>
        void SaveNoTran<T1>(List<T1> list) where T1 : class, new();

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        Task<bool> Delete(T entity);

        /// <summary>
        /// 删除（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        bool DeleteSync(T entity);

        /// <summary>
        /// 删除集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Delete(List<T> entity);

        /// <summary>
        /// 删除集合（同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSync(List<T> entity);

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        Task<bool> Delete<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 删除（同步）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        bool DeleteSync<T1>(T1 entity) where T1 : class, new();

        /// <summary>
        /// 删除集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Delete<T1>(List<T1> entity) where T1 : class, new();

        /// <summary>
        /// 删除集合（同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSync<T1>(List<T1> entity) where T1 : class, new();

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        Task<T> Query(Expression<Func<T, bool>> Lambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        Task<T1> Query<T1>(Expression<Func<T1, bool>> Lambda) where T1 : class, new();

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        Task<List<T>> QueryList(Expression<Func<T, bool>> expression = null, int skip = 0, int take = 0);

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        Task<List<T1>> QueryList<T1>(Expression<Func<T1, bool>> expression = null, int skip = 0, int take = 0) where T1 : class, new();

        /// <summary>
        /// 查询集合数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> QueryListCount(Expression<Func<T, bool>> expression = null);

        /// <summary>
        /// 查询集合数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> QueryListCount<T1>(Expression<Func<T1, bool>> expression = null) where T1 : class, new();

        /// <summary>
        /// 查询sql语句(集合)
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据列表</returns>
        Task<List<T>> SqlQueryList(string sql);

        /// <summary>
        /// 查询sql语句返回单个字段
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        object GetSqlScalar(string sql);

        /// <summary>
        /// 执行sql语句方式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteCommand(string sql, params object[] parameters);

        /// <summary>
        /// 开始事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        void BeginTran();
        /// <summary>
        /// 提交事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        void CommitTran();
        /// <summary>
        /// 回滚事务【注意此方法不支持多线程，仅在一个线程中有效】
        /// </summary>
        void RollbackTran();
    }
}

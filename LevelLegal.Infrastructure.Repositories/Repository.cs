using LevelLegal.Domain.Entities.Data;
using LevelLegal.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LevelLegal.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public Repository(DataAccess context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        protected DbContext Context { get; }

        protected DbSet<T> DbSet { get; }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            DbSet.AddRange(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entity)
        {
            DbSet.UpdateRange(entity);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        //public DataSet ExecuteQueryCommand(string spName, List<KeyValuePair<string, object>> pcolParameter = null)
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection objConnection = new SqlConnection(Context.Database.GetDbConnection().ConnectionString);
        //    SqlCommand objCommand = null;
        //    try
        //    {
        //        objConnection.Open();

        //        objCommand = new SqlCommand(spName, objConnection);
        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;

        //        SqlParameter objReturnValue = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);

        //        if (pcolParameter != null)
        //        {
        //            foreach (var objParameter in pcolParameter)
        //            {
        //                objCommand.Parameters.AddWithValue(objParameter.Key, objParameter.Value);
        //            }
        //        }

        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = objCommand;

        //        da.Fill(ds);

        //        objCommand.Dispose();
        //        objConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;

        //        objCommand.Dispose();
        //        objConnection.Close();
        //    }

        //    return ds;
        //}

    }
}

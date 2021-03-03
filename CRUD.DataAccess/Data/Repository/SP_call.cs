using CRUD.DataAccess.Data.Repository.IRepository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Data.Repository
{
    public class SP_call : ISP_call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public SP_call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                throw new Exception();
            }
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                throw new Exception();
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();

                    if(item1!=null && item2 != null)
                    {
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                    }

                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                throw new Exception();
            }
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    var value = sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

                    return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                throw new Exception();
            }
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    var value = sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

                    return (T)Convert.ChangeType(value, typeof(T));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                throw new Exception();
            }
        }
    }
}

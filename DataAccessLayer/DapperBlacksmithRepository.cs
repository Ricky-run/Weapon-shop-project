using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using WeaponShopModel;

namespace DataAccessLayer
{
    public class DapperBlacksmithRepository : IRepository<Blacksmith>
    {
        private readonly string _connectionString;

        public DapperBlacksmithRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Blacksmith item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Blacksmiths (Name) VALUES (@Name)";
                db.Execute(sql, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Blacksmiths WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public IEnumerable<Blacksmith> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Blacksmiths";
                return db.Query<Blacksmith>(sql).ToList();
            }
        }

        public Blacksmith ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Blacksmiths WHERE Id = @Id";
                return db.QuerySingleOrDefault<Blacksmith>(sql, new { Id = id });
            }
        }

        public void Update(Blacksmith item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Blacksmiths SET Name = @Name WHERE Id = @Id";
                db.Execute(sql, item);
            }
        }
    }
}

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using WeaponShopModel;

namespace DataAccessLayer
{
    public class DapperWeaponRepository : IRepository<Weapon>
    {
        private readonly string _connectionString;

        public DapperWeaponRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Weapon item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Weapons (Name, Price) VALUES (@Name, @Price)";
                db.Execute(sql, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Weapons WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public IEnumerable<Weapon> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Weapons";
                return db.Query<Weapon>(sql).ToList();
            }
        }

        public Weapon ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Weapons WHERE Id = @Id";
                return db.QuerySingleOrDefault<Weapon>(sql, new { Id = id });
            }
        }

        public void Update(Weapon item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Weapons SET Name = @Name, Price = @Price WHERE Id = @Id";
                db.Execute(sql, item);
            }
        }
    }
}

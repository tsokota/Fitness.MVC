using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.DataObjects.Data;

namespace Fitness.AdoNet.Repositories
{
    public interface IChargeRepository
    {
        List<ChargeExtended> GetList();
        ChargeExtended GetItemById(int id);
        void AddItem(Charge elem);
        void EditItem(int id, Charge elem);
        void DeleteItem(int id);
    }
    public class ChargeRepository : IChargeRepository
    {
        private IConnectionRepository _connRepos;

        public ChargeRepository(IConnectionRepository connectionRepository)
        {
            _connRepos = connectionRepository;
        }

        public List<ChargeExtended> GetList()
        {
            string sql = "select c.Id, cg.Name as GroupName, c.Name, c.Summ, c.Date from charges c left  join ChargeGroup cg on c.GroupId = cg.Id ";

            DataTable dt = _connRepos.GetTableResult(sql);

            var result = new List<ChargeExtended>();

            foreach (DataRow dr in dt.Rows)
            {
                var charge = new ChargeExtended
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Date = Convert.ToDateTime(dr["Date"]),
                    Summ = Convert.ToDecimal(dr["Summ"]),
                    Name = dr["Name"].ToString(),
                    GroupName = dr["GroupName"].ToString(),
                };

                result.Add(charge);
            }
            return result;
        }

        public ChargeExtended GetItemById(int id)
        {
            string sql = "select c.Id, cg.Name as GroupName, c.Name, c.Summ, c.Date from charges c left join ChargeGroup cg on c.GroupId = cg.Id where c.Id = " + id;

            DataTable dt = _connRepos.GetTableResult(sql);

            var result = new List<ChargeExtended>();

            foreach(DataRow dr in dt.Rows)
            {
                var charge = new ChargeExtended
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Date = Convert.ToDateTime(dr["Date"]),
                    Summ = Convert.ToDecimal(dr["Summ"]),
                    Name = dr["Name"].ToString(),
                    GroupName = dr["GroupName"].ToString(),
                };

                result.Add(charge);
            }
            return result[0];
        }

        [Obsolete]
        public void AddItem(Charge elem)
        {
            string sql = "INSERT INTO Charges([Date], Summ, Name) VALUES (@Date, @Summ, @Name)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@Date", elem.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.Add("@Summ", elem.Summ);
            cmd.Parameters.Add("@Name", elem.Name);
            _connRepos.Execute(cmd);
        }

        [Obsolete]
        public void EditItem(int id, Charge elem)
        {
            string sql = "UPDATE Charges SET Summ = @Summ, Date = @Date, Name = @Name " +
                         "where Id = " + id;
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@Date", elem.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.Add("@Summ", elem.Summ);
            cmd.Parameters.Add("@Name", elem.Name);
            _connRepos.Execute(cmd);
        }


        [Obsolete]
        public void DeleteItem(int id)
        {
            string sql = "DELETE FROM Charges WHERE Id = @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@ID", id);
            _connRepos.Execute(cmd);
        }

    }
}

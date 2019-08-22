using Fitness.DataObjects.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.AdoNet.Repositories
{
    public interface IAbonementIncomeRepository
    {
        List<AbonementIncomeExtended> GetList();
        void AddItem(AbonementIncome elem);
    }
    public class AbonementIncomeRepository : IAbonementIncomeRepository
    {
        private IConnectionRepository _connRepos;

        public AbonementIncomeRepository(IConnectionRepository connectionRepository)
        {
            _connRepos = connectionRepository;
        }

        public List<AbonementIncomeExtended> GetList()
        {
            string sql = "select ai.Id, a.[Name] as Abonement, c.FIO as Client, u.FIO as [User], ai.[Date], ai.Summ " +
                "from AbonementIncome ai " +
                "left join Abonements a on ai.AbonementId = a.Id " +
                "left join Clients c on ai.ClientId = c.Id " +
                "left join Users u on ai.UserId = u.Id ";

            DataTable dt = _connRepos.GetTableResult(sql);

            var result = new List<AbonementIncomeExtended>();

            foreach (DataRow dr in dt.Rows)
            {
                var charge = new AbonementIncomeExtended
                {
                    Date = Convert.ToDateTime(dr["Date"]),
                    Id = Convert.ToInt32(dr["Id"]),
                    Summ = Convert.ToDecimal(dr["Summ"]),
                    ClientName = dr["Client"].ToString(),
                    AbonementName = dr["Abonement"].ToString(),
                    UserName = dr["User"].ToString()
                };

                result.Add(charge);
            }
            return result;
        }

        [Obsolete]
        public void AddItem(AbonementIncome elem)
        {
            string sql = "INSERT INTO AbonementIncome([Date], Summ) VALUES (@Date, @Summ)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@Date", elem.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.Add("@Summ", elem.Summ);
            _connRepos.Execute(cmd);
        }
    }
}


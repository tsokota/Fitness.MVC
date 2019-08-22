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
            string sql = "select c.Id, cg.Name as GroupName, c.Name, c.Summ, c.Date from charges c inner join ChargeGroup cg on c.GroupId = cg.Id";

            DataTable dt = _connRepos.GetTableResult(sql);

            var result = new List<ChargeExtended>();

            foreach(DataRow dr in dt.Rows)
            {
                var charge = new ChargeExtended
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Date = Convert.ToDateTime(dr["Date"]),
                    Summ = Convert.ToDecimal(dr["Summ"]),
                    GroupName = dr["GroupName"].ToString(),
                };

                result.Add(charge);
            }
            return result;
        }
    }
}

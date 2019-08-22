using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.AdoNet.Repositories;
using Fitness.DataObjects.Data;


namespace Fitness.Business.Services
{
    public interface IChargeService
    {
        List<ChargeExtended> GetList();
    }

    public class ChargeService : IChargeService
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeService(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public List<ChargeExtended> GetList()
        {
            return _chargeRepository.GetList();
        }
    }
}

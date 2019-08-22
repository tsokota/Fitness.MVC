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
        ChargeExtended GetItem(int id);
        void Create(Charge elem);
        void Edit(int id, Charge elem);
        void Delete(int id);
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

        public ChargeExtended GetItem(int id)
        {
            return _chargeRepository.GetItemById(id);
        }

        public void Create(Charge elem)
        {
            _chargeRepository.AddItem(elem);
        }

        public void Edit(int id, Charge elem)
        {
            _chargeRepository.EditItem(id, elem);
        }

        public void Delete(int id)
        {
            _chargeRepository.DeleteItem(id);
        }
    }
}

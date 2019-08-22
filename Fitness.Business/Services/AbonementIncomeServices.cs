using Fitness.AdoNet.Repositories;
using Fitness.DataObjects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services
{
    public interface IAbonementIncomeService
    {
        List<AbonementIncomeExtended> GetList();
        AbonementIncomeExtended GetItem(int id);
        void Create(AbonementIncome elem);
        void Edit(int id, AbonementIncome elem);
        void Delete(int id);
    }

    public class AbonementIncomeService : IAbonementIncomeService
    {
        private readonly IAbonementIncomeRepository _abonementIncomeRepository;

        public AbonementIncomeService(IAbonementIncomeRepository abonementIncomeRepository)
        {
            _abonementIncomeRepository = abonementIncomeRepository;
        }

        public List<AbonementIncomeExtended> GetList()
        {
            return _abonementIncomeRepository.GetList();
        }

        public AbonementIncomeExtended GetItem(int id)
        {
            return _abonementIncomeRepository.GetItemById(id);
        }

        public void Create(AbonementIncome elem)
        {
           _abonementIncomeRepository.AddItem(elem);
        }

        public void Edit(int id, AbonementIncome elem)
        {
            _abonementIncomeRepository.EditItem(id, elem);
        }

        public void Delete(int id)
        {
            _abonementIncomeRepository.DeleteItem(id);
        }
    }
}

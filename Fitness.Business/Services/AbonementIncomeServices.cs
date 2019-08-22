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
        void Create(AbonementIncome elem);
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

        public void Create(AbonementIncome elem)
        {
           _abonementIncomeRepository.AddItem(elem);
        }
    }
}

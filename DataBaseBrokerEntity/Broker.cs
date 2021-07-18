using DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseBrokerEntity
{
    public class Broker
    {
        private static Broker _instance;
        private CalculationContext _context;

        public static Broker Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Broker();
                return _instance;
            }
        }

        private Broker()
        {
            _context = new CalculationContext();
        }

        public Operater LogInSuccesful(string firstName, string password)
        {
            var operaters = _context.Operaters.ToList();

            foreach (var operater in operaters)
            {
                if (operater.FirstName == firstName && operater.Password == password)
                    return operater;
            }

            return null;
        }

    }
}

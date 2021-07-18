using DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.LogIn
{
    public class OperaterEventArgs
    {
        private readonly Operater _operater;

        public Operater Operater => _operater;

        public OperaterEventArgs(Operater operater)
        {
            _operater = operater;
        }
    }
}

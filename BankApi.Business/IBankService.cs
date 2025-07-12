using BankApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankApi.Business
{
    public interface IBankService
    {
        void Add(Bank bank);
        void Update(Bank bank);
        void Delete(Bank bank);
        List<Bank> List(bool? isActive, int page, int pageSize);
        Bank Get(Expression<Func<Bank, bool>> filter);
    }
}

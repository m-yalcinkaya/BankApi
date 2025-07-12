

using BankApi.Entity;
using BankApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Azure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BankApi.Business
{
    public class BankManager : IBankService
    {

        private readonly MyContext _myContext;

        public BankManager(MyContext context) {
            _myContext = context;
        }

        public void Add(Bank bank)
        {
            _myContext.Entry(bank).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _myContext.SaveChanges();
        }

        public void Delete(Bank bank)
        {
            _myContext.Entry(bank).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _myContext.SaveChanges();
        }

        public Bank Get(Expression<Func<Bank, bool>> filter) => _myContext.Banks.SingleOrDefault(filter);

        public List<Bank> List(bool? isActive, int page = 1, int pageSize = 10)
        {
            var query = _myContext.Banks.ToList();

            // isActive varsa filtrele
            if (isActive.HasValue)
                query = query.Where(b => b.IsActive == isActive.Value).ToList();

            // Linq metodlarıyla pagination
            var pagedData = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedData;
        }

        public void Update(Bank bank)
        {
            _myContext.Entry(bank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _myContext.SaveChanges();
        }
    }
}

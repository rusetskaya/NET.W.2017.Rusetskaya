using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class AccontRepository : IAccountRepository
    {
        private readonly DbContext context;

        public AccontRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalAccount> GetAll()
        {
            return context.Set<Account>().Select(account => new DalAccount()
                        {
                            Id = account.Id,
                            AccountNumber = account.Number.ToString(),
                            AccountType = account.AccountType.Name,
                            OwnerName = account.Owner.Name,
                            Balance = account.Balance,
                            BenefitPoints = account.BenefitPoints
                        });
        }

        public DalAccount GetById(int key)
        {
            var ormaccont = context.Set<Account>().FirstOrDefault(account => account.Id == key);
            return new DalAccount()
            {
                Id = ormaccont.Id,
                AccountNumber = ormaccont.Number.ToString()

            };
        }

        public DalAccount GetByPredicate(Expression<Func<DalAccount, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalAccount e)
        {
            var account = new Account()
            {
                Number = Convert.ToInt32(e.AccountNumber),
                OwnerId = e.Id
            };
            context.Set<Account>().Add(account);
        }

        public void Delete(DalAccount e)
        {
            var account = new Account()
            {
                Id = e.Id,
                Owner = e.OwnerName.ToString(),
                RoleId = e.RoleId
            };
            account = context.Set<User>().Single(u => u.Id == account.Id);
            context.Set<User>().Remove(account);
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
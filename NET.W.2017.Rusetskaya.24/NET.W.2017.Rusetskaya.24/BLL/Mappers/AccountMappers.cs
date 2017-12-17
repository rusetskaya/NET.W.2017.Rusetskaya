using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class AccountMappers
    {
        public static DalAccount ToDalAccount(this Account account) => new DalAccount
        {
            AccountType = account.GetType().AssemblyQualifiedName,
            AccountNumber = account.AccountNumber,
            OwnerName = account.OwnerName,
            Balance = account.Balance,
            BenefitPoints = account.BenefitPoints
        };

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.Name,
                RoleId = dalUser.RoleId
            };
        }
    }
}

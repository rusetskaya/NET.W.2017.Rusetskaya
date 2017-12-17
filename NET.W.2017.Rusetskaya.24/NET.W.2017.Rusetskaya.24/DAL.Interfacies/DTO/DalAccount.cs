namespace DAL.Interfacies.DTO
{
    public class DalAccount
    {
        public string AccountType { get; set; }

        public string AccountNumber { get; set; }

        public string OwnerName { get; set; }

        public decimal Balance { get; set; }

        public int BenefitPoints { get; set; }
    }
}
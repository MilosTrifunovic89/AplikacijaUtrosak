namespace Domain.Customer
{
    public class PublicCustomer : CustomerClass
    {
        #region Properties
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PIB { get; set; }
        public string CompanyIDnumber { get; set; }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return (obj is PublicCustomer publicCustomer && publicCustomer.ID == ID);
        }
        #endregion
    }
}

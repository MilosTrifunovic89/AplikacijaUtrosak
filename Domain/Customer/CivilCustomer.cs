namespace Domain.Customer
{
    public class CivilCustomer : CustomerClass
    {
        #region Properties
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string IDnumber { get; set; }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return (obj is CivilCustomer civilCustomer && civilCustomer.ID == ID);
        }
        #endregion

    }
}

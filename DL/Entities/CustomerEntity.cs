namespace DL.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public long CustomerId { get; set; }

        public string CustomerName{ get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

    }
}

namespace DL.SqlQueries
{
    public static class CustomerQueries
    {
        public const string CreateCustomer = @"
            INSERT INTO Customers (CustomerName, Email, Phone)
            VALUES (@CustomerName, @Email, @Phone);
            SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

        public const string GetCustomers = @"
            SELECT CustomerId, CustomerName, Email, Phone, CreatedDate, ModifiedDate, IsDeleted
            FROM Customers
            WHERE IsDeleted = 0";

        public const string GetCustomerById = @"
            SELECT CustomerId, CustomerName, Email, Phone, CreatedDate, ModifiedDate, IsDeleted
            FROM Customers
            WHERE CustomerId = @CustomerId AND 
            IsDeleted = 0";

        public const string UpdateCustomer = @"
            UPDATE Customers
            SET CustomerName = @CustomerName,
                Email = @Email,
                Phone = @Phone,
                ModifiedDate = GETUTCDATE()
            WHERE CustomerId = @CustomerId AND 
            IsDeleted = 0";

        public const string SoftDeleteCustomer = @"
            UPDATE Customers
            SET IsDeleted = 1,
                ModifiedDate = GETUTCDATE()
            WHERE CustomerId = @CustomerId AND
            IsDeleted = 0";
    }
}
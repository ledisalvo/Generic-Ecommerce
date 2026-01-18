namespace Generic_Ecommerce.Application.Exceptions
{
    public static class AppErrorCatalog
    {
        public static readonly Error CreateCustomerCustomerExists = new("CREATECUSTOMER_CUSTOMEREXISTS", "Ese cliente ya existe en el sistema.");
        public static readonly Error GetCustomerCustomerNotFound = new("GETCUSTOMER_CUSTOMERNOTFOUND", "Ese cliente no existe en el sistema.");
    }
}

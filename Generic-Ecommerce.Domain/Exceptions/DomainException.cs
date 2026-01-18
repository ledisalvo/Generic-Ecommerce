namespace Generic_Ecommerce.Domain.Exceptions
{
    /// <summary>
    /// Excepción base para reglas de negocio en el dominio.
    /// </summary>
    public class DomainException : Exception
    {   
        public string Code { get; }
        public DomainException(string code, string message) : base(message) { Code = code; }
    }
}

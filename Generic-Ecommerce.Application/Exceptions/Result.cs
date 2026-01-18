using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Application.Exceptions
{
    public class Result<T>
    {
        public bool Success { get; }
        public T? Value { get; }
        public List<Error> Errors { get; }

        private Result(bool success, T? value, List<Error> errors)
        {
            Success = success;
            Value = value;
            Errors = errors;
        }

        /// <summary>
        /// Crea un <see cref="Result{T}"/> exitoso que contiene el valor especificado.
        /// </summary>
        /// <param name="value">El valor que se asociará con el resultado exitoso.</param>
        /// <returns>Una instancia de <see cref="Result{T}"/> que representa una operación exitosa con el valor proporcionado.</returns>
        public static Result<T> Ok(T value) =>
            new(true, value, new List<Error>());

        /// <summary>
        /// Crea una instancia de <see cref="Result{T}"/> fallida con el código y mensaje de error especificados.
        /// </summary>
        /// <param name="code">El código de error que identifica el tipo o categoría de la falla. No puede ser <see langword="null"/> ni estar vacío.</param>
        /// <param name="message">El mensaje de error que describe el motivo de la falla. No puede ser <see langword="null"/> ni estar vacío.</param>
        /// <returns>Un <see cref="Result{T}"/> que representa una operación fallida, conteniendo la información de error proporcionada.</returns>
        public static Result<T> Fail(string code, string message) =>
            new Result<T>(false, default, new List<Error> { new Error(code, message) });

        /// <summary>
        /// Crea una instancia de <see cref="Result{T}"/> fallida con la colección de errores especificada.
        /// </summary>
        /// <param name="errors">La colección de objetos <see cref="Error"/> que describen los motivos de la falla. No puede ser nula ni contener elementos nulos.</param>
        /// <returns>Un <see cref="Result{T}"/> que representa una operación fallida, conteniendo los errores proporcionados.</returns>
        public static Result<T> Fail(IEnumerable<Error> errors) =>
            new Result<T>(false, default, errors.ToList());
    }

    public record Error(string Code, string Message);
}

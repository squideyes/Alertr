using Alertr.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alertr.ClientTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailAlert = new EmailAlert();

            var results = new List<ValidationResult>();

            if (!ValidationHelper.TryValidate(emailAlert, out results))
            {
                foreach (var result in results)
                    Console.WriteLine(result.ErrorMessage);
            };

            Console.ReadKey();
        }
    }
}

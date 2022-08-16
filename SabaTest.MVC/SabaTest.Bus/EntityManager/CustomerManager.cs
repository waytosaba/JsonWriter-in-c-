using System;
using System.IO;
using SabaTest.Data.Model;

namespace SabaTest.Bus
{
    public class CustomerManager
    {
        #region WriteToJsonFile        
        /// <summary>
        /// Writes customer details to json file.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string WriteToJsonFile(Customer customer, string filePath)
        {
            var dataResult = JsonWriterHelper.WriteJsonFile(customer, filePath);
            return dataResult;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SabaTest.Bus
{
    public class JsonWriterHelper
    {

        #region WriteJsonFile        
        /// <summary>
        /// Writes any object to json format
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string WriteJsonFile(object obj, string filePath)
        {
            try
            {
                var options = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var jsonString = ConvertToByteFormat(obj, options);
                File.WriteAllBytes(filePath, jsonString);
                return MessageText.FileWritten;
            }
            catch (Exception e)
            {
                var error = $"{MessageText.FileFailed} {e.Message}";
                //TODO add log file before return
                return error;
            }
        }

        #endregion

        #region ConvertToByteFormat        
        /// <summary>
        ///  serialize to UTF-8 bytes which is about 5-10% faster than using the string-based methods
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        private static byte[] ConvertToByteFormat(object obj, JsonSerializerSettings options)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            var jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer.CreateDefault(options).Serialize(jsonWriter, obj);
            jsonWriter.Flush();
            stream.Position = 0;
            return stream.ToArray();
        }
        #endregion
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Test.Models
{
    /// <summary>
    /// Данные из файла
    /// </summary>
    public class FileData
    {
        public Person[] persons { get; set; }

        /// <summary>
        /// Получить данные из файла 
        /// </summary>
        /// <returns></returns>
        public static List<Person> getFileData()
        {
            var file = System.IO.File.Exists(FastСonst.fileName) ? System.IO.File.ReadAllText(FastСonst.fileName) : null;
            FileData fileData = file != null ? JsonConvert.DeserializeObject<FileData>(file) : null;
            return fileData?.persons.ToList();
        }
    }
}

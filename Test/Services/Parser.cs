using System;

namespace Test.Services
{
    /// <summary>
    /// Сервис для парсинга
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Из строки в дату
        /// </summary>
        /// <param name="date">дата строкой</param>
        /// <returns></returns>
        public static DateTime stringToDateTime(string date)
        {
            return DateTime.Parse(date);
        }
    }
}

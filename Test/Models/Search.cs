using System.Text.RegularExpressions;

namespace Test.Models
{
    /// <summary>
    /// Модель поиска в файле
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Тип поиска
        /// 1 - по городам, 
        /// 2 - по языкам, 
        /// 3 - по диапазону дат рождения
        /// </summary>
        public int typeSearch { get; set; }
        /// <summary>
        /// Параметр поиска
        /// </summary>
        public string parameter1 { get; set; }
        /// <summary>
        /// Параметр поиска
        /// </summary>
        public string parameter2 { get; set; }

        /// <summary>
        /// Валидация модели
        /// </summary>
        /// <returns></returns>
        public bool validateSearch()
        {
            Regex regex = new Regex(FastСonst.regexLetters);
            if (typeSearch > 0 && typeSearch < 3)
                return string.IsNullOrEmpty(parameter1) 
                    || !regex.IsMatch(parameter1) ? false : true;
            if (typeSearch == 3 
                && !string.IsNullOrEmpty(parameter1) 
                && !string.IsNullOrEmpty(parameter2))
            {
                if (!regex.IsMatch(parameter1) 
                    && !regex.IsMatch(parameter2))
                    return true;
            }
            return false;
        }
    }
}

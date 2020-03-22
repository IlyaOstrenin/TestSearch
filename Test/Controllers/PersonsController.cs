using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    /// <summary>
    /// Работа с данными
    /// </summary>
    public class PersonsController : Controller
    {
        /// <summary>
        /// Получить данные из файла
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/person")]
        public List<Person> Get()
        {
            return FileData.getFileData();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/person")]
        public ActionResult<List<Person>> Post(Search search)
        {
            if (!search.validateSearch())
                return BadRequest(FastСonst.errorAnswer);
            List<Person> persons = FileData.getFileData();
            List<Person> filterPersons = new List<Person>();
            switch (search.typeSearch)
            {
                case 1://по городам
                    {
                        filterPersons = persons
                            .Where(x => !string.IsNullOrEmpty(x.location) 
                            && x.location
                            .ToLower()
                            .Contains(search.parameter1
                            .ToLower()))
                            .ToList();
                    }
                    break;
                case 2://по языкам
                    {
                        foreach (var itemPerson in persons.Where(x => x.languages.Length > 0))
                        {
                            var languagesToString = (String.Join(", ", itemPerson.languages)).ToLower();
                            if (languagesToString.Contains(search.parameter1.ToLower()))
                                filterPersons.Add(itemPerson);
                        }
                    }
                    break;
                case 3://по диапазону дат рождения
                    {
                        DateTime date1 = Parser.stringToDateTime(search.parameter1);
                        DateTime date2 = Parser.stringToDateTime(search.parameter2);
                        DateTime dateMax = date1 > date2 ? date1 : date2;
                        DateTime dateMin = dateMax == date1 ? date2 : date1;
                        foreach (var itemPerson in persons.Where(x => !string.IsNullOrEmpty(x.dob)))
                        {
                            DateTime itemBob = Parser.stringToDateTime(itemPerson.dob);
                            if (itemBob <= dateMax && itemBob >= dateMin)
                                filterPersons.Add(itemPerson);
                        }
                    }
                    break;
            }
            return filterPersons;
        }
    }
}

using Laboratorio12.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio12.Controllers
{
    [Route("api/[controller]/[action]")]
    //agregar el action permite que se pueda diferenciar por cada seccion
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //[HttpGet(Name = "Get")]
        //al añadir el action ya no es necesario separar por funcion
        [HttpGet]
        public List<Person> Get()
        {
            List<Person> response = GetPeople();

            return response;
        }

        private static List<Person> GetPeople()
        {
            var response = new List<Person>();

            for (int i = 0; i < 20; i++)
            {
                response.Add(
                    new Person
                    {
                        Id = i + 1,
                        FirstName = "Luis",
                        LastName = "Gastelu"
                    }
                );
            }

            return response;
        }

        //[HttpGet(Name = "GetById")]
        //al añadir el action ya no es necesario separar por funcion
        [HttpGet]
        public Person GetById(int id)
        {
            //var response = new Person
            //{
            //    Id = 1,
            //    FirstName = "Luis",
            //    LastName = "Gastelu"
            //};

            List<Person> people = GetPeople();

            var response = people.Where(x => x.Id == id).FirstOrDefault();

            return response;
        }

        [HttpPost]
        public Person GetByFilter(Person person)
        {

            List<Person> people = GetPeople();

            var response = people.Where(x => x.Id == person.Id).FirstOrDefault();

            return response;
        }

        [HttpPost]
        public bool Insert()
        {
            var response = new ResponseBase();
            //response.Message = "Inserto Correctamente";
            //response.Id = 0;

            response.Message = "EL CODIGO YA EXISTE";
            response.Id = -1;

            return true;
        }
    }
}

using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Model.Context;
using RestWithAPSNETUdemy.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAPSNETUdemy.Business.Implementations
{
    public class IPersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public IPersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Create(Person person)
        {         
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

using RentACar.DataModels.Requests.Country;
using RentACar.DataModels.Responses.City;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.DataModels.Responses.Person;
using RentACar.DataModels.Requests.Person;

namespace RentACar.Service.Methods
{
    public class PersonService : IPersonService
    {
        private readonly DbSetContext context= new DbSetContext();


        public List<Person> GetAll()
        {
            return context.Person.ToList();
        }
        public CreatePersonResponse CreateNewPerson(CreatePersonRequest request)
        {

            var AddNewPerson = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                JMBG = request.JMBG,

            };
            context.Person.Add(AddNewPerson);
            context.SaveChanges();
            return new CreatePersonResponse() { Person = AddNewPerson };
            
        }

        public CreatePersonResponse Update(UpsertPresonRequest request)
        {
            var existPerson = context.Person.FirstOrDefault(x => x.PersonId == request.PresonId);
            if (existPerson == null)
            {
                existPerson.FirstName = request.FirstName;
                existPerson.LastName = request.LastName;
                existPerson.BirthDate = request.BirthDate;
                existPerson.JMBG = request.JMBG;

                context.Person.Add(existPerson);
                context.SaveChanges();
                return new CreatePersonResponse() { Person = existPerson };

            }
            else return null;
        }

        public CommonResponse Delete(int id)
        {
            var RemovePerson=context.Person.FirstOrDefault(x=>x.PersonId==id);
            context.Person.Remove(RemovePerson); context.SaveChanges();
            return new CommonResponse() { ObjectId = id,Message="Successfully removed!" };
        }

    }
}

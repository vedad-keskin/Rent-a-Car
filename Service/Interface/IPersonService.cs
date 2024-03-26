
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Responses.Person;
using RentACar.DataModels.Requests.Person;

namespace RentACar.Service.Interface
{
    public interface IPersonService
    {

        public List<Person> GetAll();
        public CreatePersonResponse CreateNewPerson(CreatePersonRequest request);
        public CreatePersonResponse Update(UpsertPresonRequest request);
        public CommonResponse Delete(int id);
    }
}

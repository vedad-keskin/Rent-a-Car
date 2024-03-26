using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Payments;
using RentACar.DataModels.Requests.Recensions;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{

    [ApiController]
    [Route("Controller")]
    public class PaymentsController:ControllerBase
    {
        public IPaymentsService Service { get; set; }
        public PaymentsController(IPaymentsService service)
        {
            this.Service = service;
        }

        [HttpGet("GetAllPayments")]
        public IActionResult GetAllPayments()
        {

            var response = Service.GetAllPayments();
            return Ok(response);
        }
        [HttpPost("CreateNewPayments")]
        public IActionResult CreateNewPayments(CreatePaymentsRequest request)
        {

            var response = Service.CreateNewPayment(request);
            return Ok(response);
        }

        [HttpPut("UpdatePayments")]
        public IActionResult UpdatePayments(UpsertPaymentsRequest request)
        {
            var response = Service.UpdatePayments(request);
            return Ok(response);
        }

        [HttpDelete("DeletePaymentsById")]
        public IActionResult Delete(int id)
        {
            var response = Service.DeletePayments(id);
            return Ok(response);
        }
    }
}


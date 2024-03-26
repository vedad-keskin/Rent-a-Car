namespace RentACar.DataModels.Responses
{
    public class CommonResponse
    {
        public int ObjectId { get; set; }
        public bool SuccessResponse { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

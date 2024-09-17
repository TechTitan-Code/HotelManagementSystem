namespace HotelManagementSystem.Dto.ResponseModel
{
    using Newtonsoft.Json;

    public class InitializePaymentResponseDto
    {
        [JsonProperty("authorization_url")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        [JsonProperty("reference")]
        public string TransactionReference { get; set; }
    }

    public class PaystackResponseDto<T>
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }

}

using Newtonsoft.Json;

namespace HTTPClientFactoryPractice.Dtos.Responses
{
    public class ListResponse<T> : BaseResponse<List<T>>
    {
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}

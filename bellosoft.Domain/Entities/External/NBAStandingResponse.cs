using bellosoft.Domain.Entities.Dtos;
using System.Text.Json.Serialization;

namespace bellosoft.Domain.Entities.External
{
    public class NBAStandingResponse
    {
        [JsonPropertyName("response")]
        public List<NBAStandingDto> Response { get; set; }
    }
}

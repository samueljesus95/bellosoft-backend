using bellosoft.Domain.Entities.Dtos;
using System.Text.Json.Serialization;

namespace bellosoft.Domain.Entities.External
{
    public class NBATeamResponse
    {
        [JsonPropertyName("response")]
        public List<NBATeamDto> Response { get; set; }
    }
}

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Compendium.Core.Models
{
    public class CampaignEntry
    {
        [JsonProperty("rawText")]
        public string? RawText { get; set; }

        [JsonProperty("rawPublic")]
        public string? RawPublic { get; set; }

        [JsonProperty("labels")]
        public List<string>? Labels { get; set; }

        [JsonProperty("tagSymbol")]
        public string? TagSymbol { get; set; }

        [JsonProperty("tagValue")]
        public string? TagValue { get; set; }
    }

    public class Original
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("revision")]
        public string? Revision { get; set; }

        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonProperty("updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }

    public class CampaignLogger
    {
        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("original")]
        public Original? Original { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty("campaignEntries")]
        public List<CampaignEntry>? CampaignEntries { get; set; }

        [JsonProperty("logs")]
        public List<Log>? Logs { get; set; }
    }

    public class Log
    {
        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("original")]
        public Original? Original { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty("logEntries")]
        public List<LogEntry>? LogEntries { get; set; }
    }


    public class LogEntry
    {
        [JsonProperty("rawText")]
        public string? RawText { get; set; }

        [JsonProperty("rawPrefix")]
        public string? RawPrefix { get; set; }

        [JsonProperty("rawSuffix")]
        public string? RawSuffix { get; set; }

        [JsonProperty("ordering")]
        public string? Ordering { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }

}

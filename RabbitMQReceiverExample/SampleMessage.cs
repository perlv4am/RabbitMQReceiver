using System;
using Newtonsoft.Json;

namespace RabbitMQReceiverExample
{
    public class SampleMessage
    {
        public SampleMessage(string type, int uuid, DateTime readySince, string resultPath)
        {
            this.Type = type;
            this.Uuid = uuid;
            this.ReadySince = readySince;
            this.ResultPath = resultPath;
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uuid")]
        public int Uuid { get; set; }

        [JsonProperty("readySince")]
        public DateTime ReadySince { get; set; }

        [JsonProperty("resultPath")]
        public string ResultPath { get; set; }

    }
}
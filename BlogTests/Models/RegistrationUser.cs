namespace BlogTests.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class RegistrationUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

    }
    public partial class RegistrationUser
    {
        public static RegistrationUser FromJson(string json) => JsonConvert.DeserializeObject<RegistrationUser>(json, BlogTests.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RegistrationUser self) => JsonConvert.SerializeObject(self, BlogTests.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


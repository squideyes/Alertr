using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alertr.Shared
{
    public class Incident
    {
        public static class Lengths
        {
            public static class ModuleName
            {
                public const int MinLength = 4;
                public const int MaxLength = 64;
            }
            
            public static class IncidentCode
            {
                public const int MinLength = 4;
                public const int MaxLength = 64;
            }

            public static class Message
            {
                public const int MinLength = 16;
                public const int MaxLength = 1024;
            }

            public static class ExtraInfo
            {
                public const int MaxLength = 6000;
            }
        }

        [Required]
        [Description("A pre-assigned GUID that identifies the client.")]
        public Guid? ClientKey { get; set; }

        [Required]
        [StringLength(Lengths.ModuleName.MaxLength, 
            MinimumLength = Lengths.ModuleName.MinLength)]
        [Description("The name of the client module that detected the incident.")]
        public string ModuleName { get; set; }

        [Required]
        [StringLength(Lengths.IncidentCode.MaxLength,
            MinimumLength = Lengths.IncidentCode.MinLength)]
        [Description("A client-generated incident-specific code.")]
        public string IncidentCode { get; set; }

        [Required]
        [IsDefinedEnum(typeof(Severity))]
        [Description("The initial Severity level of the incident.")]
        public Severity Severity { get; set; }

        [Required]
        [StringLength(Lengths.Message.MaxLength,
            MinimumLength = Lengths.Message.MinLength)]
        [Description("A short description of the problem that led to this alert.")]
        public string Message { get; set; }

        [Description("An arbitrary JSON object to include in the incident log.")]
        [StringLength(Lengths.ExtraInfo.MaxLength)]
        [IsJson]
        public string ExtraInfo { get; set; }
    }
}

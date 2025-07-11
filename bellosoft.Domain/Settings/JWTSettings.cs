﻿namespace bellosoft.Domain.Settings
{
    public class JWTSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public int ExpirationHours { get; set; }
    }
}

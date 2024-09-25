    internal record AuthenticationOptions(AuthSchemeOptions Schemes){
        public const string SectionName = "Authentication";
    }
    internal record AuthSchemeOptions(AuthJwtBearerOptions Bearer);
    internal record AuthJwtBearerOptions(string Issuer, string Audience, string AuthEndpoint, string MetadataAddress);
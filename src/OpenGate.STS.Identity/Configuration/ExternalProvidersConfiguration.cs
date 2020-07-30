namespace OpenGate.STS.Identity.Configuration
{
    public class ExternalProvidersConfiguration
    {
        public bool UseGitHubProvider { get; set; }
        public string GitHubClientId { get; set; }
        public string GitHubClientSecret { get; set; }
        public bool UseGoogleProvider { get; set; }
        public string GoogleClientId { get; set; }
        public string GoogleClientSecret { get; set; }
        public bool UseFacebookProvider { get; set; }
        public string FacebookAppId { get; set; }
        public string FacebookAppSecret { get; set; }
        public bool UseTwitterProvider { get; set; }
        public string TwitterClientId { get; set; }
        public string TwitterClientSecret { get; set; }
    }
}







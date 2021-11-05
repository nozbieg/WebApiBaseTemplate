namespace WebApi.Application.Features.VersionInfo.Queries
{
    public class VersionInfoDto
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string ApiCompatibilityVersion { get; set; }
        public string Autoupdate { get; set; }
        public string HashCode { get; set; }
        public string MinRequiredVersionMediqus { get; set; }
    }
}
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GabosNationalNode.Application.Features.VersionInfo.Queries
{
    public class GetVersionInfoQueryHandler : IRequestHandler<GetVersionInfoQuery, GetVersionInfoResponse>
    {
        public async Task<GetVersionInfoResponse> Handle(GetVersionInfoQuery request, CancellationToken cancellationToken)
        {
            var getVersionInfoResponse = new GetVersionInfoResponse();

            //Possible Validation Here
            if (getVersionInfoResponse.Success)
            {
                var hashResult = await Task<string>.Run(() =>
                {

                    var bytes = Encoding.UTF8.GetBytes(Assembly.GetExecutingAssembly().GetName().FullName);
                    string result;

                    using (var hash = SHA512.Create())
                    {
                        var hashedInputBytes = hash.ComputeHash(bytes);
                        var hashedInputStringBuilder = new StringBuilder(128);
                        foreach (var b in hashedInputBytes)
                        {
                            hashedInputStringBuilder.Append(b.ToString("X2"));
                        }

                        result = hashedInputStringBuilder.ToString();
                        return result;
                    }
                });

                var versionInfo = new VersionInfoDto()
                {
                    Name = Assembly.GetExecutingAssembly().GetName().Name,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    ApiCompatibilityVersion = "1",
                    Autoupdate = "No",
                    HashCode = hashResult,
                    MinRequiredVersionMediqus = "50.0",
                };
                getVersionInfoResponse.VersionInfo = versionInfo;
            }
            return getVersionInfoResponse;
        }
    }
}


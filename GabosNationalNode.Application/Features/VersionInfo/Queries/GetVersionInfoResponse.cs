using GabosNationalNode.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabosNationalNode.Application.Features.VersionInfo.Queries
{
   
    public class GetVersionInfoResponse : BaseResponse
    {
        public GetVersionInfoResponse() : base()
        {

        }

        public VersionInfoDto VersionInfo { get; set; }
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabosNationalNode.Application.Features.VersionInfo.Queries
{
    public class GetVersionInfoQuery : IRequest<GetVersionInfoResponse>
    {
    }
}

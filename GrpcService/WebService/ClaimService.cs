﻿
using GrpcService.InterfaceService;
using System.Security.Claims;

namespace GrpcService.WebService
{
    /*public class ClaimService:IClaimService
    {
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
        }
        public Guid  GetCurrentUserId { get; }
    }*/
}

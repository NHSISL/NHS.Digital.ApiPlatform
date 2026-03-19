// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Clients.CareIdentityService.Exceptions
{
    public class CareIdentityServiceClientDependencyException : Xeption
    {
        public CareIdentityServiceClientDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

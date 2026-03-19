// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Foundations.CareIdentityServices.Exceptions
{
    public class CareIdentityServiceDependencyException : Xeption
    {
        public CareIdentityServiceDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

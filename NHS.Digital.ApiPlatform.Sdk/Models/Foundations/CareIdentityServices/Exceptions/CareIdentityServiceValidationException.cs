// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Foundations.CareIdentityServices.Exceptions
{
    public class CareIdentityServiceValidationException : Xeption
    {
        public CareIdentityServiceValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Foundations.CareIdentityServices.Exceptions
{
    public class UnauthorisedCareIdentityServiceException : Xeption
    {
        public UnauthorisedCareIdentityServiceException(string message)
            : base(message)
        { }
    }
}

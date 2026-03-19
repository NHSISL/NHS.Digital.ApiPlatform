// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Processings.CareIdentityServices.Exceptions
{
    public class UnauthorisedCareIdentityServiceProcessingException : Xeption
    {
        public UnauthorisedCareIdentityServiceProcessingException(string message)
            : base(message)
        { }
    }
}

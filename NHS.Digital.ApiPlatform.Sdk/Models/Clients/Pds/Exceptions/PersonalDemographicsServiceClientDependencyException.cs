// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using Xeptions;

namespace NHS.Digital.ApiPlatform.Sdk.Models.Clients.Pds.Exceptions
{
    public class PersonalDemographicsServiceClientDependencyException : Xeption
    {
        public PersonalDemographicsServiceClientDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

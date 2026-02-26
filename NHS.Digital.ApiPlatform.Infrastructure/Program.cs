// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using NHS.Digital.ApiPlatform.Infrastructure.Services;

namespace NHS.Digital.ApiPlatform.Infrastructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scriptGenerationService = new ScriptGenerationService();

            scriptGenerationService.GenerateBuildScript(
                branchName: "main",
                projectName: "NHS.Digital.ApiPlatform.Sdk",
                dotNetVersion: "10.0.100");

            scriptGenerationService.GeneratePrLintScript(branchName: "main");
        }
    }
}

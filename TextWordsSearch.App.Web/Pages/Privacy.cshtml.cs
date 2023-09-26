//-----------------------------------------------------------------------
// <copyright file="Privacy.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.App.Web.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> privacyLogger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        this.privacyLogger = logger;
    }

    public void OnGet()
    {
    }
}

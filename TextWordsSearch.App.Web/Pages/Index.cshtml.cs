//-----------------------------------------------------------------------
// <copyright file="Index.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TextWordsSearch.App.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment currentEnvironment;
    private readonly string uploadsFolderName;

    public IndexModel(IWebHostEnvironment environment)
    {
        this.currentEnvironment = environment;

        this.uploadsFolderName = Path.Combine(this.currentEnvironment.WebRootPath, "uploads");
        if (Directory.Exists(this.uploadsFolderName) is false)
        {
            Directory.CreateDirectory(this.uploadsFolderName);
        }
    }

    [BindProperty]
    public IFormFile? Upload { get; set; }

    public void OnGet()
    {
        this.ViewData["Title"] = "TextWordsSearchTool";
    }

    public async Task OnPostUploadTextFileAsync()
    {
        if (this.ModelState.IsValid)
        {
            if (this.Upload is not null)
            {
                string uploadFilePath = Path.Combine(this.uploadsFolderName, this.Upload.FileName);

                using (FileStream fileStream = new (uploadFilePath, FileMode.Create))
                {
                    await this.Upload.CopyToAsync(fileStream);
                }

                if (System.IO.File.Exists(uploadFilePath))
                {
                    DataStore.ContentStringsFromTextFile = System.IO.File.ReadAllLines(uploadFilePath);
                }
            }
        }
    }
}

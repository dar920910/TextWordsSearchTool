using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWordsSearch.Library;

namespace TextWordsSearch.App.Web.Pages;

public class IndexModel : PageModel
{
    private IWebHostEnvironment _Environment;
    private readonly string _UploadsFolderName;

    public IndexModel(IWebHostEnvironment environment)
    {
        _Environment = environment;

        _UploadsFolderName = Path.Combine(_Environment.WebRootPath, "uploads");
        if (Directory.Exists(_UploadsFolderName) is false)
        {
            Directory.CreateDirectory(_UploadsFolderName);
        }
    }

    public void OnGet()
    {
        ViewData["Title"] = "TextWordsSearchTool";
    }

    [BindProperty]
    public IFormFile? Upload { get; set; }

    public async Task OnPostUploadTextFileAsync()
    {
        if (ModelState.IsValid)
        {
            if (Upload is not null)
            {
                string uploadFilePath = Path.Combine(_UploadsFolderName, Upload.FileName);

                using (FileStream fileStream = new(uploadFilePath, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                if (System.IO.File.Exists(uploadFilePath))
                {
                    DataStore.ContentStringsFromTextFile = System.IO.File.ReadAllLines(uploadFilePath);
                }
            }
        }
    }
}

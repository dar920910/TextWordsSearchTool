using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWordsSearch.Library;

namespace TextWordsSearch.App.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    [BindProperty]
    public string TargetText { get; set; }

    [BindProperty]
    public string TargetWord { get; set; }

    public uint WordCountInText { get; set; }

    public IActionResult OnPost()
    {
        WordCountInText = TextWordsCounter.GetWordCountInText(TargetWord, TargetText);
        return Page();
    }
}

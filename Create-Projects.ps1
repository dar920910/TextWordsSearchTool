Write-Host "`nStep 1: Creating a New Solution`n"

dotnet new sln
dotnet new gitignore


Write-Host "`nStep 2: Creating Projects from Templates`n"

dotnet new classlib --name "TextWordsSearch.Library" --framework "net6.0"
dotnet new nunit --name "TextWordsSearch.Testing" --framework "net6.0"
dotnet new console --name "TextWordsSearch.App.CLI" --framework "net6.0"
dotnet new webapp --name "TextWordsSearch.App.Web" --framework "net6.0"


Write-Host "`nStep 3: Adding References to Projects`n"

dotnet add "TextWordsSearch.Testing" reference "TextWordsSearch.Library"
dotnet add "TextWordsSearch.App.CLI" reference "TextWordsSearch.Library"
dotnet add "TextWordsSearch.App.Web" reference "TextWordsSearch.Library"


Write-Host "`nStep 4: Adding Projects to the Solution`n"

dotnet sln add "TextWordsSearch.Library"
dotnet sln add "TextWordsSearch.Testing"
dotnet sln add "TextWordsSearch.App.CLI"
dotnet sln add "TextWordsSearch.App.Web"


Write-Host "`nStep 5: Displaying Projects from the Solution`n"

dotnet sln list

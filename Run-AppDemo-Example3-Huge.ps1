$BUILD_DIRECTORY = "TextWordsSearch.App.CLI\bin\Debug\net6.0"
$EXECUTABLE = "TextWordsSearch.App.CLI.exe"

Write-Host "`n -> Executing the Program:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" "Examples/Example3_Huge.txt"
Write-Host "`n"

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/TextWordsSearchTool

COPY TextWordsSearch.Library/ TextWordsSearch.Library/
COPY TextWordsSearch.App.CLI/ TextWordsSearch.App.CLI/

RUN dotnet publish TextWordsSearch.App.CLI/TextWordsSearch.App.CLI.csproj --output "/usr/local/bin/TextWordsSearchTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained

WORKDIR /usr/local/bin/TextWordsSearchTool

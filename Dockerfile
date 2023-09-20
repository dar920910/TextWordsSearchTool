FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/TextWordsSearchTool

COPY TextWordsSearch.Library/ TextWordsSearch.Library/
COPY TextWordsSearch.Testing/ TextWordsSearch.Testing/
COPY TextWordsSearch.App.CLI/ TextWordsSearch.App.CLI/
COPY TextWordsSearch.App.Web/ TextWordsSearch.App.Web/

RUN dotnet publish TextWordsSearch.App.CLI/TextWordsSearch.App.CLI.csproj --output "/usr/local/bin/TextWordsSearchTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
RUN dotnet publish TextWordsSearch.App.Web/TextWordsSearch.App.Web.csproj --output "/usr/local/bin/TextWordsSearchTool/Web/" --configuration "Release" --use-current-runtime --no-self-contained

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_URLS="https://+;http://+" \
    ASPNETCORE_HTTPS_PORT=5002 \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/TextWordsSearch.pfx \
    ASPNETCORE_Kestrel__Certificates__Default__Password="Text_Words_Search_2023!"

WORKDIR /usr/local/bin/TextWordsSearchTool

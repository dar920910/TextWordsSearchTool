docker run --rm --interactive --tty --publish 5001:80 --publish 5002:443 --volume $env:USERPROFILE\.aspnet\https:/https/ text_words_search /bin/bash -c "cd /usr/local/bin/TextWordsSearchTool/Web/ && dotnet TextWordsSearch.App.Web.dll"
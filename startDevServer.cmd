:start
dotnet build SpengernewsProject.Webapi --no-incremental --force
dotnet watch run -c Debug --project SpengernewsProject.Webapi
goto start
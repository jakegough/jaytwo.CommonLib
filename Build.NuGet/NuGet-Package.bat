call NuGet-Settings.cmd

"%NUGET_EXE%" pack "%NUGET_PROJECT%" -Build -Properties Configuration=%NUGET_CONFIGURATION%

pause
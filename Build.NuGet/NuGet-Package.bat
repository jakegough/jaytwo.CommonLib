call NuGet-Settings.cmd

"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Clean
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Net35"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Net40"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Net45"

"%NUGET_EXE%" pack "%NUGET_PROJECT%" -Verbosity detailed -Build -Properties Configuration="Net40"

pause
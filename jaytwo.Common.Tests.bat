set nunit_path=%~dp0.\packages\NUnit.Runners.2.6.4\tools
set debug_test_binary_path=%~dp0.\CommonLib.Test\bin\Debug
set test_binary_dll=jaytwo.common.test.dll

start %nunit_path%\nunit.exe %debug_test_binary_path%\%test_binary_dll%
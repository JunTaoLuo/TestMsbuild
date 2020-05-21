Prereq:
1. Make sure dotnet is on the PATH
2. net5.0 TFM might need a preview SDK, feel free to change the TFM to something older such as netcoreapp3.1 or netcoreapp5.0

Run tests:

```
cd Tests
dotnet test
```

Sample result:

```
C:\gh\tp\TestMsbuild\Tests> dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  You are using a preview version of .NET. See: https://aka.ms/dotnet-core-preview
  Tests -> C:\gh\tp\TestMsbuild\Tests\bin\Debug\net5.0\Tests.dll
Test run for C:\gh\tp\TestMsbuild\Tests\bin\Debug\net5.0\Tests.dll(.NETCoreApp,Version=v5.0)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0-preview-20200429-01
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:03.42]     Tests.UnitTest1.FailingTest [FAIL]
  X Tests.UnitTest1.FailingTest [1s 318ms]
  Error Message:
   Assert.Equal() Failure
Expected: 0
Actual:   1
  Stack Trace:
     at Tests.UnitTest1.ProcessMsbuild(String args) in C:\gh\tp\TestMsbuild\Tests\UnitTest1.cs:line 71
   at Tests.UnitTest1.FailingTest() in C:\gh\tp\TestMsbuild\Tests\UnitTest1.cs:line 38
  Standard Output Messages:
 Microsoft (R) Build Engine version 16.7.0-preview-20257-02+b861333fc for .NET
 Copyright (C) Microsoft Corporation. All rights reserved.

   Determining projects to restore...
   All projects are up-to-date for restore.
   You are using a preview version of .NET. See: https://aka.ms/dotnet-core-preview
   TestApp -> C:\gh\tp\TestMsbuild\TestApp\bin\Debug\net5.0\TestApp.dll
 C:\gh\tp\TestMsbuild\TestApp\TestApp.csproj(23,5): error : ProtoCompile output not computed

 Build FAILED.

 C:\gh\tp\TestMsbuild\TestApp\TestApp.csproj(23,5): error : ProtoCompile output not computed
     0 Warning(s)
     1 Error(s)

 Time Elapsed 00:00:00.80



Test Run Failed.
Total tests: 3
     Passed: 2
     Failed: 1
 Total time: 5.4390 Seconds
C:\gh\aspnetcore\.dotnet\sdk\5.0.100-preview.5.20258.4\Microsoft.TestPlatform.targets(32,5): error MSB4181: The "Microsoft.TestPlatform.Build.Tasks.VSTestTask" task returned false but did not log an error. [C:\gh\tp\TestMsbuild\Tests\Tests.csproj]
```
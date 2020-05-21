using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class UnitTest1
    {

        private static readonly string TestAppPath = typeof(UnitTest1).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                .Single(a => a.Key == "TestAppPath")
                .Value;
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestManipulation1()
        {
            ProcessMsbuild("/p:VerifyManipulation1=true");
        }

        [Fact]
        public void TestManipulation2()
        {
            ProcessMsbuild("/p:VerifyManipulation2=true");
        }

        [Fact]
        public void FailingTest()
        {
            ProcessMsbuild("/p:VerifyManipulation2=true /p:EnableWriting=false");
        }


        private void ProcessMsbuild(string args)
        {
            using var process = new Process();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = $"build {TestAppPath} {args}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    _output.WriteLine(e.Data);
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    _output.WriteLine("Error: " + e.Data);
                }
            };

            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.WaitForExit();
            Assert.Equal(0, process.ExitCode);
        }
    }
}

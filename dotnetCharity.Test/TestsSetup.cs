using Microsoft.AspNetCore.Mvc.Testing;

using System.Diagnostics;



namespace dotnetCharity.Test;

[SetUpFixture]
public class TestsSetup {
    
    public TestsSetup(){
        
    }

    [OneTimeSetUp]
    public void StartTests(){

        Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void EndTests(){
            Trace.Flush();
        }
    }
        
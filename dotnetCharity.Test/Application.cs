using Microsoft.AspNetCore.Mvc.Testing;

using System.Diagnostics;



namespace dotnetCharity.Test;

[SetUpFixture]
public class Application : WebApplicationFactory<Program> {

    
    public Application(){
        
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
        
using System;
using System.Collections.Generic;
using Dev2.Common.Interfaces;
using Dev2.Runtime.ServiceModel.Data;

namespace Dev2.Data
{
    public class ServiceTestModelTO : IServiceTestModelTO
    {
        public string TestName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastRunDate { get; set; }
        public List<IServiceTestInput> Inputs { get; set; }
        public List<IServiceTestOutput> Outputs { get; set; }
        public bool NoErrorExpected { get; set; }
        public bool ErrorExpected { get; set; }
        public bool TestPassed { get; set; }
        public bool TestFailing { get; set; }
        public bool TestInvalid { get; set; }
        public bool TestPending { get; set; }
        public bool Enabled { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
    }
}
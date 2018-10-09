using System;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace SerilogLab.Model
{
    public class PFLogDetail
    {
        public string Path { get; set; }

        public long TimeLength { get; set; }
        
        public string HttpMethod { get; set; }
        
        public string Remark { get; set; }
        
        public DateTime StartTime { get; set; }
    }
}
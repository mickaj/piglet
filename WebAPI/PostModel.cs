using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class PostModel
    {
        public IList<string> SourceStrings { get; set; } = new List<string>();

        public IList<string> TargetStrings { get; set; } = new List<string>();

        public string ErrorMessage { get; set; }
    }
}

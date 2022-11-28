using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Emailer
{
   public partial class AttachmentStream
    {
        public string FileName { get; set; }
        public MemoryStream File { get; set; }
        public string Extranson  { get; set; }
        public string subExtranson { get; set; }
    }
}

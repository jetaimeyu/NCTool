using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCTool.Result
{
    public class CodeResult:BaseResult
    {
        public new CodeEntity Data;
    }
    public class CodeEntity
    {
        public string[] MdCodeList;
    }
}

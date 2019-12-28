using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCTool.Result
{
    public class ProdInfoResult:BaseResult
    {
        public new ProdInfoEntity Data;

    }
    public class ProdInfoEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProdID { set; get; }
        /// <summary>
        /// 产品名称    
        /// </summary>
        public string ProdName { set; get; }
        /// <summary>
        /// 型号ID
        /// </summary>
        public string SkuID { set; get; }
        /// <summary>
        /// 型号名称
        /// </summary>
        public string SkuName { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCTool.Result
{
    public class ProduceParamResult:BaseResult
    {
        public new List<ProduceParamEntity> Data;
    }
    public class ProduceParamEntity
    {
        public string CatalogID { set; get; }
        public string CatalogName { set; get; }
        public string IsDisabled { set; get; }
        public string IsPublic { set; get; }
        public string IsRequired { set; get; }
        public string ParamDefValue { set; get; }
        /// <summary>
        /// 参数ID
        /// </summary>
        public string ParamId { set; get; }
        /// <summary>
        /// 参数ID(post时用   与参数列表获取时大小写不一样)
        /// </summary>
        public string ParamID { set; get; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string ParamValue { set; get; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { set; get; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ParamType { set; get; }

     //  public string ParamsValues { set; get; }
        public string SortID { set; get; }

        public int ProduceID { set; get; }
    }
}

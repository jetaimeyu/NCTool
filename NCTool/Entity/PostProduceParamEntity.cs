using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCTool.Result;

namespace NCTool.Entity
{
    /// <summary>
    /// 打码数据保存
    /// </summary>
    public class PostProduceParamEntity
    {
        public string CompInCode { set; get; }
        public int PUserId { set; get; } = Common.user.UserID;
        public string CompInCodeMemo { set; get; } = "";
        public int Count { set; get; } = 1;
        public int InvalidUserId { set; get; } = 0;
        public string MadeIn { set; get; } = "";
        public int OutUserId { set; get; } = 0;
        public string Code { set; get; } = "01";
        public string State { set; get; } = "0";
        public int Type { set; get; } = 1;
        public int PrintType { set; get; } = 1;

        public new ProduceInfoEnttity produceInfo;

    }
    public class ProduceInfoEnttity
    {
        public string EqJane { set; get; } = "";
        public int ID { set; get; } = 0;
        public string MDCode { set; get; }
        public string ProdBatchNO { set; get; } = "";
        public string ProdID { set; get; }
        public string ProdInnerCode { set; get; }
        public string ProdName { set; get; }
        public string ProdOrderNO { set; get; } = "";
        public string ProduceDate { set; get; } = "";
        public string SkuID { set; get; }
        public string SkuName { set; get; }

        public int SkuType { set; get; } = 2;

        public new List<ProduceParamEntity> ProduceParams;

    }
}

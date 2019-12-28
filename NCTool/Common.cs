using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NCTool.Result;

namespace NCTool
{
    public class Common
    {

        public static UserModel user;
        public static string WebApi = ConfigurationManager.AppSettings["WebApi"];

        //领码接口
        public static string GetCodeUrl => WebApi + "/45/api/v1/MdCode/SavePrintOneForGBCode";

        //登录接口
        public static string ApiUrlLogin => WebApi + "/50/api/v1/User/Login";

        //通过型号名称获取产品ID/产品名称/型号ID/型号名称
        public static string GetProdInfoUrl => WebApi + "/50/api/v1/JJPurchasePkg/GetWlProdBySkuName? skuName = ";

        //打码保存接口
        public static string GetCodeSaveUrl => WebApi + "/45/api/V1.1/Produce/SavePrintInfoNew2";
        //http://api45.maidiyun.com/api/V1.1/Produce/GetProduceParamsForProdInfoNew?prodId=191223000188&_=1577324931065

        //获取生产参数接口
        public static string GetProduceParamUrl => WebApi + "/45/api/V1.1/Produce/GetProduceParamsForProdInfoNew?prodId=";
    }
}

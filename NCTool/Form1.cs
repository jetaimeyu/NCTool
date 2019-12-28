using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;
using NCTool.Entity;
using NCTool.Result;
using Newtonsoft.Json;

namespace NCTool
{


    public partial class Form1 : Form
    {
        private DataTable SourceDataFromCSV;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  GridView1.Columns("列名").ReadOnly = True      

        }

        /// <summary>
        /// 导入按钮点击赋值datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            string m_FileName = CSVHelper.GetCsvFile();
            if (File.Exists(m_FileName))
            {
                DataTable m_Data = CSVHelper.ReadCSV(m_FileName);
                SourceDataFromCSV = m_Data;
                dataGridView1.DataSource = m_Data;
            }
        }
        /// <summary>
        /// 点击导出选择文件位置并导出为csv文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            string m_Path = CSVHelper.GetCsvSavepath();
            if (CSVHelper.SaveCSV(SourceDataFromCSV, m_Path))
            {
                MessageBox.Show("导出完成");
            }
        }


        /// <summary>
        /// 物联码填充
        /// </summary>
        private void BindingCode_Click(object sender, EventArgs e)
        {
            try
            {
                InfoTextBox.Text = $"开始填充物联码\r\n" + InfoTextBox.Text;
                for (int i = 0; i < SourceDataFromCSV.Rows.Count; i++)
                {
                    string m_SkuName = SourceDataFromCSV.Rows[i]["参数1"].ToString();

                    //检查本行数据是否已填充物联码
                    if (!string.IsNullOrEmpty(SourceDataFromCSV.Rows[i]["物联码"].ToString()))
                    {
                        InfoTextBox.Text = $"型号{m_SkuName}物联码已填充\r\n" + InfoTextBox.Text;
                        continue;
                    }

                    //根据型号名称获取产品信息
                    string m_GetProdInfoUrl = Common.GetProdInfoUrl + m_SkuName;
                    m_GetProdInfoUrl = "http://192.168.1.51:8152/api/v1/JJPurchasePkg/GetWlProdBySkuName?skuName=2222";
                    ProdInfoResult m_ProdInfoResult = Http.Instance.HttpGet<ProdInfoResult>(m_GetProdInfoUrl, "", true);
                    if (m_ProdInfoResult.State != 1)
                    {
                        InfoTextBox.Text = $"未能找到型号{m_SkuName}的产品信息\r\n" + InfoTextBox.Text;
                        continue;
                    }

                    //获取物联码
                    string m_GetCodeUrl = Common.GetCodeUrl;
                    string code = "";
                    CodeResult result = Http.Instance.HttpGet<CodeResult>(m_GetCodeUrl, "", true);
                    if (result.State == 1 && result.Data.MdCodeList.Length > 0)
                    {
                        code = result.Data.MdCodeList[0];
                    }
                    else
                    {
                        InfoTextBox.Text = $"为型号：{m_SkuName}领取物联码失败\r\n" + InfoTextBox.Text;
                        continue;
                    }

                    //http://api45.maidiyun.com/api/V1.1/Produce/GetProduceParamsForProdInfoNew?prodId=191223000188&_=1577324931065
                    //根据产品ID获取生产参数
                    string m_GetProduceParamUrl = Common.GetProduceParamUrl + m_ProdInfoResult.Data.ProdID;
                    List<ProduceParamEntity> m_ProduceParamsInfo = new List<ProduceParamEntity>();
                    ProduceParamResult ProduceParamResult = Http.Instance.HttpGet<ProduceParamResult>(m_GetProduceParamUrl, "", true);
                    if (ProduceParamResult.State == 1 && ProduceParamResult.Data.Count > 0)
                    {
                        //循环给生产参数赋值
                        m_ProduceParamsInfo = GetPostProduceInfo(ProduceParamResult.Data, SourceDataFromCSV.Rows[i]);
                    }
                    else
                    {
                        InfoTextBox.Text = $"未获取到到型号：{m_SkuName}的生产参数\r\n" + InfoTextBox.Text;
                        continue;
                    }

                    //获取生产参数
                    ProduceInfoEnttity m_ProduceInfo = new ProduceInfoEnttity();
                    m_ProduceInfo.ProduceParams = m_ProduceParamsInfo;
                    m_ProduceInfo.MDCode = code;
                    m_ProduceInfo.ProdID = m_ProdInfoResult.Data.ProdID;
                    m_ProduceInfo.SkuID = m_ProdInfoResult.Data.SkuID;
                    m_ProduceInfo.ProdName = m_ProdInfoResult.Data.ProdName;
                    m_ProduceInfo.SkuName = m_ProdInfoResult.Data.SkuName;
                    m_ProduceInfo.ProdInnerCode = SourceDataFromCSV.Rows[i]["参数1"].ToString();

                    //拼接post数据
                    PostProduceParamEntity m_PostData = new PostProduceParamEntity();
                    m_PostData.CompInCode = SourceDataFromCSV.Rows[i]["参数1"].ToString();
                    m_PostData.PUserId = Common.user.UserID;
                    m_PostData.produceInfo = m_ProduceInfo;

                    //保存产品与物联码至保存打码数据接口
                    string m_SaveCodeAndProdUrl = Common.GetCodeSaveUrl;
                    BaseResult m_SaveResult = Http.Instance.HttpPost<BaseResult>(m_SaveCodeAndProdUrl, JsonConvert.SerializeObject(m_PostData), true);
                    //保存打码记录成功将物联码赋值给datagridview
                    if (m_SaveResult.State==1)
                    {
                        //将物联码赋值给datagridView
                        SourceDataFromCSV.Rows[i]["物联码"] ="https://m.maidiyun.com/?" + code;
                        dataGridView1.DataSource = SourceDataFromCSV;
                    }
                    else
                    {
                        InfoTextBox.Text = $"为型号{m_SkuName}保存打码记录失败\r\n" + InfoTextBox.Text;
                        continue;
                    }
                }

                InfoTextBox.Text = $"填充物联码结束\r\n" + InfoTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        /// <summary>
        /// 循环赋值生产参数POST参数值
        /// </summary>
        /// <param name="p_ProduceList"></param>
        /// <returns></returns>
        public List<ProduceParamEntity> GetPostProduceInfo(List<ProduceParamEntity> p_ProduceList, DataRow p_RowData)
        {
            try
            {
                List<ProduceParamEntity> m_PostProduceList = new List<ProduceParamEntity>();
                foreach (var item in p_ProduceList)
                {
                    ProduceParamEntity m_ProduceItem = new ProduceParamEntity();
                    m_ProduceItem.CatalogID = item.CatalogID;
                    m_ProduceItem.CatalogName = item.CatalogName;
                    m_ProduceItem.ParamName = item.ParamName;
                    m_ProduceItem.IsPublic = item.IsPublic;
                    m_ProduceItem.ParamID = item.ParamId;
                    m_ProduceItem.ProduceID = 0;
                    m_ProduceItem.SortID = item.SortID;
                    switch (item.ParamName)
                    {
                        case "批次号":
                            m_ProduceItem.ParamValue = p_RowData["参数1"].ToString();
                            break;
                        case "参数2":
                            m_ProduceItem.ParamValue = p_RowData["参数2"].ToString();
                            break;
                        case "参数3":
                            m_ProduceItem.ParamValue = p_RowData["参数3"].ToString();
                            break;
                        case "参数4":
                            m_ProduceItem.ParamValue = p_RowData["参数4"].ToString();
                            break;
                        case "参数5":
                            m_ProduceItem.ParamValue = p_RowData["参数5"].ToString();
                            break;
                        case "参数6":
                            m_ProduceItem.ParamValue = p_RowData["参数6"].ToString();
                            break;
                        case "参数7":
                            m_ProduceItem.ParamValue = p_RowData["参数7"].ToString();
                            break;
                    }
                    m_PostProduceList.Add(m_ProduceItem);
                }
                return m_PostProduceList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

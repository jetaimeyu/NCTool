using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NCTool
{
    public class CSVHelper
    {
       
        public static bool SaveCSV(DataTable p_Dt, string p_FullPath)
        {
            try
            {
                FileInfo fi = new FileInfo(p_FullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(p_FullPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                string _bufferLine = "";
                for (int i = 0; i < p_Dt.Rows.Count; i++)
                {
                    _bufferLine = "";
                    for (int j = 0; j < p_Dt.Columns.Count; j++)
                    {
                        if (j > 0)
                            _bufferLine += ",";
                        _bufferLine += p_Dt.Rows[i][j].ToString();
                    }
                    sw.WriteLine(_bufferLine);
                }
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
 
        /// <summary>
        /// 读取csv文件
        /// </summary>
        /// <param name="FileStream"></param>
        /// <returns></returns>
        public static DataTable ReadCSV(string FileStream)
        {
            DataTable dt = new DataTable();
          
            FileStream fs = new FileStream(FileStream, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            //记录每次读取的一行记录
            string strLine = null;
            //记录每行记录中的各字段内容
            string[] arrayLine = null;
            //分隔符
            //  string[] separators = { "\t" };
            //判断，若是第一次，建立表头
            bool isFirst = true;
            //逐行读取CSV文件
            while ((strLine = sr.ReadLine()) != null)
            {
                strLine = strLine.Trim();
                arrayLine = strLine.Split('\t');
                int dtColumns = arrayLine.Length;//列的个数
                if (isFirst)
                {
                    for (int i = 0; i < dtColumns; i++)
                    {
                        dt.Columns.Add($"参数{i + 1}");//每一列名称
                    }
                    dt.Columns.Add("物联码");//额外添加一列 用于存放Ecode
                    DataRow dataRow = dt.NewRow();//新建一行
                    for (int j = 0; j < dtColumns; j++)
                    {
                        dataRow[j] = arrayLine[j];
                    }
                    dt.Rows.Add(dataRow);//添加一行
                    isFirst = false;
                }
                else//表内容
                {
                    DataRow dataRow = dt.NewRow();//新建一行
                    for (int j = 0; j < dtColumns; j++)
                    {
                        dataRow[j] = arrayLine[j];
                    }
                    dt.Rows.Add(dataRow);//添加一行
                }
            }
            sr.Close();
            fs.Close();
            return dt;
        }

        /// <summary>
        /// 文件夹内选择CSV文件
        /// </summary>
        /// <returns></returns>
        public static string GetCsvFile()
        {
            try
            {
                string m_FilePath = string.Empty;
                OpenFileDialog m_DlgOpenFile = new OpenFileDialog();
                m_DlgOpenFile.Title = "FileName";
                //m_DlgOpenFile.InitialDirectory = @"桌面";
                m_DlgOpenFile.Filter = ".csv|*.csv";
                m_DlgOpenFile.FilterIndex = 1;
                DialogResult m_Dr = m_DlgOpenFile.ShowDialog();
                m_FilePath = m_Dr == DialogResult.OK ? m_DlgOpenFile.FileName : "";
                return m_FilePath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 选择文件保存路径
        /// </summary>
        /// <returns></returns>
        public static string GetCsvSavepath()
        {
            try
            {
                string localFilePath = "";
                //string localFilePath, fileNameExt, newFileName, FilePath; 
                SaveFileDialog sfd = new SaveFileDialog();
                //设置文件类型 
                sfd.Filter = "Excel表格（*.csv）|*.csv";

                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;

                //点了保存按钮进入 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                    //获取文件路径，不带文件名 
                    //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                    //给文件名前加上时间 
                    //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                    //在文件名里加字符 
                    //saveFileDialog1.FileName.Insert(1,"dameng"); 

                    //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                    ////fs输出带文字或图片的文件，就看需求了 
                }

                return localFilePath;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

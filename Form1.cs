using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Net;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DTFrom.MaxDate = DateTime.Now.AddMonths(-1);
            DTFrom.MinDate = DateTime.Now.AddMonths(-1);
        }

        private void Btn6MthRate_Click(object sender, EventArgs e)
        {
            string strDTFrom;

            strDTFrom = Convert.ToDateTime(DTFrom.Text).ToString("yyyy-MM");
                        
            string URL = @"https://eservices.mas.gov.sg/api/action/datastore/search.json?resource_id=5f2b18a8-0883-4769-a635-879c63d3caac&filters[end_of_month]=" + strDTFrom + "";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            WebRequest request = WebRequest.Create(URL);
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            int startIndex = responseFromServer.IndexOf("records");
            startIndex = startIndex + 9;
            int NoOfchars = responseFromServer.Length - (startIndex);
            string stringToShow = responseFromServer.Substring(startIndex, NoOfchars);
            DataTable dt = JsonStringToDataTable(stringToShow);
            GridView1.DataSource = dt;
        }

        public DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData + ex.Message.ToString()));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strDTFrom, strDTTo;

            strDTFrom = Convert.ToDateTime(DTFrom.Text).AddMonths(-10).ToString("yyyy-MM");
            strDTTo = Convert.ToDateTime(DTFrom.Text).ToString("yyyy-MM");
            string URL = @"https://eservices.mas.gov.sg/api/action/datastore/search.json?resource_id=5f2b18a8-0883-4769-a635-879c63d3caac&limit=10&between[end_of_month]="+strDTFrom+","+strDTTo+"";
            ServicePointManager.Expect100Continue = true;
            
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            WebRequest request = WebRequest.Create(URL);
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            int startIndex = responseFromServer.IndexOf("records");
            startIndex = startIndex + 9;
            int NoOfchars = responseFromServer.Length - (startIndex);
            string stringToShow = responseFromServer.Substring(startIndex, NoOfchars);
            DataTable dt = JsonStringToDataTable(stringToShow);
            GridView1.DataSource = dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using System.Collections;
using System.Web.Script.Serialization;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class frmTranslater : Form
    {
        public frmTranslater()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = TranslateText(textBoxInput.Text);
        }

        public string TranslateText(string input)
        {
            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "EN", "MR", Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;

            // Get all json data
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);

            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;
        }

        private void frmTranslater_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("LanguageName", typeof(string)), new DataColumn("ISOCode", typeof(string)) });
            dt.Rows.Add("Hindi", "HI");
            dt.Rows.Add("English", "EN");
            ddlSource.DataSource = dt;
            ddlSource.ValueMember = "ISOCode";
            ddlSource.DisplayMember = "LanguageName";

            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[] { new DataColumn("LanguageName", typeof(string)), new DataColumn("ISOCode", typeof(string)) });
            dt1.Rows.Add("Hindi", "HI");
            dt1.Rows.Add("English", "EN");
            dt1.Rows.Add("Marathi", "MR");
            dt1.Rows.Add("Gujarati", "GU");

            ddlTarget.DataSource = dt1;
            ddlTarget.ValueMember = "ISOCode";
            ddlTarget.DisplayMember = "LanguageName";
        }
        private void buttonOk1_Click(object sender, EventArgs e)
        {
            string url = "https://translation.googleapis.com/language/translate/v2?key=API Key";
            url += "&source=" + ddlSource.SelectedValue;
            url += "&target=" + ddlTarget.SelectedValue;
            url += "&q=" + Uri.EscapeUriString(textBoxInput.Text);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
            textBoxOutput.Text = jsonData.Data.Translations[0].TranslatedText;
        }
        public class JsonData
        {
            public Data Data { get; set; }
        }
        public class Data
        {
            public List<Translation> Translations { get; set; }
        }
        public class Translation
        {
            public string TranslatedText { get; set; }
        }
    }
}

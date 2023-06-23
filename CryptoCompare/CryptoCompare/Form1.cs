using binance_0._1;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CryptoCompare
{
    public partial class Form1 : Form
    {
        private bool toJson = false;
        private bool toXml = false;
        private bool toDatabase = false;
        public Form1()
        {
            InitializeComponent();

        }

        public static DateTime ConvertToDateTime(double time)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(time).ToLocalTime();
            return dateTime;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DownloadFinishedLabel.Text = "Data downloading";
            await Program.DownloadData(toJson, toXml, toDatabase);
            DownloadFinishedLabel.Text = "Data downloaded";
            if (Program.newsList != null)
            {
                foreach (var news in Program.newsList)
                {
                    listView1.Items.Add(news.PublishedAt + "   " + news.Title);
                }
            }
            foreach (var token in Program.tokens)
            {
                listBox1.Items.Add(token);
            }
        }

        private void LoadChart(string token)
        {
            chart1.Series.Clear();
            chart1.Series.Add(token);
            //chart1.Series[token].XValueType = ChartValueType.DateTime;
            chart1.Series[token].ChartType = SeriesChartType.Line;
            if (Program.data.ContainsKey(token))
            {
                foreach (var item in Program.data[token])
                {
                    chart1.Series[token].Points.AddXY(ConvertToDateTime(item.Time), item.Open);
                    chart1.Series[token].Points.AddXY(ConvertToDateTime(item.Time), item.Close);
                }
            }

            /*
            chart1.Series.Clear();
            int i = 0;
            foreach (var news in Program.newsList)
            {
                i++;
                chart1.Series.Add(news.Title);
                chart1.Series[news.Title].XValueType = ChartValueType.DateTime;
                chart1.Series[news.Title].Points.AddXY(news.PublishedAt, i);
                chart1.Series[news.Title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            }
            */
        }

        private void DownloadFinishedLabel_Click(object sender, EventArgs e)
        {

        }

        private void xmlCheck_CheckedChanged(object sender, EventArgs e)
        {
            toXml = !toXml;
        }

        private void jsonCheck_CheckedChanged(object sender, EventArgs e)
        {
            toJson = !toJson;
        }

        private void databaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            toDatabase = !toDatabase;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedItem.ToString();
            LoadChart(listBox1.SelectedItem.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

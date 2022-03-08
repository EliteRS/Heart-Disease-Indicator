using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace BackpropagationActivity
{
    public partial class Form1 : Form
    {
        NeuralNet bp;
        CsvData csvData;
        public Form1()
        {
            InitializeComponent();
            csvData = new CsvData();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bp = new NeuralNet(9, 5, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<HeartDisease> data = csvData.getRecords();
            for (int i = 0; i < 1000; i++)
            {
                foreach(var d in data)
                {
                    bp.setInputs(0, d.Highbp);
                    bp.setInputs(1, d.Highcol);
                    bp.setInputs(2, d.Colcheck);
                    bp.setInputs(3, d.Bmi);
                    bp.setInputs(4, d.Smoker);
                    bp.setInputs(5, d.Stroke);
                    bp.setInputs(6, d.Diabetes);
                    bp.setInputs(7, d.PhysActivity);
                    bp.setInputs(8, d.Fruits);

                    bp.setDesiredOutput(0, d.Heart_Disease);
                    bp.learn();
                    
                }
            }
            System.Windows.Forms.MessageBox.Show("Training Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.loadWeights(openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double Highbp = Convert.ToDouble(textBox1.Text);
            double Highcol = Convert.ToDouble(textBox2.Text);
            double Colcheck = Convert.ToDouble(textBox3.Text);
            double Bmi = Convert.ToDouble(textBox4.Text);
            double Smoker = Convert.ToDouble(textBox5.Text);
            double Stroke = Convert.ToDouble(textBox6.Text);
            double Diabetes = Convert.ToDouble(textBox7.Text);
            double PhysActivity = Convert.ToDouble(textBox8.Text);
            double Fruits = Convert.ToDouble(textBox9.Text);

            bp.setInputs(0, Highbp);
            bp.setInputs(1, Highcol);
            bp.setInputs(2, Colcheck);
            bp.setInputs(3, Bmi);
            bp.setInputs(4, Smoker);
            bp.setInputs(5, Stroke);
            bp.setInputs(6, Diabetes);
            bp.setInputs(7, PhysActivity);
            bp.setInputs(8, Fruits);
            bp.run();

            textBox10.Text = "" + bp.getOuputData(0);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.saveWeights(saveFileDialog1.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

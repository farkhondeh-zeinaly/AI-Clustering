using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResoveDataset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> types = new Dictionary<string, int>();
            types.Add("Bank", 0);
            types.Add("AutomobileIndustry", 1);
            types.Add("BpoIndustry", 2);
            types.Add("CementIndustry", 3);
            types.Add("Farmers1", 4);
            types.Add("Farmers2", 5);
            types.Add("HealthCareResources", 6);
            types.Add("TextileIndustry", 7);
            types.Add("PoultryIndustry", 8);
            types.Add("Residential(individual)", 9);
            types.Add("Residential(Apartments)", 10);
            types.Add("FoodIndustry", 11);
            types.Add("ChemicalIndustry", 12);
            types.Add("Handlooms", 13);
            types.Add("FertilizerIndustry", 14);
            types.Add("Hostel", 15);
            types.Add("Hospital", 16);
            types.Add("Supermarket", 17);
            types.Add("Theatre", 18);
            types.Add("University", 19);

            List<string> selectedTrans = new List<string>();
            Random rand = new Random();
            var allTrans = File.ReadAllLines(@"E:\Projects\Farkhondeh Projects\Clustering\Clustering Dataset - Copy.arff");
            for (int i = 0; i < allTrans.Length; i++)
            {
                int camma3 = 0;
                int camma = 0;
                while (camma3 < 3)
                {
                    camma = allTrans[i].IndexOf(',', camma + 1);
                    camma3++;
                }

                //allTrans[i] = allTrans[i].Remove(camma);
                //var tranType = allTrans[i].Substring(allTrans[i].LastIndexOf(',') + 1, allTrans[i].Length - allTrans[i].LastIndexOf(',') - 1);
                //allTrans[i] = allTrans[i].Replace(tranType, types[tranType].ToString());

                string currentTran = allTrans[i].Remove(camma);
                var tranType = currentTran.Substring(currentTran.LastIndexOf(',') + 1, currentTran.Length - currentTran.LastIndexOf(',') - 1);
                currentTran = currentTran.Replace(tranType, types[tranType].ToString());

                var rnd = rand.NextDouble();
                if (rnd > .98)
                {
                    selectedTrans.Add(currentTran);
                }
            }

            File.WriteAllLines(@"E:\Projects\Farkhondeh Projects\Clustering\Clustering Dataset Resolved.arff", selectedTrans.ToArray()); //allTrans);
        }
    }
}

using AnalyticHierarchyProcess.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalyticHierarchyProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AHP myAHP = AHP.Instance;
            List<string> alternatives = new List<string>();
            alternatives.Add("mBank");
            alternatives.Add("Bank Milenium");
            alternatives.Add("Bank BPH");
            List<string> criteria = new List<string>();
            criteria.Add("Sieć placówek");
            criteria.Add("Oprocentowanie kredytu");
            criteria.Add("Opłaty");
            criteria.Add("Sieć bankomatów");
            criteria.Add("Okres nieoprocentowanego kredytu");
            myAHP.PrepareDataStructure(criteria, alternatives);
            double[][] CriteriaMatrixOfPairwiseComparison = new double[][] {
                new double[] { 1, 1.0 / 7.0, 1.0 / 3.0, 3, 1.0 / 5.0},
                new double[] { 7, 1, 5, 9, 3 },
                new double[] { 3, 1.0 / 5.0, 1, 5, 1.0 / 3.0 },
                new double[] { 1.0 / 3.0, 1.0 / 9.0 , 1.0 / 5.0, 1, 1.0/7.0 },
                new double[] { 5, 1.0 / 3.0, 3, 7, 1 }
            };
            try
            {
                ValidateValues.Check(CriteriaMatrixOfPairwiseComparison);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(-1);
            }
            finally
            {
                myAHP.SetCriteriaPairwiseValues(CriteriaMatrixOfPairwiseComparison);
                myAHP.ComputeCriteriaCoeffs();
                textBox1.Text = myAHP.Criteria[0].Coeff.ToString();
                textBox2.Text = myAHP.Criteria[0].PairwiseValues[1].ToString();
            }
        }
    }
}

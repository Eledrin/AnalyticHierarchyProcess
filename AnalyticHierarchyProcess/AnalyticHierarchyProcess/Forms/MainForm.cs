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
            double[][] k1 = new double[][] {
                new double[] {1.0, 1.0 / 3.0, 1.0 / 5.0},
                new double[] {1.0, 1.0 / 3.0, 1.0 / 5.0 },
                new double[] {5.0, 3.0, 1.0}
            };
            double[][] k2 = new double[][] {
                new double[] {1.0, 1.0 / 3.0, 3.0},
                new double[] {3.0, 1.0, 5.0 },
                new double[] {1.0 / 3.0, 1.0 / 5.0, 1.0}
            };
            double[][] k3 = new double[][] {
                new double[] {1.0, 1.0 / 3.0, 3.0},
                new double[] {3.0, 1.0, 7.0 },
                new double[] {1.0 / 3.0, 1.0 / 7.0, 1.0}
            };
            double[][] k4 = new double[][] {
                new double[] {1.0, 1.0 / 7.0, 1.0 / 3.0},
                new double[] {7.0, 1.0, 5.0 },
                new double[] {3.0, 1.0 / 5.0, 1.0}
            };
            double[][] k5 = new double[][] {
                new double[] {1.0, 3.0, 1.0 / 5.0},
                new double[] {1.0 / 3.0, 1.0, 1.0 / 7.0 },
                new double[] {5.0, 7.0, 1.0}
            };
            try
            {
                ValidateValues.Check(CriteriaMatrixOfPairwiseComparison);
                ValidateValues.Check(k1);
                ValidateValues.Check(k2);
                ValidateValues.Check(k3);
                ValidateValues.Check(k4);
                ValidateValues.Check(k5);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(-1);
            }
            finally
            {
                myAHP.SetCriteriaPairwiseValues(CriteriaMatrixOfPairwiseComparison);
                myAHP.Criteria[0].SetAlternativesPairwiseValues(k1);
                myAHP.Criteria[1].SetAlternativesPairwiseValues(k2);
                myAHP.Criteria[2].SetAlternativesPairwiseValues(k3);
                myAHP.Criteria[3].SetAlternativesPairwiseValues(k4);
                myAHP.Criteria[4].SetAlternativesPairwiseValues(k5);
                myAHP.ComputeEvaluationOfAlternatives();
                textBox1.Text = myAHP.GetNameOfBestAlternative();
                textBox2.Text = myAHP.GetEvaluationOfBestAlternative().ToString();
            }
        }
    }
}

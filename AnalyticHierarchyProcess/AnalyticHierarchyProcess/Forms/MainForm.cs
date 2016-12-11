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
            criteria.Add("Sień bankomatów");
            criteria.Add("Okres nieoprocentowanego kredytu");
            myAHP.prepareDataStructure(criteria, alternatives);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fernandez_IT201NS_LABACT3CDBS_MIDTERM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Budget.Clear();
            Cost.Clear();
            Import.Clear();
            Urg.SelectedIndex = -1;
            Risk.SelectedIndex = -1;
            aff.Text = "Affordability";
            Decision.Text = "Decision";
        }

        private void Eval_Click(object sender, EventArgs e)
        {
            if (IsEmpty(txtBudget.Text) || IsEmpty(txtCost.Text) || IsEmpty(txtImportance.Text))
            {
                MessageBox.Show("Please fill everything!");
                return;
            }

            double budget = double.Parse(Budget.Text);
            double cost = double.Parse(Cost.Text);
            int importance = int.Parse(Import.Text);

            string afford = aff(budget, cost);
            double score = ComputePriority(importance, cmbUrgency.Text);
            string risk = EvaluateRisk(cmbRisk.Text);
            string decision = GenerateDecision(afford, score, risk);
            string explain = GenerateExplanation(decision);

            DisplayResult(afford, decision, explain);
        }
    }
}

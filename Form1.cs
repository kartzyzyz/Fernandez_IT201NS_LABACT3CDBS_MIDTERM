using System;
using System.Windows.Forms;

namespace Fernandez_IT201NS_LABACT3CDBS_MIDTERM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }

        private string CheckAffordability(double budget, double cost)
        {
            if (cost <= budget * 0.6)
                return "Affordable";
            else if (cost <= budget)
                return "Critical";
            else
                return "Not Affordable";
        }


        private int ComputePriority(int importance, string urgency)
        {
            int weight = urgency == "High" ? 5 : urgency == "Medium" ? 3 : 1;
            return importance * weight;
        }


        private string EvaluateRisk(string risk)
        {
            if (risk == "Low") return "Safe";
            if (risk == "Medium") return "Moderate";
            return "High Risk";
        }

        private string GenerateDecision(string afford, int score, string risk)
        {
            if (afford == "Not Affordable") return "Not Recommended";
            if (afford == "Affordable" && score >= 30 && risk == "Safe") return "Safe";
            if (risk == "High Risk" || afford == "Critical") return "Think about it first!";
            return "Proceed with Caution";
        }

        private string GenerateExplanation(string decision)
        {
            if (decision == "Proceed Immediately") return "Proceed.";
            if (decision == "Proceed with Caution") return "Be cautious.";
            if (decision == "Delay Decision") return "Have some time to think about it carefully.";
            return "The cost exceeds the budget.";
        }

        private void DisplayResult(string afford, string decision, string explanation)
        {
            aff.Text = "Affordability: " + afford;
            Decision.Text = "Decision: " + decision;
            MessageBox.Show("Explanation:\n\n" + explanation, "Result");
        }

        private void ResetForm()
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
            if (IsEmpty(Budget.Text) || IsEmpty(Cost.Text) || IsEmpty(Import.Text))
            {
                MessageBox.Show("Please fill all the needed information."); return;
            }
            if (!IsNumeric(Budget.Text) || !IsNumeric(Cost.Text) || !IsNumeric(Import.Text))
            {
                MessageBox.Show("Budget, Cost, and Importance should all be numerals!"); return;
            }
            if (Urg.SelectedIndex == -1 || Risk.SelectedIndex == -1)
            {
                MessageBox.Show("Please select how urgent and how risky it is!"); return;
            }

            double budget = double.Parse(Budget.Text);
            double cost = double.Parse(Cost.Text);
            int importance = int.Parse(Import.Text);

            string afford = CheckAffordability(budget, cost);
            int score = ComputePriority(importance, Urg.SelectedItem.ToString());
            string risk = EvaluateRisk(Risk.SelectedItem.ToString());
            string decision = GenerateDecision(afford, score, risk);
            string explain = GenerateExplanation(decision);

            DisplayResult(afford, decision, explain);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }


        private void Budget_TextChanged(object sender, EventArgs e) { }
        private void Cost_TextChanged(object sender, EventArgs e) { }
        private void Import_TextChanged(object sender, EventArgs e) { }
        private void Risk_SelectedIndexChanged(object sender, EventArgs e) { }
        private void aff_Click(object sender, EventArgs e) { }
        private void Decision_Click(object sender, EventArgs e) { }
        private void lblBudget_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
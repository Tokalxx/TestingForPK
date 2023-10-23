namespace TestingForPK
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> Group14 = new Dictionary<string, string>();
        Dictionary<string, string> AnswerDic = new Dictionary<string, string>();
        Random ran = new Random();
        int TempNumScore = 0;
        bool check1 = true;

        public Form1()
        {
            InitializeComponent();

            Group14.Add("PK", "Sound of Depression");
            Group14.Add("Simphiwe", "Wizard of Hearts");
            Group14.Add("Siya", "Nightmare of HR");
            Group14.Add("Nhlanhla", "Myth of Standards");
            Group14.Add("Samir", "Defier of Odds");
            Group14.Add("Sean", "Beast of Gevaudan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            TempNumScore = 0;
            panel2.Controls.Clear();
            AnswerDic.Clear();

            if (check1)
            {
                Gen1();
                check1 = false;
            }
            else
            {
                Gen2();
                check1 = true;
            }
        }

        private void Gen1()
        {
            List<string> callNumbers = Group14.Keys.ToList();
            List<string> calDescription = Group14.Values.ToList();

            int labelY1 = 0; // Initialize the Y coordinate for the first label
            int labelY2 = 0; // Initialize the Y coordinate for the first label

            foreach (string x in callNumbers)
            {
                Label callLabel = new Label
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    Font = new System.Drawing.Font("Arial", 12),
                    Width = 100,
                    Height = 30,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Set the location (X, Y) for the label
                callLabel.Location = new Point(0, labelY1);

                callLabel.Click += CallLabel_Click;
                panel1.Controls.Add(callLabel);

                // Adjust the Y coordinate for the next label
                labelY1 += callLabel.Height + 10; // You can adjust the spacing as needed
            }
            foreach (string x in calDescription.OrderBy(r => ran.Next()))
            {


                Label definitionTextBlock = new Label
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    Font = new System.Drawing.Font("Arial", 12),
                    Width = 300,
                    Height = 30,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                definitionTextBlock.Location = new Point(0, labelY2);

                panel2.Controls.Add(definitionTextBlock);

                // Adjust the Y coordinate for the next label
                labelY2 += definitionTextBlock.Height + 10;
                definitionTextBlock.Click += Definition_MouseLeftButtonClick;

                panel2.Controls.Add(definitionTextBlock);

            }
        }

        private void Gen2()
        {
            List<string> callNumbers = Group14.Keys.ToList();
            List<string> calDescription = Group14.Values.ToList();

            int labelY1 = 0; // Initialize the Y coordinate for the first label
            int labelY2 = 0; // Initialize the Y coordinate for the first label

            foreach (string x in callNumbers)
            {
                Label callLabel = new Label
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    Font = new System.Drawing.Font("Arial", 12),
                    Width = 100,
                    Height = 30,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Set the location (X, Y) for the label
                callLabel.Location = new Point(0, labelY1);

                callLabel.Click += Definition_MouseLeftButtonClick;
                panel2.Controls.Add(callLabel);

                // Adjust the Y coordinate for the next label
                labelY1 += callLabel.Height + 10; // You can adjust the spacing as needed
            }
            foreach (string x in calDescription.OrderBy(r => ran.Next()))
            {


                Label definitionTextBlock = new Label
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    Font = new System.Drawing.Font("Arial", 12),
                    Width = 300,
                    Height = 30,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                definitionTextBlock.Location = new Point(0, labelY2);

                panel1.Controls.Add(definitionTextBlock);

                // Adjust the Y coordinate for the next label
                labelY2 += definitionTextBlock.Height + 10;
                definitionTextBlock.Click += CallLabel_Click;


            }
        }

        private Label callNumberTextBlock = null;
        private void CallLabel_Click(object sender, EventArgs e)
        {
            callNumberTextBlock = (Label)sender;
            callNumberTextBlock.BackColor = Color.Yellow;
        }

        private void Definition_MouseLeftButtonClick(object sender, EventArgs e)
        {
            if (callNumberTextBlock != null)
            {

                if (!check1)
                {
                    Label descriptTextBlock = (Label)sender;
                    AnswerDic.Add(callNumberTextBlock.Text, descriptTextBlock.Text);
                    callNumberTextBlock.BackColor = Color.Gray;
                    callNumberTextBlock.Enabled = false;
                    descriptTextBlock.BackColor = Color.Gray;
                    descriptTextBlock.Enabled = false;

                    callNumberTextBlock = null;
                }
                else
                {
                    Label descriptTextBlock = (Label)sender;
                    AnswerDic.Add(descriptTextBlock.Text, callNumberTextBlock.Text);
                    callNumberTextBlock.BackColor = Color.Gray;
                    callNumberTextBlock.Enabled = false;
                    descriptTextBlock.BackColor = Color.Gray;
                    descriptTextBlock.Enabled = false;

                    callNumberTextBlock = null;
                }
            }
            else
            {
                MessageBox.Show("Select Call Number First");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> x in Group14)
            {
                if (AnswerDic.TryGetValue(x.Key, out string area))
                {
                    if (x.Value.Equals(area))
                    {
                        TempNumScore++;
                    }
                }
            }

            MessageBox.Show("Your Score is: " + TempNumScore);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
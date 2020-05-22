using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class MainFrom : Form
    {
        private int inputParameter = 4;
        private int buttonSize = 50;
        private int font = 10;
        private int sleepTime = 500;
        private int numberOfDisabledButtons = 0;

        private bool pressedButtonExists = false;
        private Button[] pressedButtons;

        public MainFrom(int inputParameter)
        {
            this.inputParameter = inputParameter;
            InitializeComponent();
        }

        private List<int> CreatePayload()
        {
            var payload = new List<int>();
            for (var i = 0; i < inputParameter * inputParameter / 2; i++)
            {
                payload.Add(i);
                payload.Add(i);
            }

            return payload;
        }

        private void GameFormLoad(object sender, EventArgs e)
        {
            this.Size = new Size((inputParameter + 1) * buttonSize, (inputParameter + 2) * buttonSize);
            pressedButtons = new Button[2];

            var payload = CreatePayload();
            for (var i = 0; i < inputParameter; i++)
            {
                for (var j = 0; j < inputParameter; j++)
                {
                    var button = new Button
                    {
                        Location = new Point(i * buttonSize, j * buttonSize), 
                        Size = new Size(buttonSize, buttonSize),
                        Font = new Font("Minion Pro", font), 
                        Padding = new Padding(0)
                    };

                    var random = new Random().Next(payload.Count - 1);
                    button.Name = payload[random].ToString();
                    payload.RemoveAt(random);

                    button.Click += new EventHandler(ButtonClick);

                    this.Controls.Add(button);
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var clickedButton = (Button) sender;
            clickedButton.Enabled = false;
            clickedButton.Text = clickedButton.Name;

            if (!pressedButtonExists)
            {
                pressedButtonExists = true;
                pressedButtons[0] = clickedButton;
            }
            else
            {
                pressedButtons[1] = clickedButton;
                ButtonComparison();
            }
        }

        private void ButtonComparison()
        {
            pressedButtonExists = false;

            if (pressedButtons[0].Name != pressedButtons[1].Name)
            {
                Task.Delay(sleepTime).Wait();
                pressedButtons[0].Text = "";
                pressedButtons[1].Text = "";
                pressedButtons[0].Enabled = true;
                pressedButtons[1].Enabled = true;
            }
            else
            {
                numberOfDisabledButtons += 2;

                if (numberOfDisabledButtons == this.Controls.Count)
                {
                    Application.Exit();
                }
            }
        }
    }
}
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
    /// <summary>
    /// Game implementation
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainFrom : Form
    {
        private int _inputParameter = 4;
        private readonly int _buttonSize = 50;
        private const int font = 10;
        private readonly int _sleepTime = 500;
        private int _numberOfDisabledButtons;

        private bool _pressedButtonExists = false;
        private Button[] _pressedButtons;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainFrom"/> class.
        /// </summary>
        /// <param name="inputParameter">The input parameter.</param>
        public MainFrom(int inputParameter)
        {
            this._inputParameter = inputParameter;
            InitializeComponent();
        }

        /// <summary>
        /// Creating an array to be placed on the window
        /// </summary>
        private List<int> CreatePayload()
        {
            var payload = new List<int>();
            for (var i = 0; i < _inputParameter * _inputParameter / 2; i++)
            {
                payload.Add(i);
                payload.Add(i);
            }

            return payload;
        }

        /// <summary>
        /// Filling a window with buttons and initializing them.
        /// </summary>
        private void GameFormLoad(object sender, EventArgs e)
        {
            this.Size = new Size((_inputParameter + 1) * _buttonSize, (_inputParameter + 2) * _buttonSize);
            _pressedButtons = new Button[2];

            var payload = CreatePayload();
            for (var i = 0; i < _inputParameter; i++)
            {
                for (var j = 0; j < _inputParameter; j++)
                {
                    var button = new Button
                    {
                        Location = new Point(i * _buttonSize, j * _buttonSize), 
                        Size = new Size(_buttonSize, _buttonSize),
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

        /// <summary>
        /// Pressing a button, changing its characteristics depending on the situation.
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            var clickedButton = (Button) sender;
            clickedButton.Enabled = false;
            clickedButton.Text = clickedButton.Name;

            if (!_pressedButtonExists)
            {
                _pressedButtonExists = true;
                _pressedButtons[0] = clickedButton;
            }
            else
            {
                _pressedButtons[1] = clickedButton;
                ButtonComparison();
            }
        }

        /// <summary>
        /// Comparing the contents of two buttons and changing its characteristics depending on the situation.
        /// </summary>
        private void ButtonComparison()
        {
            _pressedButtonExists = false;

            if (_pressedButtons[0].Name != _pressedButtons[1].Name)
            {
                Task.Delay(_sleepTime).Wait();
                _pressedButtons[0].Text = "";
                _pressedButtons[1].Text = "";
                _pressedButtons[0].Enabled = true;
                _pressedButtons[1].Enabled = true;
            }
            else
            {
                _numberOfDisabledButtons += 2;

                if (_numberOfDisabledButtons == this.Controls.Count)
                {
                    Application.Exit();
                }
            }
        }
    }
}
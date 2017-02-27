using FormulaCalculation.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using FormulaCalculation.Interfaces;
using Ninject;
using Timer = System.Timers.Timer;

namespace FormulaCalculation
{
    public partial class MainWindow : Form
    {
        private readonly Timer _function;
        private readonly ICalculator _calculator;
        private readonly IJSON _json;

        public MainWindow()
        {
            InitializeComponent();
            _function = new Timer(new TimeSpan(0, 0, 0, 1).TotalMilliseconds);
            _function.AutoReset = true;
            _function.Elapsed += TimerFunctionOnElapsed;
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _calculator = kernel.Get<ICalculator>();
            _json = kernel.Get<IJSON>();
        }

        private void TimerFunctionOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dictionary<string, dynamic> values = _json.getJSON();

            dynamic op;
            values.TryGetValue("op", out op);
            dynamic parm1;
            values.TryGetValue("parm1", out parm1);
            dynamic parm2;
            values.TryGetValue("parm2", out parm2);

            var result = _calculator.Calculate(op, parm1, parm2);

            SetText(result.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = button1.Text == Resources.Button1_Status_Stop
                ? Resources.Button1_Status_Start
                : Resources.Button1_Status_Stop;

            if (button1.Text == Resources.Button1_Status_Stop)
                resultwindow.Text = "";

            _function.Enabled = !_function.Enabled;
            
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (resultwindow.InvokeRequired)
            {
                SetTextCallback d = SetText;
                Invoke(d, text);
            }
            else
            {
                if ((resultwindow.Text + text + Environment.NewLine).Length < resultwindow.MaxLength)
                {
                    resultwindow.Text = resultwindow.Text + text + Environment.NewLine;
                }
                else
                {
                    button1.PerformClick();
                }
            }
        }
    }
}

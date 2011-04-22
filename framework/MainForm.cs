using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using Doo;
using Doo.Environments;
using Doo.Machine;

namespace Doo
{
    public partial class MainForm : Form, IDirector
    {
        IEnvironment _env;
        IAgent _agn;
        Thread _loopThread;
        bool _stopLoop;
        long _cycle;
        int _logCounter;
        delegate void LogDelegate(string log);
        delegate void UpdateCycleTextBoxDelegate();
        
        public MainForm()
        {
            InitializeComponent();

            // TO DO: dinamically iterate available environment classes
            //try
            //{
            //    Assembly assembly = Assembly.LoadFrom("experiment.dll");
            //    string s;
            //    Type t = null;
            //    foreach (Type type in assembly.GetTypes())
            //    {
            //        Console.WriteLine(type.Name);
            //        if (type.Name == "Env")
            //            environmentsComboBox.Items.Add(type.Name);
            //    }
            //}
            //catch (Exception exch)
            //{
            //}

            environmentsComboBox.Items.Add("BasicEnvironment");
            environmentsComboBox.SelectedIndex = environmentsComboBox.Items.Count - 1;
            _cycle = 0;
            _logCounter = 0;
        }
        
        protected override void Dispose(bool disposing)
        {
            _stopLoop = true;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        void initNetButton_Click(object sender, EventArgs e)
        {
            switch (environmentsComboBox.Text)
            {
                case "BasicEnvironment":
                    _env = new BasicEnvironment();
                    break;
            }
            // TO DO: dinamically create environment class
            //t = Type.GetType("Doo.Environments.EnvironmentL010");
            //IEnvironment env = (IEnvironment)Activator.CreateInstance(t, new object[] { 5, 5 });

            _agn = new Doo.Machine.AgentControl(this);
            _env.SetAgent(_agn);

            _agn.Show();
            _env.Show();

            //
            //_env.Initialize(); // TO DO: the initialization must be better managed. it could conflict with change in environment mode combobox.
            _agn.Initialize();
            Log("Inizialization OK");

            //
            initNetButton.Enabled = false;
            startNetButton.Enabled = true;
            stepNetButton.Enabled = true;
            stopNetButton.Enabled = false;
        }

        void stepNetButton_Click(object sender, EventArgs e)
        {
            Step();
        }

        void startNetButton_Click(object sender, EventArgs e)
        {
            _stopLoop = false;
            _loopThread = new Thread(Loop);
            _loopThread.Start();
            startNetButton.Enabled = false;
            stepNetButton.Enabled = false;
            stopNetButton.Enabled = true;
        }

        private void stopNetButton_Click(object sender, EventArgs e)
        {
            _stopLoop = true;
            startNetButton.Enabled = true;
            stepNetButton.Enabled = true;
            stopNetButton.Enabled = false;
        }

        void Step()
        {
            _env.Step();
            _agn.Step();
            _cycle++;
            if ((_cycle & 3) == 3) // update cycle text box every 4 cycle
                UpdateCycleTextBox();
        }

        void UpdateCycleTextBox()
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateCycleTextBoxDelegate(UpdateCycleTextBox));
            }

            cycleTextBox.Text = _cycle.ToString();
        }

        void Loop()
        {
            //int sleep = int.Parse(sleepBetweenStepTextBox.Text);
            while (!_stopLoop)
            {
                Thread.Sleep(int.Parse(sleepBetweenStepTextBox.Text));
                Application.DoEvents();
                Step();
            }
        }

        void logListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (logListView.SelectedItems == null)
                return;

            string str = logListView.SelectedItems[0].SubItems[2].Text;
            MessageBox.Show(str);
        }

        public void Log(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new LogDelegate(Log), new object[] { log });
                return;
            }
            _logCounter++;
            ListViewItem item = new ListViewItem(new string[] { _logCounter.ToString(), DateTime.Now.ToString("hh:mm:ss"), log });
            logListView.Items.Add(item);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stopLoop = true;
        }
    }
}

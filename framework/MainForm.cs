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
using Doo.Machine.HTM;

namespace Doo
{
    public partial class MainForm : Form, IDirector
    {
        List<IAgent> _agents;
        Thread _loopThread;
        bool _stopLoop;
        long _cycle;
        int _logCounter;
        delegate void LogDelegate(string log);
        delegate void UpdateCycleTextBoxDelegate();
        delegate void LoopFinishedDelegate();

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _cycle = 0;
            _logCounter = 0;
            _agents = new List<IAgent>();
        }

        protected override void Dispose(bool disposing)
        {
            _stopLoop = true;
            //_loopThread.Join();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        bool Step()
        {
            _cycle++;
            foreach (IAgent agn in _agents)
                if (!agn.Step())
                    return false;
            return true;
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
                if (!Step())
                    _stopLoop = true;
                if (int.Parse(breakAtStepTextBox.Text) != 0)
                {
                    if (_cycle == int.Parse(breakAtStepTextBox.Text))
                        _stopLoop = true;
                }
                if ((_cycle & 3) == 3) // update cycle text box every 4 cycle
                    UpdateCycleTextBox();
            }
            LoopFinished();
        }

        void LoopFinished()
        {
            if (this.InvokeRequired)
            {
                Invoke(new LoopFinishedDelegate(LoopFinished));
                return;
            }
            UpdateCycleTextBox();
            Log("Loop interrupted.");
            startButton.Enabled = true;
            stepButton.Enabled = true;
            stopButton.Enabled = false;
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
            logListView.Items[logListView.Items.Count - 1].EnsureVisible();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stopLoop = true;
        }

        private void imageDesktopButton_Click(object sender, EventArgs e)
        {
            ImageEnvironment env = new ImageEnvironment(this);
            _agents.Add(env);
            ImagePreprocessor preprocessor = new ImagePreprocessor(this);
            _agents.Add(preprocessor);
            HTMBuilder htmBuilder = new HTMBuilder(this);
            _agents.Add(htmBuilder);
            preprocessor.InputAgent = env;   // link the preprocessor to the environment
            htmBuilder.InputAgent = preprocessor;   // link the htm builder to the preprocessor

            // Set the layout
            preprocessor.MdiParent = this;
            preprocessor.Location = new Point(0, 0);
            preprocessor.Show();
            htmBuilder.MdiParent = this;
            htmBuilder.Location = new Point(0, preprocessor.Height);
            htmBuilder.Show();
            env.MdiParent = this;
            env.Location = new Point(preprocessor.Width, 0);
            env.Show();
            env.Initialize(); // TO DO manage better the initialization process.

            //
            this.Log("Image desktop created.");
            initializeButton.Enabled = true;
            imageDesktopButton.Enabled = false;
            dataDesktopButton.Enabled = false;
        }

        private void dataDesktopButton_Click(object sender, EventArgs e)
        {
            DataEnvironment env = new DataEnvironment(this);
            _agents.Add(env);
/*            IAgent preprocessor = new DataPreprocessor(this);
            _agents.Add(preprocessor);*/
            HTMBuilder htmBuilder = new HTMBuilder(this);
            _agents.Add(htmBuilder);
            //preprocessor.InputAgent = env;   // link the preprocessor to the environment
            htmBuilder.InputAgent = env;   // link the htm builder to the environment
            htmBuilder.MinimumOverlap = 1;

            // Set the layout
            //preprocessor.MdiParent = this;
            //preprocessor.Location = new Point(0, this.Top + this.Height);
            //preprocessor.Show();
            htmBuilder.MdiParent = this;
            htmBuilder.Location = new Point(0, 0);
            htmBuilder.Show();
            env.MdiParent = this;
            env.Location = new Point(htmBuilder.Width, 0);
            env.Show();

            //
            this.Log("Data desktop created.");
            initializeButton.Enabled = true;
            imageDesktopButton.Enabled = false;
            dataDesktopButton.Enabled = false;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            Step();
            UpdateCycleTextBox();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _stopLoop = false;
            _loopThread = new Thread(Loop);
            _loopThread.Start();
            startButton.Enabled = false;
            stepButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _stopLoop = true;
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            foreach (IAgent agn in _agents)
                agn.Initialize();
            initializeButton.Enabled = false;
            startButton.Enabled = true;
            stepButton.Enabled = true;
            stopButton.Enabled = false;
        }
    }
}

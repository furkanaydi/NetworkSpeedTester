using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkSpeedTester
{
    /// <summary>
    /// MainForm provides a simple user interface for testing network latency
    /// via ICMP ping. Users can specify a host and run multiple pings to
    /// calculate average round-trip time. Results are displayed in a
    /// multi‑line text box.
    ///
    /// This class inherits from <see cref="Form"/> and creates controls
    /// programmatically. For a larger project consider using the Windows
    /// Forms designer (.resx) for layout.
    /// </summary>
    public class MainForm : Form
    {
        private readonly TextBox _hostTextBox;
        private readonly Button _testButton;
        private readonly TextBox _resultTextBox;

        public MainForm()
        {
            // Set up the form properties
            Text = "Network Speed Tester";
            Width = 400;
            Height = 300;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // Label for the host text box
            var hostLabel = new Label
            {
                Text = "Host:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 13)
            };
            Controls.Add(hostLabel);

            // Text box where user enters the host to ping
            _hostTextBox = new TextBox
            {
                Location = new System.Drawing.Point(60, 10),
                Width = 200,
                Text = "google.com" // Provide a sensible default
            };
            Controls.Add(_hostTextBox);

            // Button that triggers the ping test
            _testButton = new Button
            {
                Text = "Test",
                Location = new System.Drawing.Point(280, 8)
            };
            _testButton.Click += TestButton_Click;
            Controls.Add(_testButton);

            // Multi‑line text box to display results
            _resultTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 50),
                Width = 360,
                Height = 200,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true
            };
            Controls.Add(_resultTextBox);
        }

        /// <summary>
        /// Handles the click event of the test button. Initiates an async
        /// ping sequence and displays results. Exceptions are caught and
        /// displayed in the result text box to avoid unhandled exceptions
        /// bringing down the UI thread.
        /// </summary>
        private async void TestButton_Click(object? sender, EventArgs e)
        {
            string host = _hostTextBox.Text;
            if (string.IsNullOrWhiteSpace(host))
            {
                MessageBox.Show("Please enter a host name or IP address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _resultTextBox.Clear();
            _resultTextBox.AppendText($"Testing ping to {host}...\r\n");

            // Disable the button while running to prevent concurrent tests
            _testButton.Enabled = false;

            try
            {
                using Ping ping = new Ping();
                int count = 5; // number of ping attempts
                long totalTime = 0;
                int successCount = 0;

                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        // Send an asynchronous ping with a 1000ms timeout
                        PingReply reply = await ping.SendPingAsync(host, 1000);
                        if (reply.Status == IPStatus.Success)
                        {
                            _resultTextBox.AppendText($"Reply from {reply.Address}: time={reply.RoundtripTime}ms\r\n");
                            totalTime += reply.RoundtripTime;
                            successCount++;
                        }
                        else
                        {
                            _resultTextBox.AppendText($"Request failed: {reply.Status}\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any exceptions thrown by SendPingAsync (e.g., invalid host)
                        _resultTextBox.AppendText($"Ping failed: {ex.Message}\r\n");
                    }
                }

                if (successCount > 0)
                {
                    double average = totalTime / (double)successCount;
                    _resultTextBox.AppendText($"\r\nAverage round‑trip time: {average:F2}ms\r\n");
                }
                else
                {
                    _resultTextBox.AppendText("No successful pings.\r\n");
                }
            }
            finally
            {
                // Re‑enable the test button after the test completes
                _testButton.Enabled = true;
            }
        }
    }
}

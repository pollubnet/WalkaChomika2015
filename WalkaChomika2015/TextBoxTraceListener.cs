using System;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace Ktos.Common
{
    /// <summary>
    /// Class for moving Debug information to simple TextBox
    /// </summary>
    public class TextBoxTraceListener
    {
        /// <summary>
        /// TextBox, which will be receiving debug information
        /// </summary>
        private TextBox output;

        /// <summary>
        /// Creates new instance of TextBoxTraceListener
        /// </summary>
        /// <param name="output">TextBox which will be receiving Debug information</param>
        public TextBoxTraceListener(TextBox output)
        {
            this.output = output;
        }

        /// <summary>
        /// Writes message to debugging TextBox, along with current time
        /// </summary>
        /// <param name="message">Debug message</param>
        public void Write(string message)
        {
            output.Text += string.Format("[{0:HH:mm:dd.ff}] ", DateTime.Now);
            output.Text += message;
        }

        /// <summary>
        /// Writes message to debugging TextBox followed by line terminator, along with current time
        /// </summary>
        /// <param name="message">Debug message</param>
        public void WriteLine(string message)
        {
            this.Write(message + Environment.NewLine);
        }
    }
}

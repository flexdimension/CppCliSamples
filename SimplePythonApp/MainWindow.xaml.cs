using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace SimplePythonApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScriptEngine engine = null;
        private ScriptScope scope = null;

        private class TextBoxWriter : TextWriter
        {
            private TextBox textBox;
            private Encoding encoding;

            public TextBoxWriter(TextBox textBox) : this(textBox, Encoding.UTF8)
            {
                
            }

            public TextBoxWriter(TextBox textBox, Encoding encoding)
            {
                this.textBox = textBox;
                this.encoding = encoding;
            }

            public override void WriteLine(string value)
            {
                this.textBox.AppendText(value);
            }

            public override void Write(char value)
            {
                this.textBox.AppendText(value.ToString());
            }

            public override void Write(char[] buffer, int index, int count)
            {
                this.textBox.AppendText(new string(buffer));
                this.textBox.ScrollToEnd();
            }

            public override void Write(int value)
            {
                this.textBox.AppendText(value.ToString());
            }

            public override Encoding Encoding
            {
                get
                {
                    return this.encoding;
                }
            }

        }

        TextBoxWriter writer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            engine = Python.CreateEngine();
            engine.Runtime.IO.RedirectToConsole();
            writer = new TextBoxWriter(outputText);
            
            Console.SetOut(writer);
            Console.SetError(writer);

            scope = engine.CreateScope();
        }

        private void Eval(string input)
        {
            try
            {
                ScriptSource source = engine.CreateScriptSourceFromString(input, SourceCodeKind.SingleStatement);
                source.Execute(scope);

            }
            catch (Exception ex)
            {

                outputText.AppendText(ex.Message);
                outputText.AppendText("\n");
                outputText.ScrollToEnd();
            }


        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (inputText.Text.Length > 0)
                {
                    outputText.AppendText(inputText.Text);
                    outputText.AppendText("\n");
                    outputText.ScrollToEnd();
                    Eval(inputText.Text);
                    inputText.Text = "";
                }
            }

        }
    }
}

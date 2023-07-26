using System;
using System.IO;
using System.Windows;

namespace FileSearchApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtFileName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                try
                {
                    string[] foundFiles = Directory.GetFiles(@"C:\", fileName, SearchOption.TopDirectoryOnly);
                    string[] windowsFiles = Directory.GetFiles(@"C:\Windows", fileName, SearchOption.TopDirectoryOnly);
                    string[] allFoundFiles = new string[foundFiles.Length + windowsFiles.Length];
                    foundFiles.CopyTo(allFoundFiles, 0);
                    windowsFiles.CopyTo(allFoundFiles, foundFiles.Length);

                    if (allFoundFiles.Length > 0)
                    {
                        txtResult.Text = $"File found: {allFoundFiles[0]}";
                    }
                    else
                    {
                        txtResult.Text = "File not found.";
                    }
                }
                catch (UnauthorizedAccessException execute)
                {
                    txtResult.Text = "Access to the file or directory is denied. You may not have permission to access certain files or directories.";
                }
                catch (Exception execute)
                {
                    txtResult.Text = "An error occurred while searching for the file.";
                }
            }
            else
            {
                txtResult.Text = "Please enter a file name to execute.";
            }
        }
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiSharp01.Classes;
using RuiSharp01.Enums;

namespace RuiSharp01
{
    public partial class Form1 : Form
    {

        private DataManager _manager = new DataManager();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeStatusLabelColor(LoggingStatus status)
        {
            switch (status)
            {
                case LoggingStatus.Success:
                    StatusLabel.ForeColor = Color.Blue;
                    break;
                case LoggingStatus.Error:
                    StatusLabel.ForeColor = Color.Red;
                    break;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var status = _manager.RegisterData(DataTextBox.Text);
            switch (status)
            {
                case RegisterStatus.EmptyValueFailed:
                    StatusLabel.Text = "空文字は受け付けません";
                    ChangeStatusLabelColor(LoggingStatus.Error);
                    break;
                case RegisterStatus.LengthOverFailed:
                    StatusLabel.Text = $"文字数は{_manager.LENGTH_LIMIT}以下にしてください";
                    ChangeStatusLabelColor(LoggingStatus.Error);
                    break;
                case RegisterStatus.Succesed:
                    StatusLabel.Text = $"{DataTextBox.Text}を登録しました";
                    ChangeStatusLabelColor(LoggingStatus.Success);
                    break;
            }
            DataTextBox.Text = string.Empty;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.ClearData();
                OutputLabel.Text = string.Empty;
                StatusLabel.Text = "データは正常にクリアされました";
                ChangeStatusLabelColor(LoggingStatus.Success);
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                ChangeStatusLabelColor(LoggingStatus.Error);
            }
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            try
            {
                var outputText = _manager.OutputText();
                OutputLabel.Text = outputText;
                StatusLabel.Text = "正常に出力されました";
                ChangeStatusLabelColor(LoggingStatus.Success);
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                ChangeStatusLabelColor(LoggingStatus.Error);
            }
        }
    }
}
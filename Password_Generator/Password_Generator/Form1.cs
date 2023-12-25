using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        int currentPasswordLength = 0;
        Random character = new Random();

        private void passwordGenerator(int passwordLength)
        {
            String allCharacters = "ABCDEFGHILMNOPQRSTUVWXYZ0123456789abcdefghilmnopqrstuvwxyz!@#$%^&*()[]<>~";
            //ABCDEFGHILMNOPQRSTUVWXYZ0123456789abcdefghilmnopqrstuvwxyz!@#$%^&*()[]<>~
            String randomPassword = "";

            for(int i = 0; i < passwordLength; i++)
            {
                int randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum];
            }
            passwordLabel.Text = randomPassword;
        }

        public Form1()
        {
            InitializeComponent();
            passwordLengthSlider.Maximum = 20;
            passwordLengthSlider.Minimum = 5;
            passwordGenerator(5);
            passwordLengthLabel.AutoSize = true;
        }

        private void copyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordLabel.Text);
        }

        private void passwordLengthSlider_Scroll(object sender, EventArgs e)
        {
            currentPasswordLength = passwordLengthSlider.Value;
            passwordLengthLabel.Text = "Password Length: " + currentPasswordLength.ToString();
            passwordGenerator(currentPasswordLength);
        }
    }
}

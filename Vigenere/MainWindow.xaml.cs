using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vigenere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            var text = EncryptInput.Text;
            var key = EncryptKey.Text;
            key = GetKey(text, key);
            var matrix = BuildMatrix();
            var encryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += matrix[GetPosition(key[i])][GetPosition(text[i])];
            }

            EncryptedText.Text = encryptedText;
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            var text = EncryptInput.Text;
            var key = EncryptKey.Text;
            key = GetKey(text, key);
            var matrix = BuildMatrix();
            var decryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                var s = GetString(key[i]);

                decryptedText += chars[GetPosition(text[i])];
            }

            DecryptedText.Text = decryptedText;
        }

        private string GetKey(string text, string key)
        {
            var returnedKey = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                returnedKey += key[i % key.Length];
            }
            return returnedKey;
        }

        private string[] BuildMatrix()
        {
            var matrix = new string[26];

            for (int i = 0; i < 26; i++)
            {
                var letter = i;

                for (int j = 0; j < 26; j++)
                {
                    matrix[i] += chars[letter];
                    letter++;

                    if (letter == 26)
                        letter = 0;
                }
            }

            return matrix;
        }

        private int GetPosition(char c, string s = chars)
        {
            for (int i = 0; i < 26; i++)
            {
                if (s[i] == c)
                    return i;
            }
            return 0;
        }

        private string GetString(char c)
        {
            var s = string.Empty;

            var position = GetPosition(c);

            for (int i = 0; i < 26; i++)
            {
                s += chars[position];

                if (position == 26)
                {
                    position = 0;
                }
            }

            return s;
        }
    }
}

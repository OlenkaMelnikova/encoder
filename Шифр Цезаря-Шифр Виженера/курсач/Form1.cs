using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using курсач;

namespace encoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        private EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        private static string[] alphabet;

        private void Init()
        {
            if (radioButton6.Checked)
            {
                alphabet = new string[] {
                                          "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" ,
                                          "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" ,
                                          " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
                };
            }
            else
            {
                alphabet = new string[]{ "а", "б", "в","г", "д", "е", "ё", "ж","з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с","т", "у", "ф", "х","ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я",
                                         "А", "Б", "В","Г", "Д", "Е", "Ё", "Ж","З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С","Т", "У", "Ф", "Х","Ц", "Ч", "Ш", "Щ", "Ь", "Ы", "Э", "Ю", "Я",
                                         " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
            }
        }

        public string Encryption(string[] array, string[] array2, string text)// ф- я  шифрования
        {

            // string text = textBox2.Text;// текст бокс принимает строковые значения
            string result = string.Empty;
            foreach (var letter in text)
            {
                for (int i = 0; i < array.Length; i++)//в цикле просматриваем текст
                {
                    if (letter.ToString() == array[i])//записываем значение  в тектс бокс 3
                    {
                        //textBox3.Text += array2[i];
                        result += array2[i];
                        break;
                    }
                }
            }
            return result;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Close();//выход
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = String.Concat(" ", ((trackBar1.Value).ToString()));//записываем значения трекбара в метку
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            label3.Text = "Зашифрованный текст";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            label3.Text = "Расшифрованный текст";
        }

        private void radioButton4_Click(object sender, EventArgs e)//событие нажатия метода Виженера
        {
            label1.Visible = false;    //приводим элементы формы в порядок
            trackBar1.Visible = false;
            label4.Visible = false;
            label5.Visible = true;
            textBox1.Visible = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)//событие нажатия метода Цезаря
        {
            label1.Visible = true;         //приводим элементы формы в порядок
            trackBar1.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            textBox1.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox2.Focus();
            Init();
        }

        private void button3_Click(object sender, EventArgs e) //событие кнопки  СПРАВКА - вызов формы
        {
            Form2 F = new Form2();
            F.ShowDialog();
        }



        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Init();
            textBox1.Clear();
            textBox2.Clear();


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Init();
            textBox1.Clear();
            textBox2.Clear();
        }

        private bool CheckInputText(string s)
        {
            bool res = false;
            for (int i = 0; i < alphabet.Length; ++i)
                if (s == alphabet[i]) res = true;
            return res;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !CheckInputText(e.KeyChar.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !CheckInputText(e.KeyChar.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            string input = textBox2.Text;//возвращаем копию этой строки

            if (radioButton4.Checked)//если метод виженера
            {               
                string key_temp = textBox1.Text;//возвращаем копию ключа шифрования

                textBox3.Text = encryptionDecryption.EncryptV(input, key_temp, alphabet);//записываем результат
            }

            if (radioButton3.Checked)//если метод Цезаря
            {
                if (input == string.Empty)
                {
                    MessageBox.Show("Введите текст");
                    return;
                }

                var move = trackBar1.Value;

                var array2 = alphabet.Skip(move).Concat(alphabet.Take(move)).ToArray();

                textBox3.Text = encryptionDecryption.EncryptionCesar(input, alphabet,array2);//Encryption(input, array2, alphabet);//шифруем
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            if (radioButton4.Checked)//если метод Виженера
            {
                textBox3.Text = "";
                //тот же самый алгоритм-только сейчас ДЕШИФРОВАНИЕ
                string input = "", key = "", key_temp = "";
                int mod = 0, number_of_letter;//счетчик текста
                input = textBox2.Text;
                key_temp = textBox1.Text;
                if (textBox2.Text != "" && textBox1.Text != "")//если все данные введены
                {
                    mod = input.Length % key_temp.Length;
                    for (int i = 0; i < (input.Length - mod) / key_temp.Length; i++)
                    {
                        key += key_temp;
                    }
                    for (int i = 0; i < mod; i++)
                    {
                        key += key_temp[i];
                    }
                    string[] input_mas = new string[input.Length];
                    int[] input_index = new int[input.Length];
                    string[] key_mas = new string[input.Length];
                    int[] key_index = new int[input.Length];
                    string[] encrypted_word = new string[input.Length];
                    for (int i = 0; i < input.Length; i++)
                    {
                        input_mas[i] = Convert.ToString(input[i]);
                    }
                    for (int i = 0; i < key.Length; i++)
                    {
                        key_mas[i] = Convert.ToString(key[i]);
                    }

                    for (int i = 0; i < input.Length; i++)
                    {

                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (input_mas[i] == alphabet[j])
                            {
                                input_index[i] = j;
                            }
                            if (key_mas[i] == alphabet[j])
                            {
                                key_index[i] = j;
                            }
                        }
                    }


                    for (int i = 0; i < input_mas.Length; i++)
                    {
                        number_of_letter = (input_index[i] - key_index[i] + alphabet.Length) % alphabet.Length;
                        encrypted_word[i] = alphabet[number_of_letter];
                        number_of_letter = 0;
                    }

                    for (int i = 0; i < input_index.Length; i++)
                    {
                        textBox3.Text += encrypted_word[i];//записываем зашифрованный текст 
                    }
                }

            }

            if (radioButton3.Checked)//если метод Цезаря
            {
                if (textBox2.Text == String.Empty)
                {
                    MessageBox.Show("Введите текст");
                    return;
                }
                int move = 0;


                move = Convert.ToInt32(trackBar1.Value);
                string[] array2;
                array2 = alphabet.Skip(move).Concat(alphabet.Take(move)).ToArray();
                textBox3.Text = encryptionDecryption.EncryptionCesar(input, array2, alphabet);//Encryption(input, array2, alphabet);//шифруем
            }

        }

    }
}


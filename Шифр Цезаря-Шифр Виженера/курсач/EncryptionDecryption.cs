using encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace курсач
{
    public class EncryptionDecryption
    {


        public string EncryptV(string input, string key_temp, string[] alphabet)
        {
            //ШИФРОВАНИЕ Виженер
            string key = string.Empty;

            int mod = 0;//счетчик количества текста

            if (input == string.Empty || key_temp == string.Empty)//если все исходные данные введены
            {
                return string.Empty;
            }

            mod = input.Length % key_temp.Length;//алгоритм шифрования:  переменной mod присваиваем значение введенного текста
            for (int i = 0; i < (input.Length - mod) / key_temp.Length; i++)//просматриваем в цикле
            {
                key += key_temp;
            }
            for (int i = 0; i < mod; i++)
            {
                key += key_temp[i];
            }
            //определение значений
            string[] input_mas = new string[input.Length];
            int[] input_index = new int[input.Length];
            string[] key_mas = new string[input.Length];
            int[] key_index = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                input_mas[i] = Convert.ToString(input[i]);//конвертирование в строковое значение
            }

            for (int i = 0; i < key.Length; i++)
            {
                key_mas[i] = Convert.ToString(key[i]);//конвертирование в строковое значение
            }

            for (int i = 0; i < input.Length; i++)//просматриваем введенные данные
            {
                for (int j = 0; j < alphabet.Length; j++)//просматриваем алфавит
                {
                    if (input_mas[i] == alphabet[j])//введенные данные присваиваем к алфавиту
                    {
                        input_index[i] = j;//записываем значение
                    }

                    if (key_mas[i] == alphabet[j])//введенные данные присваиваем к алфавиту
                    {
                        key_index[i] = j;//записываем значение
                    }
                }
            }

            int number_of_letter;
            string[] encrypted_word = new string[input.Length];

            for (int i = 0; i < input_mas.Length; i++)//введенный массив просматриваем
            {
                number_of_letter = (input_index[i] + key_index[i]) % alphabet.Length;//шифруем
                encrypted_word[i] = alphabet[number_of_letter];
                number_of_letter = 0;
            }

            string result = string.Empty;

            foreach (var word in encrypted_word)//записываем результат шифровки
            {
                result += word;
            }

            return result;
        }


        public string EncryptionCesar(string input, string[] array, string[] array2)// ф- я  шифрования
        {
            // string text = textBox2.Text;// текст бокс принимает строковые значения
            string result = string.Empty;
            foreach (var letter in input)
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
    }
}

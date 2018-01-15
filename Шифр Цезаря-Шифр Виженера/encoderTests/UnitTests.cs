using System;
using encoder;
using NUnit.Framework;
using курсач;

namespace encoderTests
{ 
    [TestFixture]
    public class UnitTests
    {

        string[] englishAlphabet = new string[] {
                                          "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" ,
                                          "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" ,
                                          " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        string[] russianAlphabet = new string[]{ "а", "б", "в","г", "д", "е", "ё", "ж","з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с","т", "у", "ф", "х","ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я",
                                    "А", "Б", "В","Г", "Д", "Е", "Ё", "Ж","З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С","Т", "У", "Ф", "Х","Ц", "Ч", "Ш", "Щ", "Ь", "Ы", "Э", "Ю", "Я",
                                    " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
        // true - russianAlphabet
        // false - englishAlphabet
        [TestCase("","585","", true)]
        [TestCase("", "585", "", false)]
        [TestCase("фантастика", "век", "цешфеьфнхв", true)]
        public void EncryptVPositiveTest(string input, string key_temp, string result, bool alphabetTrigger)
        {
            var alphabet = alphabetTrigger ? russianAlphabet : englishAlphabet;

            var encryptionResult = new EncryptionDecryption().EncryptV(input, key_temp, alphabet);

            Assert.AreEqual(result, encryptionResult);            
        }
    }
}

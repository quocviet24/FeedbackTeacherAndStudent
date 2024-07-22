using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    static public class Encode
    {
        static public string CaesarCipherEncrypt(string text)
        {
            string encryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (char.IsLetter(ch))
                {
                    int newChar;
                    if (char.IsUpper(ch))
                    {
                        newChar = (ch + 6 - 'A') % 26 + 'A';
                    }
                    else
                    {
                        newChar = (ch + 6 - 'a') % 26 + 'a';
                    }
                    encryptedText += (char)newChar;
                }
                else if (char.IsDigit(ch))
                {
                    int newDigit = (ch + 6 - '0') % 10 + '0';
                    encryptedText += (char)newDigit;
                }
                else
                {
                    encryptedText += ch;
                }
            }
            return encryptedText;
        }

        static public string CaesarCipherDecrypt(string text)
        {
            string decryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (char.IsLetter(ch))
                {
                    int newChar;
                    if (char.IsUpper(ch))
                    {
                        newChar = (ch - 6 - 'A' + 26) % 26 + 'A';
                    }
                    else
                    {
                        newChar = (ch - 6 - 'a' + 26) % 26 + 'a';
                    }
                    decryptedText += (char)newChar;
                }
                else if (char.IsDigit(ch))
                {
                    int newDigit = (ch - 6 - '0' + 10) % 10 + '0';
                    decryptedText += (char)newDigit;
                }
                else
                {
                    decryptedText += ch;
                }
            }
            return decryptedText;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TechEval.Interface;

namespace TechEval.Impl
{
    public class Words:IWords
    {
        public string GetWord(string inputNumber)
        {
            StringBuilder wordAsString = new StringBuilder();

            int indexOfDecimal = inputNumber.IndexOf('.');

            int numLength = (indexOfDecimal >-1) ? (indexOfDecimal) : inputNumber.Length;

            switch (numLength)
            {
                case 1://singles  
                    if (inputNumber[0] != '.')
                        wordAsString.Append(findWordSingle(inputNumber[0]));
                    break;

                case 2://tens
                    if (inputNumber[0] == '0')//NOTE: this contingency for leading zeros should be done for, but i am only doing it once here as an example...
                    {
                        wordAsString.Append(findWordSingle(inputNumber[1]));
                    }
                    else
                    {
                        if (inputNumber[0] == '1')
                        {
                            wordAsString.Append(findWordTens(inputNumber));
                        }
                        else
                        {
                            wordAsString.Append(findWordTens(inputNumber) + "-");
                            wordAsString.Append(findWordSingle(inputNumber[1]));
                        }
                    }

                    break;

                case 3://hundreds
                    wordAsString.Append(findWordSingle(inputNumber[0]) + " hundred ");

                    if (inputNumber[1] == '0')
                    {
                        wordAsString.Append(findWordSingle(inputNumber[2]));
                    }
                    else
                    {
                        if (inputNumber[1] == '1')
                        {
                            wordAsString.Append(findWordTens(inputNumber.Remove(0, 1)));
                        }
                        else
                        {
                            wordAsString.Append(findWordTens(inputNumber.Remove(0, 1)) + "-");
                            wordAsString.Append(findWordSingle(inputNumber.Remove(0, 1)[1]));
                        }
                    }
                    break;

                case 4://thousands
                    wordAsString.Append(findWordSingle(inputNumber[0]) + " thousand ");

                    if (inputNumber[1] != '0')
                        wordAsString.Append(findWordSingle(inputNumber[1]) + " hundred ");

                    if (inputNumber[1] == '0' && inputNumber[2] == '0' && inputNumber[3] == '0')
                        return wordAsString.ToString();

                    if (inputNumber[2] == '0')
                    {
                        wordAsString.Append(findWordSingle(inputNumber[3]));
                    }
                    else
                    {
                        if (inputNumber[2] == '1')
                        {
                            wordAsString.Append(findWordTens(inputNumber.Remove(0, 2)));
                        }
                        else
                        {
                            wordAsString.Append(findWordTens(inputNumber.Remove(0, 2)) + "-");
                            wordAsString.Append(findWordSingle(inputNumber.Remove(0, 2)[1]));
                        }
                    }
                    break;

                default://too big for now                   
                    wordAsString.Append("Please enter a number between 0 and 9999 with only a max of two digits after the decimal.");
                    break;
            }

            if (indexOfDecimal > 0)
            {
                wordAsString.Append(" and ");
                                
                wordAsString.Append(inputNumber.Substring(inputNumber.IndexOf('.') + 1, 2));
                
                wordAsString.Append("/100");
            }

            wordAsString.Append(" dollars");

            return wordAsString.ToString().First().ToString().ToUpper() + String.Join("", wordAsString.ToString().Skip(1));
        }

        private string findWordSingle(char number)
        {
            string found = "";

            switch (number)
            {
                case '0':
                    found = "zero";
                    break;
                case '1':
                    found = "one";
                    break;
                case '2':
                    found = "two";
                    break;
                case '3':
                    found = "three";
                    break;
                case '4':
                    found = "four";
                    break;
                case '5':
                    found = "five";
                    break;
                case '6':
                    found = "six";
                    break;
                case '7':
                    found = "seven";
                    break;
                case '8':
                    found = "eight";
                    break;
                case '9':
                    found = "nine";
                    break;
                default:
                    break;
            }

            return found;
        }

        private string findWordTens(string number)
        {
            string found = "";
                       
            switch (number[0])
            {
                case '0':
                    found = "";
                    break;
                case '1':
                    found = findWordTeens(number);
                    break;
                case '2':
                    found = "twenty";
                    break;
                case '3':
                    found = "thirty";
                    break;
                case '4':
                    found = "fourty";
                    break;
                case '5':
                    found = "fifty";
                    break;
                case '6':
                    found = "sixty";
                    break;
                case '7':
                    found = "seventy";
                    break;
                case '8':
                    found = "eighty";
                    break;
                case '9':
                    found = "ninety";
                    break;
                default:
                    break;
            }

            return found;
        }

        private string findWordTeens(string number)
        {
            string found = "";
            
            if(number.IndexOf('.') > 0)
                number = number.Substring(0, number.IndexOf('.'));

            switch (number)
            {
                case "10":
                    found = "ten";
                    break;
                case "11":
                    found = "eleven";
                    break;
                case "12":
                    found = "twelve";
                    break;
                case "13":
                    found = "thirteen";
                    break;
                case "14":
                    found = "fourteen";
                    break;
                case "15":
                    found = "fifteen";
                    break;
                case "16":
                    found = "sixteen";
                    break;
                case "17":
                    found = "seventeen";
                    break;
                case "18":
                    found = "eighteen";
                    break;
                case "19":
                    found = "nineteen";
                    break;
                default:
                    break;
            }

            return found;

        }             
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.RegisterConvert
{
    internal class ValidRegister
    {
      //  Number _number = new Number();
        public void WriteErrorsFromArray(ref Dictionary<string, double> validRegisters, byte register01, byte register00, byte register11, byte register10, byte register221)
        {
            byte[] arrayErrrosIfSaveFlags = new byte[31];

            // смысл такой, метод в который передаем массив, этот массив заполняем, два аргумента это, первый индекс с которого записывать, второй длина сколько писать
            ReceiveArrayErrosIfFlagsSave(register01, ref arrayErrrosIfSaveFlags, 0, 8);
            ReceiveArrayErrosIfFlagsSave(register00, ref arrayErrrosIfSaveFlags, 8, 8);
            ReceiveArrayErrosIfFlagsSave(register11, ref arrayErrrosIfSaveFlags, 16, 7);
            ReceiveArrayErrosIfFlagsSave(register10, ref arrayErrrosIfSaveFlags, 23, 6);
            ReceiveArrayErrosIfFlagsSave(register221, ref arrayErrrosIfSaveFlags, 29, 2, 22);

            for (int i = 0; i < arrayErrrosIfSaveFlags.Length; i++)
            {
                validRegisters.Add(ConstatansVariables.CoolectionErrorsAndFlags2[i], arrayErrrosIfSaveFlags[i]); // коллекция , имя - значение
            }
        }

        void ReceiveArrayErrosIfFlagsSave(byte rgister, ref byte[] arrayRegisters, int indexRegister, int valueindexRegister, int numberRegister = 0)
        {
            string changeResult2 = Convert.ToString(rgister, 2);

            int countArray = indexRegister + valueindexRegister; // устанавливаем длину записи

            int count22Reg = 1;

            if (changeResult2.Length != 8) // делаем длину 8 б
            {
                while (changeResult2.Length != 8)
                {
                    changeResult2 = changeResult2.Insert(0, "0");
                }
            }

            if (numberRegister != 22) // сделал реверс, чтобы ошибки соотвестсвовали порядки в списке на листочке, сперва идет верхний байт, потом нижний, 22 ргеистр убрал, там всего 4 бит и так понятно.кек
            {
                char[] reverces = changeResult2.ToCharArray();

                Array.Reverse(reverces);

                changeResult2 = new string(reverces);
            }


            for (int i = 0; i < arrayRegisters.Length - 1; i++) // перебираем, делаем размер + 8 от индекса, так как 8 бит 
            {
                if (indexRegister == countArray)
                    break;

                if (numberRegister == 22) // для 22 регистра так там первые 6 бит не используются
                    arrayRegisters[indexRegister] = Convert.ToByte(changeResult2.Substring(count22Reg + 5, 1));
                else
                    arrayRegisters[indexRegister] = Convert.ToByte(changeResult2.Substring(i, 1));

                indexRegister++;
                count22Reg++;
            }
        }

        public void ValidIndexFromTwoRegisterLow(ref Dictionary<string, double> arrayRegisters, byte register) =>
                   arrayRegisters.Add(ConstatansVariables.ТЕКУЩИЙ_НОМЕР_ПЕРИОДА, Convert.ToDouble(register + 1));

        public double ConvertToGisterezis(double register)
        {
            if (register.ToString().Length <= 1)
                return register;
            else
                return register / 10;
        }

        public double ConvertTo16(byte registerHigth, byte registerLow, int indexRegister)
        {
            var registerHigth16 = Convert.ToString(registerHigth, 16); //  переводим регистры в 16
            var registerLow16 = Convert.ToString(registerLow, 16); //

            double upd16 = 0; // здесь хранится преобразованный регистр
            double res16 = 0; // здесь хранится результат выполнения
            int regLength; // длина регистра, для того чтобы присвоить в какую степень возводить при переводе системы счисления

            while (registerHigth16.Length < 2) // если не хватает длины дописываем
            {
                registerHigth16 = registerHigth16.Insert(0, "0");
            }

            while (registerLow16.Length < 2)
            {
                registerLow16 = registerLow16.Insert(0, "0");
            }

            var registerNew = $"{registerHigth16}{registerLow16}"; // готовый регистр в 16
            regLength = registerNew.Length - 1; // устанавливаем степень


            for (int i = 0; i < registerNew.Length; i++)
            {
                string indexRegisters = registerNew.Substring(i, 1);

                if (indexRegisters.Contains("a"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("a", "10"));

                    res16 += upd16 * Math.Pow(16, regLength); // записываем ответ и считаем сумму
                    regLength--; // уменьшаем степень
                }
                else if (indexRegisters.Contains("b"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("b", "11"));

                    res16 += upd16 * Math.Pow(16, regLength);
                    regLength--;
                }
                else if (indexRegisters.Contains("c"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("c", "12"));

                    res16 += upd16 * Math.Pow(16, regLength);
                    regLength--;
                }
                else if (indexRegisters.Contains("d"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("d", "13"));

                    res16 += upd16 * Math.Pow(16, regLength);
                    regLength--;
                }
                else if (indexRegisters.Contains("e"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("e", "14"));

                    res16 += upd16 * Math.Pow(16, regLength);
                    regLength--;
                }
                else if (indexRegisters.Contains("f"))
                {
                    upd16 = Convert.ToDouble(indexRegisters.Replace("f", "15"));

                    res16 += upd16 * Math.Pow(16, regLength);
                    regLength--;
                }
                else
                {
                    res16 += Convert.ToDouble(indexRegisters) * Math.Pow(16, regLength);
                    regLength--;
                }
            }

            if (indexRegister == 1) // алфг для того, чтобы опнимать надо ли преобразовывать или нет или отправить готовый ответ
                return ConverKelvinToCelsius(res16); // перевод из кельвина в цельсию
            else if (indexRegister == 2)
            {
                if (res16 != 0)
                    return res16 / 10;
                else
                    return res16;
            }
            else if (indexRegister == 3)
            {
                if (res16 != 0)
                {
                    double res = Math.Round(res16 * 0.1, 1);

                    return res;
                }
                else
                {
                    return res16;
                }

            }
            else if (indexRegister == 4)
            {
                double res = 0;
                double standartCoal = 65280;
                if (res16 > 32000)
                    res = res16 - standartCoal;
                else
                    return res16;

                return res;
            }
            else if (indexRegister == 5)
            {
                if (res16 != 0)
                    return Math.Round(res16 / 100, 1);
                else
                    return res16;
            }
            else
                return res16;
        }

        public double ConverKelvinToCelsius(double register) => Math.Round((register / 10 - 273.15), 1);

        public double ConvertToGKal(byte register1, byte register2, byte register3, byte register4)
        {
            string reg1 = SetRegisterLenth(register1);
            string reg2 = SetRegisterLenth(register2);
            string reg3 = SetRegisterLenth(register3);
            string reg4 = SetRegisterLenth(register4);

            string register = $"{reg3}{reg4}{reg1}{reg2}";

            double numberNew = 0; //= Math.Round(_number.ReceiveNumber16(register) / 1000000, 3);

            return numberNew;
        }

        string SetRegisterLenth(byte register)
        {
            string registerStr = Convert.ToString(register, 16);

            while (registerStr.Length < 2)
            {
                registerStr = registerStr.Insert(0, "0");
            }

            return registerStr;
        }
    }
}

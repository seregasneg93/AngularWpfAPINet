using KratekServices.WorkJobServerWPF.PassedTerminalRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.RegisterConvert
{
    internal class ConvertRegistersFrequencies
    {
        public PrepfrationFrequenciesDB ReceiveValidFreqForBD(PassedFrequencies passedFrequencies)
        {
            PrepfrationFrequenciesDB prepfrationFrequenciesDB = new();


            prepfrationFrequenciesDB = ReceiveValidDataFreq(passedFrequencies.ArrayRegistersFrequencies.ToArray(),
                                                                passedFrequencies.NameFrequencies, passedFrequencies.Modbuss);

            return prepfrationFrequenciesDB;
        }

        PrepfrationFrequenciesDB ReceiveValidDataFreq(byte[] arrayRegisters, string typeFreq,int modbuss)
        {
            PrepfrationFrequenciesDB prepfrationFrequencies = new();

            if(typeFreq == ConstatansVariables.ENG_ITD)
            {
                string validCurrent = $"{arrayRegisters[15]}{arrayRegisters[16]}";
                double validRegister = Convert.ToDouble(validCurrent);

                if (validRegister > 0)
                    validRegister /= 100;

                prepfrationFrequencies.NameFrequencies = typeFreq;
                prepfrationFrequencies.Modbuss = modbuss;
                prepfrationFrequencies.ArrayRegistersFrequencies.Add("Ток", validRegister);

                double validRegister21 = ConvertTo16(arrayRegisters[3], arrayRegisters[4]);
                double validRegister22 = ConvertTo16(arrayRegisters[5], arrayRegisters[6]);

                prepfrationFrequencies.ArrayRegistersFrequencies.Add(ConstatansVariables.ERROR_FREQ, validRegister21);
                prepfrationFrequencies.ArrayRegistersFrequencies.Add(ConstatansVariables.РЕГИСТ_ПРЕДУПРЕЖДЕНИЯ_ITD, validRegister22);
            }

            return prepfrationFrequencies;
        }



        public double ConvertTo16(byte registerHigth, byte registerLow)
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


            return res16;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.RegisterConvert
{
    public class ConvertRegister
    {
        ValidRegister _validRegister = new ValidRegister();
        Table2Register _table2Register = new Table2Register();

        public Dictionary<string, double> ReceiveConvertRegisters(byte[] register, string nameTerminal)
        {
            byte[] arrayRegisres = register;

            return ReceiveValidArrayByte(arrayRegisres, nameTerminal); // метод который выполняет преобразвоние регистров в новый массив
        }

        Dictionary<string, double> ReceiveValidArrayByte(byte[] registersTerminal, string nameTerminal)
        {
            Dictionary<string, double> validRegisters = new Dictionary<string, double>();

            FillArrayRegisters(ref validRegisters, ref registersTerminal); // метод который выполняет логику преобразования регистров

            validRegisters.Add(ConstatansVariables.ПРОПОРЦИЯ_МОЩНОСТИ, registersTerminal[9] * 10); // пропорция мощности
            validRegisters.Add(ConstatansVariables.ДОБАВКА_ТЕМПЕРАТУРЫ, registersTerminal[10]); // добавка температуры
            validRegisters.Add(ConstatansVariables.УСТАВКА_Т_ПОДАЧИ, registersTerminal[11]); // уставка
            validRegisters.Add(ConstatansVariables.МЕТОД_РЕГУЛИРОВКИ, registersTerminal[12]); // метод регулировки
            validRegisters.Add(ConstatansVariables.ПЕРИОД_СТАРТ_СТОП, registersTerminal[13]); // период
            validRegisters.Add(ConstatansVariables.РАСПИСАНИЕ_РАБОТЫ, registersTerminal[14]); // расписание работы
            validRegisters.Add(ConstatansVariables.ЧАСТОТА_ХОЛОСТОГО_ХОДА, registersTerminal[15]); // частота холостого хода
            validRegisters.Add(ConstatansVariables.УСТАВКА_ТЕМПЕРАТУРЫ_БУНКЕРА, registersTerminal[16]); // уставка температуры бугкера
            validRegisters.Add(ConstatansVariables.КОЭФ_ОТ_ИНТЕГРАЛА, registersTerminal[17]); //  коэф от интеграла
            validRegisters.Add(ConstatansVariables.ПРОПОРЦИОНАЛЬНЫЙ_КОЭФ, registersTerminal[18]); // пропорциональный коэф
            validRegisters.Add(ConstatansVariables.УСТАВКА_ТЕМПЕРАТУРЫ, registersTerminal[19]); // температура помещения
            validRegisters.Add(ConstatansVariables.КОЭФ_ОТ_ПРОИЗВОДСТВЕННОЙ, registersTerminal[20]); // коэф от производной
            validRegisters.Add(ConstatansVariables.УПРАВЛЕНИЕ_КОНТРОЛЛЕРОМ, registersTerminal[21]); // Ручное управление 
            validRegisters.Add(ConstatansVariables.НАШ_MODBUS, registersTerminal[22]); //Modbuss adress
            validRegisters.Add(ConstatansVariables.ВРЕМЯ_СТАРТ_СТОП, registersTerminal[45]); // Время стопрт-стоп
            validRegisters.Add(ConstatansVariables.ВЕРХНЯЯ_ТЕМПЕРАТУРА, registersTerminal[46]); // верхняя темпр регудировки


            validRegisters.Add(ConstatansVariables.ГИСТЕРЕЗИС_ТЕМПЕРАТУР, _validRegister.ConvertToGisterezis(Convert.ToDouble(registersTerminal[48]))); // гизтереси темпр
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ПОДАЧИ, _validRegister.ConvertTo16(registersTerminal[63], registersTerminal[64], 1)); // 30 регистр Температура подачи
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_НА_УЛИЦЕ, _validRegister.ConvertTo16(registersTerminal[65], registersTerminal[66], 1)); // 31 регистр температура на улице
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ОБРАТКИ, _validRegister.ConvertTo16(registersTerminal[69], registersTerminal[70], 1));  // 33 регистр темпеература обратки
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ШНЕКА, _validRegister.ConvertTo16(registersTerminal[71], registersTerminal[72], 1)); // 34 регистр температура шнека
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_БУНКЕРА_1, _validRegister.ConvertTo16(registersTerminal[73], registersTerminal[74], 1));  // 35 регистр температура бункера 1
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_БУНКЕРА_2, _validRegister.ConvertTo16(registersTerminal[75], registersTerminal[76], 1)); // 36 регистр температура бункера 2
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ПОМЕЩЕНИЯ, _validRegister.ConvertTo16(registersTerminal[79], registersTerminal[80], 1)); // 38 регистр температура помещения котельной
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ПОДАЧИ_СЕТЕВОГО, _validRegister.ConvertTo16(registersTerminal[81], registersTerminal[82], 1)); // 39 регистр температура подачи сетевого контура
            validRegisters.Add(ConstatansVariables.ТЕМПЕРАТУРА_ОБРАТКИ_СЕТЕВОГО, _validRegister.ConvertTo16(registersTerminal[83], registersTerminal[84], 1)); // 40 регистр температура обратки сетевого контура
            validRegisters.Add(ConstatansVariables.ЦЕНА_СЧЕТЧИКА, _validRegister.ConvertTo16(registersTerminal[85], registersTerminal[86], 2)); // 41 регистр цена счетчика воды
            validRegisters.Add(ConstatansVariables.ЖЕЛАЕМАЯ_ТЕМПЕРАТУРА, _validRegister.ConvertTo16(registersTerminal[87], registersTerminal[88], 1)); // 42 регистр желаема температура воды
            validRegisters.Add(ConstatansVariables.РЕГ_ВРЕМЯ_ПОДАЧИ, _validRegister.ConvertTo16(registersTerminal[89], registersTerminal[90], 3)); // 43 регистр Регулируемое время подачи
            validRegisters.Add(ConstatansVariables.МОЩНОСТЬ_КОТЕЛЬНОЙ, _validRegister.ConvertTo16(registersTerminal[91], registersTerminal[92], 2)); // 44 регистр мощность котельной
            validRegisters.Add(ConstatansVariables.СКОРОСТЬ_ПОТОКА_ВОДЫ, _validRegister.ConvertTo16(registersTerminal[93], registersTerminal[94], 2)); // 45 регистр Скорость потока воды
            validRegisters.Add(ConstatansVariables.ВРЕМЯ_ПОДАЧИ_УГЛЯ, _validRegister.ConvertTo16(registersTerminal[95], registersTerminal[96], 2)); // 46 регистр Время подачи на 1 кг угля
            validRegisters.Add(ConstatansVariables.ОСТАТОК_УГЛЯ, _validRegister.ConvertTo16(registersTerminal[97], registersTerminal[98], 4));  // 47 регистр остаток угля
            validRegisters.Add(ConstatansVariables.ИЗМЕРЕННЫЙ_ПОТОК_ВОДЫ, _validRegister.ConvertTo16(registersTerminal[99], registersTerminal[100], 2)); // 48 регистр измеренный поток воды
            validRegisters.Add(ConstatansVariables.ДОБАВКА_УГЛЯ, _validRegister.ConvertTo16(registersTerminal[101], registersTerminal[102], 0)); // 49 регистр добавка угля при засыпке
            validRegisters.Add(ConstatansVariables.ДАВЛЕНИЕ_С_НЕПРЕРЕЫВНОГО_ДАТЧИКА, _validRegister.ConvertTo16(registersTerminal[103], registersTerminal[104], 5)); // 50 регистр измеренный поток воды сетевого
            validRegisters.Add(ConstatansVariables.СЧЕТЧИК_ТЕПЛА, _validRegister.ConvertToGKal(registersTerminal[143], registersTerminal[144], registersTerminal[145], registersTerminal[146])); // 70 регистр Энергия ГКал

            string convertTo2 = Convert.ToString(registersTerminal[160], 2);

            while (convertTo2.Length != 8)
            {
                convertTo2 = convertTo2.Insert(0, "0");
            }

            convertTo2.Reverse();

            ReceiveRegisterPump(ref validRegisters, convertTo2.Substring(3, 1), ConstatansVariables.УПРАВЛЕНИЕ_НАСОСОМ);// 81 регист состояние насоса 4 выход
            ReceiveRegisterPump(ref validRegisters, convertTo2.Substring(4, 1), ConstatansVariables.УПРАВЛЕНИЕ_НАСОСОМ_РЕЗЕРВ);// 81 регист состояние насоса 5 выход
                                                                                                                               //  validRegisters.Add(ConstatansVariables.УПРАВЛЕНИЕ_НАСОСОМ, registersTerminal[160]);  
                                                                                                                               //  validRegisters.Add(ConstatansVariables.УПРАВЛЕНИЕ_НАСОСОМ, registersTerminal[160]);  

            validRegisters.Add(ConstatansVariables.РАЗНОСТЬ_ТЕМПЕРАТУР, MinusRegister(validRegisters.Where(x => x.Key.Contains(ConstatansVariables.ТЕМПЕРАТУРА_ПОДАЧИ)).Select(x => x.Value).FirstOrDefault(),
            validRegisters.Where(x => x.Key.Contains(ConstatansVariables.ТЕМПЕРАТУРА_ОБРАТКИ)).Select(x => x.Value).FirstOrDefault()));

            validRegisters.Add(ConstatansVariables.РАЗНОСТЬ_ТЕМПЕРАТУР_СЕТЕВОГО, MinusRegister(validRegisters.Where(x => x.Key.Contains(ConstatansVariables.ТЕМПЕРАТУРА_ПОДАЧИ_СЕТЕВОГО)).Select(x => x.Value).FirstOrDefault(),
            validRegisters.Where(x => x.Key.Contains(ConstatansVariables.ТЕМПЕРАТУРА_ОБРАТКИ_СЕТЕВОГО)).Select(x => x.Value).FirstOrDefault()));
            #region Сатрый вариант регистров

            //validRegisters[59] = _validRegister.ConvertTo16(registersTerminal[63], registersTerminal[64], 1); // 30 регистр Температура подачи
            //validRegisters[60] = _validRegister.ConvertTo16(registersTerminal[65], registersTerminal[66], 1); // 31 регистр температура на улице
            //validRegisters[61] = _validRegister.ConvertTo16(registersTerminal[69], registersTerminal[70], 1); // 33 регистр темпеература обратки
            //validRegisters[62] = _validRegister.ConvertTo16(registersTerminal[71], registersTerminal[72], 1); // 34 регистр температура шнека
            //validRegisters[63] = _validRegister.ConvertTo16(registersTerminal[73], registersTerminal[74], 1); // 35 регистр температура бункера 1
            //validRegisters[64] = _validRegister.ConvertTo16(registersTerminal[75], registersTerminal[76], 1); // 36 регистр температура бункера 2
            //validRegisters[65] = _validRegister.ConvertTo16(registersTerminal[79], registersTerminal[80], 1); // 38 регистр температура помещения котельной
            //validRegisters[66] = _validRegister.ConvertTo16(registersTerminal[81], registersTerminal[82], 1); // 39 регистр температура подачи сетевого контура
            //validRegisters[67] = _validRegister.ConvertTo16(registersTerminal[83], registersTerminal[84], 1); // 40 регистр температура обратки сетевого контура
            //validRegisters[68] = _validRegister.ConvertTo16(registersTerminal[85], registersTerminal[86], 2); // 41 регистр цена счетчика воды
            //validRegisters[69] = _validRegister.ConvertTo16(registersTerminal[87], registersTerminal[88], 1); // 42 регистр желаема температура воды
            //validRegisters[70] = _validRegister.ConvertTo16(registersTerminal[89], registersTerminal[90], 2); // 43 регистр Регулируемое время подачи
            //validRegisters[71] = _validRegister.ConvertTo16(registersTerminal[91], registersTerminal[92], 2); // 44 регистр мощность котельной
            //validRegisters[72] = _validRegister.ConvertTo16(registersTerminal[93], registersTerminal[94], 2); // 45 регистр Скорость потока воды
            //validRegisters[73] = _validRegister.ConvertTo16(registersTerminal[95], registersTerminal[96], 2); // 46 регистр Время подачи на 1 кг угля
            //validRegisters[74] = _validRegister.ConvertTo16(registersTerminal[97], registersTerminal[98], 0); // 47 регистр остаток угля
            //validRegisters[75] = _validRegister.ConvertTo16(registersTerminal[99], registersTerminal[100], 2); // 48 регистр измеренный поток воды
            //validRegisters[76] = _validRegister.ConvertTo16(registersTerminal[101], registersTerminal[102], 0); // 49 регистр добавка угля при засыпке
            //validRegisters[77] = _validRegister.ConvertTo16(registersTerminal[103], registersTerminal[104], 2); // 50 регистр измеренный поток воды сетевого
            //validRegisters[78] = _validRegister.ConvertToGKal(registersTerminal[143], registersTerminal[144], registersTerminal[145], registersTerminal[146]); // 70 регистр Энергия ГКал

            //validRegisters[35] = Convert.ToDouble(registersTerminal[10]);// Корректировка мощности
            //validRegisters[36] = Convert.ToDouble(registersTerminal[11]);// уставка
            //validRegisters[37] = Convert.ToDouble(registersTerminal[12]);// метод регулировки
            //validRegisters[38] = Convert.ToDouble(registersTerminal[13]);// период
            //validRegisters[39] = Convert.ToDouble(registersTerminal[14]);// расписание работы
            //validRegisters[40] = Convert.ToDouble(registersTerminal[15]);// частота холостого хода
            //validRegisters[41] = Convert.ToDouble(registersTerminal[16]);// уставка температуры бункера
            //validRegisters[42] = Convert.ToDouble(registersTerminal[17]);// Коэф от интеграла
            //validRegisters[43] = Convert.ToDouble(registersTerminal[18]);// Проаорциональный коэф
            //validRegisters[44] = Convert.ToDouble(registersTerminal[19]);// уставка температуры помещения
            //validRegisters[45] = Convert.ToDouble(registersTerminal[20]);// коэф от производной
            //validRegisters[46] = Convert.ToDouble(registersTerminal[21]);// Ручное управление 
            //validRegisters[47] = Convert.ToDouble(registersTerminal[22]);// Modbuss adress
            //validRegisters[48] = Convert.ToDouble(registersTerminal[45]);// Время стопрт-стоп
            //validRegisters[49] = Convert.ToDouble(registersTerminal[46]);// верхняя темпр регудировки
            //validRegisters[58] = Convert.ToDouble(registersTerminal[48]);// гизтереси темпр


            #endregion

            return validRegisters;
        }

        void FillArrayRegisters(ref Dictionary<string, double> validRegisters, ref byte[] registersTerminal)
        {
            // метод который записывает в новый массив байты ошибок и байты разрешения аварий
            _validRegister.WriteErrorsFromArray(ref validRegisters, registersTerminal[3], registersTerminal[4], registersTerminal[5], registersTerminal[6], registersTerminal[47]);
            _table2Register.TableRegister(ref validRegisters, registersTerminal[7]); // вовзращаем индекс из таблицы для 2 регистра (номер максимального времени подачи)
            _validRegister.ValidIndexFromTwoRegisterLow(ref validRegisters, registersTerminal[8]); // 2 регист (Текущий номер периода подачи)
        }

        public int ReceiveConvertNumber(string number)
        {
            string indexLo = number.Substring(0, 1);
            string indexHi = number.Substring(1, 1);

            var resLo = ReceiveIndexConvert(indexLo);
            var resHi = ReceiveIndexConvert(indexHi);

            var result = resLo * 16 + resHi;

            return result;
        }

        int ReceiveIndexConvert(string number)
        {
            if (number.Contains("a"))
            {
                number = number.Replace("a", "10");
            }
            else if (number.Contains("b"))
            {
                number = number.Replace("b", "11");
            }
            else if (number.Contains("c"))
            {
                number = number.Replace("c", "12");
            }
            else if (number.Contains("d"))
            {
                number = number.Replace("d", "13");
            }
            else if (number.Contains("e"))
            {
                number = number.Replace("e", "14");
            }
            else if (number.Contains("f"))
            {
                number = number.Replace("f", "15");
            }
            return Convert.ToInt32(number);
        }

        double MinusRegister(double validRegisters, double validRegisters2)
        {
            return Math.Round(validRegisters - validRegisters2, 1);
        }

        void ReceiveRegisterPump(ref Dictionary<string, double> validRegisters, string index, string namePump)
        {
            validRegisters.Add(namePump, Convert.ToDouble(index));
        }
    }
}

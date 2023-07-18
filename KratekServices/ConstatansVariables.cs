using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices
{
    public class ConstatansVariables
    {
        #region Константы перменных в коде

        public const string ENG_ITD = "ITD";
        public const string ENG_ISD = "ISD";
        public const string ENG_ISD_MINI = "ISD Mini";
        public const string ENG_ISD_MINI_PLUS = "ISD Mini Plus";
        public const string ENG_PMG = "PMG";

        #endregion

        #region Константы описания регистров

        public const string ФЛАГ_ОШИБОК = "Ошибки";
        public const string ФЛАГ_РАЗРЕШЕНИЯ_АВАРИЯ = "Разрешение аварий";
        public const string ФЛАГ_ДАННЫЕ = "Данные";

        public const string ОШИБКА_RAM = "Ошибка RAM";
        public const string ОГОНЬ_В_ШНЕКЕ = "Огонь в шнеке";
        public const string АВАРИЯ_В_ШНЕКЕ = "Авария подачи угля";
        public const string НЕТ_ПРОТОКА_ВОДЫ = "Нет протока воды";
        public const string АВАРИЯ_ПОДДУВА = "Авария поддува";
        public const string АВАРИЯ_ДЫМОСОСА = "Авария дымососа";
        public const string ОШИБКА_ДАТЧИКОВ = "Ошибка датчиков температуры";
        public const string ПРЕВЫШЕНИЕ_РАЗНИЦЫ = "Превышение разницы температуры подачи";
        public const string НИЗКОЕ_ДАВЛЕНИЕ = "Низкое давление";
        public const string ОГОНЬ_В_БУНКЕРЕ = "Огонь в бункере";
        public const string НЕТ_220 = "Нет 220 вольт";
        public const string ВКЛЮЧЕНА_ПОДПИТКА_ВОДЫ = "Включена подпитка воды";
        public const string ОШИБКА_АНАЛ_ДАТЧИКА_ПОДАЧИ = "Ошибка аналогово датчика Т подачи";
        public const string ОШИБКА_АНАЛ_ДАТЧИКА_ШНЕКА = "Ошибка аналогово датчика Т шнека";
        public const string НЕТ_ПРОТОКА_ВОДЫ_ПО_2_ДАТЧИКУ = "Нет протока воды(по второму датчику)";
        public const string РЕЖИМ_РУЧНОГО_УПРАВЛЕНИЯ = "Режим ручного управления";
        public const string ДАТЧИК_ВРАЩЕНИЯ = "Разрешение аварии шнека.";
        public const string ВОДЯНОЙ_НАСОС = "Разрешение аварии протока воды.";
        public const string ДАТЧИК_ТЕМПЕРАТУРЫ = "Разрешние аварии датчиков.";
        public const string АВАРИЯ_РЕГУЛИРОВАНИЯ = "Разрешение аварии регулирования.";
        public const string РАЗРЕШЕНИЕ_НИЗКОЕ_ДАВЛЕНИЕ = "Разрешение аварии низкое давление";
        public const string РАЗРЕШЕНИЕ_АВАРИИ_ЗОЛЬНИКА = "Разрешение аварии зольника";
        public const string UNKNOW_3 = "unknown3";
        public const string UNKNOW_4 = "unknown4";
        public const string ДЫМОСОС_ВКЛЮЧЕН_ПОСТОЯННО = "Дымосос работает постоянно.";
        public const string РЕВЕРС_РАБОТАЕТ = "Режим работы реверса.";
        public const string ЕСТЬ_ДАТЧИК_ГОРЯЧЕЙ_ВОДЫ = "Источник скорости протока воды.";
        public const string ПРОИЗОШЛО_ДОБАВЛЕНИЕ_УГЛЯ = "Произошло добавление угля";
        public const string ДАТЧИК_ДАВЛЕНИЯ_АВАРИИ = "Датчик давления аварии при замыкании/размыкании";
        public const string РЕГУЛИРОВКА_ПОДДУВА = "Регулировка поддува дискретная/плавная";
        public const string ПЛАВНАЯ_РЕГУЛИРОВКА = "Плавная регулировка подачи топлива дискретная/плавная";
        public const string UNKNOW_7 = "unknown7";

        // EN_ERR_Flag2
        public const string ОШИБКА_ЗОЛЬНИКА = "Ошибка зольника";
        public const string ПЕРЕГРЕВ_ПОМЕЩЕНИЯ = "Перегрев помещения";
        public const string UNKNOW_8 = "unknown8";
        public const string UNKNOW_9 = "unknown9";
        public const string UNKNOW_10 = "unknown10";
        public const string UNKNOW_11 = "unknown11";
        public const string UNKNOW_12 = "unknown12";
        public const string UNKNOW_13 = "unknown13";
        // Services
        public const string ТЕКУЩИЙ_НОМЕР_ПЕРИОДА = "Пероид подачи,мин.";
        public const string НОМЕР_МАКСИМАЛЬНОГО_ВРЕМЕНИ = "Максимальное время подачи, сек.";
        public const string ДОБАВКА_ТЕМПЕРАТУРЫ = "Корректировка мощности.";
        public const string ПРОПОРЦИЯ_МОЩНОСТИ = "Пропорция мощности , %";
        public const string МЕТОД_РЕГУЛИРОВКИ = "Метод регулировки температуры";
        public const string УСТАВКА_Т_ПОДАЧИ = "Уставка температуры подачи °С";
        public const string РАСПИСАНИЕ_РАБОТЫ = "Расписание работы";
        public const string ПЕРИОД_СТАРТ_СТОП = "Период старт-стопа,часы";
        public const string ВРЕМЯ_СТАРТ_СТОП = "Время старт-стопа,мин";
        public const string ВЕРХНЯЯ_ТЕМПЕРАТУРА = "Верхняя температура регулировки";
        public const string УСТАВКА_ТЕМПЕРАТУРЫ_БУНКЕРА = "Уставка температуры бункера, °С";
        public const string ПРОПОРЦИОНАЛЬНЫЙ_КОЭФ = "Пропорциональный коэф регулировки по Т подачи";
        public const string КОЭФ_ОТ_ИНТЕГРАЛА = "Интегральный коэф регулировки по Т подачи";
        public const string КОЭФ_ОТ_ПРОИЗВОДСТВЕННОЙ = "Дифференциальный коэф регулировки по Т подачи";
        public const string УСТАВКА_ТЕМПЕРАТУРЫ = "Температура помещения, °С";
        public const string ЧАСТОТА_ХОЛОСТОГО_ХОДА = "Частота холостого хода %";
        public const string НАШ_MODBUS = "Сетевой адресс";
        public const string УПРАВЛЕНИЕ_КОНТРОЛЛЕРОМ = "Управление контроллером";
        public const string ГИСТЕРЕЗИС_ТЕМПЕРАТУР = "Гистерезис температур";
        public const string БИТЫ_ОШИБОК_22 = "Биты ошибок 22 регистр";
        public const string ТЕМПЕРАТУРА_ПОДАЧИ = "Температура подачи, °С";
        public const string ТЕМПЕРАТУРА_НА_УЛИЦЕ = "Температура на улице, °С";
        public const string ТЕМПЕРАТУРА_ОБРАТКИ = "Температура обратки, °С";
        public const string РАЗНОСТЬ_ТЕМПЕРАТУР = "Разность температур, °С";
        public const string РАЗНОСТЬ_ТЕМПЕРАТУР_СЕТЕВОГО = "Разность температур сетевого, °С";
        public const string ТЕМПЕРАТУРА_ШНЕКА = "Температура шнека, °С";
        public const string ТЕМПЕРАТУРА_БУНКЕРА_1 = "Температура бункера 1, °С";
        public const string ТЕМПЕРАТУРА_БУНКЕРА_2 = "Температура бункера 2, °С";
        public const string ЗАРЕЗЕРВИРОВАНО = "Зарезервировано";
        public const string ЗАРЕЗЕРВИРОВАНО_ = "Зарезервировано_";
        public const string ЗАРЕЗЕРВИРОВАНО__ = "Зарезервировано__";
        public const string ТЕМПЕРАТУРА_ПОМЕЩЕНИЯ = "Температура помещения котельной, °С";
        public const string ТЕМПЕРАТУРА_ПОДАЧИ_СЕТЕВОГО = "Температура подачи сетевого контура, °С";
        public const string ТЕМПЕРАТУРА_ОБРАТКИ_СЕТЕВОГО = "Температура обратки сетевого контура, °С";
        public const string РАЗНОСТЬ_СЕТЕВОГО_КОНТУРА = "Разность сетевого контура, °С";
        public const string ЦЕНА_СЧЕТЧИКА = "Вес импульса счетчика воды, л/имп.";
        public const string ЖЕЛАЕМАЯ_ТЕМПЕРАТУРА = "Установленная Т подачи, °С";
        public const string РЕГ_ВРЕМЯ_ПОДАЧИ = "Время подачи, сек.";
        public const string МОЩНОСТЬ_КОТЕЛЬНОЙ = "Мощность котельной, кВт";
        public const string СКОРОСТЬ_ПОТОКА_ВОДЫ = "Скорость потока воды или цена счетчика, м3/ч";
        public const string ВРЕМЯ_ПОДАЧИ_УГЛЯ = "Время подачи на килограмм угля, сек.";
        public const string ОСТАТОК_УГЛЯ = "Остаток угля в бункере, кг.";
        public const string ИЗМЕРЕННЫЙ_ПОТОК_ВОДЫ = "Измеренный поток воды, м3/ч";
        public const string ДОБАВКА_УГЛЯ = "Добавка угля, кг.";
        public const string ДАВЛЕНИЕ_С_НЕПРЕРЕЫВНОГО_ДАТЧИКА = "Давление с непрерывного датчика в КПа";
        public const string СЧЕТЧИК_ТЕПЛА = "Энергия, Гкал";
        public const string АБСОЛЮТНОЕ_ВРЕМЯ = "Абсолютное время.";
        public const string КОМАНДА_ДИСТАНЦИОННОГО_УПРАВЛЕНИЯ = "76-77 команда дистанционного управления";
        public const string РАЗРЕШЕНИЕ_ДИСТАЦИОННОГО_УПРАВЛЕНИЯ = "Разрешения дистанционного управления, 32 бита на 32 выхода";
        public const string СОСТОЯНИЕ_ВЫХОДОВ = "Состояния выходов, 32 бита на 32 выхода";
        public const string УПРАВЛЕНИЕ_НАСОСОМ = "Состояние управления насосом";
        public const string УПРАВЛЕНИЕ_НАСОСОМ_РЕЗЕРВ = "Состояние управления резервным насосом";
        public const string ФЛАГ_ОШИБКИ = "Флаги ошибок";
        // accident
        public const string АВАРИЯ_ПРЕВЫШЕНИЯ = "Авария превышения разницы Т подачи.";
        public const string АВАРИЯ_КРИТИЧЕСКОЕ_СНИЖЕНИЕ = "Авария критическое снижение температуры.";
        public const string АВАРИЯ_НЕТ_ГОРЕНИЯ = "Авария нет горения!";
        public const string РАСХОД_УГЛЯ = "Расход угля (усредненный за час),кг/ч";
        public const string ВРЕМЯ_ДО_ОПУСТОШЕНИЯ = "Время до опустошения бункера,дн.";
        public const string УГЛЯ_МЕНЬШЕ_ЧЕМ_НА_СУТКИ = "Угля меньше чем на сутки.";
        public const string ПОТЕРЯ_МОЩНОСТИ = "Потеря мощности.";
        public const string УМЕНЬШЕНИЕ_ПРОТОКА_15 = "Уменьшение протока воды на  15%";
        public const string ТЕМПЕРАТУРА_ОБРАТКИ_НИЖЕ_5 = "Температура обратки ниже +5";
        public const string ТЕМПЕРАТУРА_ПОДАЧИ_НИЖЕ_15 = "Температура подачи ниже +15";
        public const string ГАШЕНИЕ_КОТЕЛЬНОЙ = "Производится гашение котельной.";
        // settnigsTerminal
        public const string ЭНЕРГИЯ_НА_1_КГ = "Энергия на 1 кг. угля";
        public const string НОРМА_ПРОТОКА_ВОДЫ = "Норма протока воды";
        public const string ВМЕСТИМОСТЬ_БУНКЕРА = "Вместимость бункера";
        public const string МоЩНОСТЬ_КОТЛА = "Мощность котла";
        public const string ДАННЫЕ_ДОБАВЛЕНЫ = "Данные добавлены.";
        public const string ОШИБКА_ПОРТА = "Ошибка порта или порт занят!";
        public const string ИЗМЕНЕНЕНИЕ_ТЕРМИНАЛА = "Данные изменены на терминале";
        public const string СВЯЗЬ_УСТАНОВЛЕНА = "Связь установлена";
        public const string МОДЕМ_НЕ_ОТВЕЧАЕТ = "Не отвечает модем.";
        // индексы регимстров
        public const string ПО_УЛИЦЕ = "По улице";
        public const string ПО_ДЛИТЕЛЬНОСТИ = "По длительности";
        public const string ПО_Т_ПОДАЧИ = "По t подачи";
        public const string НЕПРЕРЫВНАЯ = "Непрерывная";
        public const string ГОРЯЧЕЕ_ВОДОСНАБЖЕНИЕ = "Горячее водоснабжение";
        public const string СТАРТ_СТОП = "Старт-стоп";
        public const string ГАШЕНИЕ_КОТЕЛЬНОЙ_ИНДЕКС = "Гашение котельной";
        // роли сервера
        public const string ДИСПЕТЧЕР = "Диспетчер";
        public const string ОПЕРАТОР = "Оператор";
        public const string ПОЛЬЗОВАТЕЛЬ = "Пользователь";
        // версии прошивок
        public const string ВЕРСИЯ_2014_01_09 = "2014.01.09";
        public const string ВЕРСИЯ_2014_01_24 = "2014.01.24";
        public const string ВЕРСИЯ_2014_03_12 = "2014.03.12";
        public const string ВЕРСИЯ_2014_03_13 = "2014.03.13";
        public const string ВЕРСИЯ_2014_03_21 = "2014.03.21";
        public const string ВЕРСИЯ_2016_02_17 = "2016.02.17";
        public const string ВЕРСИЯ_2016_04_14 = "2016.04.14";
        public const string ВЕРСИЯ_2018_03_27 = "2018.03.27";
        public const string ВЕРСИЯ_2018_09_15 = "2018.09.15";
        public const string ВЕРСИЯ_2020_07_17 = "2020.07.17";
        public const string ВЕРСИЯ_2021_09_29 = "2021.09.29";
        public const string ВЕРСИЯ_2021_08_30 = "2021.08.30";
        #endregion


        #region Константы ошибок частотников 

        #region ITD

        public const string НЕДОСТАТОЧНОЕ_НАПРЯЖЕНИЕ_ШИНЫ = "Ошибка недостаточного напряжения шины";
        public const string СВЕРХТОК_ПРИ_УСКОРЕНИИ = "Сверхток при ускорении";
        public const string СВЕРХТОК_ПРИ_ЗАМЕДЛЕНИИ = "Сверхток при замедлении";
        public const string СВЕРХТОК_ПРИ_СКОРОСТИ = "Сверхток при постоянной скорости";
        public const string ПЕРЕНАПРЯЖЕНИЕ_ПРИ_УСКОРЕНИИ = "Перенапряжение при ускорении";
        public const string ПЕРЕНАПРЯЖЕНИЕ_ПРИ_ЗАМЕДЛЕНИИ = "Перенапряжение при замедлении";
        public const string ПЕРЕНАПРЯЖЕНИЕ_ПРИ_ПОСТОЯННОЙ_СОКРОСТИ = "Перенапряжение при постоянной скорости";
        public const string ОШИБКА_ЗАЗЕМЛЕНИЯ = "Ошибка заземления";
        public const string КОРОТКОЕ_ЗАМЫКАНИЕ_НАГРУЗКИ = "Короткое замыкание нагрузки";
        public const string ПЕРЕГРЕВ_РАДИАТОРА = "Перегрев радиатора";
        public const string ПЕРЕГРУЗКА_ДВИГАТЕЛЯ = "Перегрузка двигателя";
        public const string ПЕРЕГРУЗКА_ПРЕОБРАЗОВАТЕЛЯ = "Перегрузка преобразователя";
        public const string ОШИБКА_СВЯЗИ = "Ошибка связи";
        public const string ОШИБКА_ВНЕШНЕЙ_КЛЕМЫ = "Ошибка внешней клеммы";
        public const string ОБРЫВ_ИЛИ_ДСБАЛАНС_ВХОДНОЙ_ФАЗЫ = "Обрыв или дисбаланс входной фазы";
        public const string ОБРЫВ_ИЛИ_ДСБАЛАНС_ВЫХОДНОЙ_ФАЗЫ = "Обрыв или дисбаланс выходной фазы";
        public const string ОШИБКА_EEPROM = "Ошибка EEPROM";
        public const string СВЯЗЬ_МЕЖДУ_ПРЕОБРАЗОВАТЕЛМ_НЕ_УСТАНОВЛЕНА = "Связь между преобразователем и клавиатурой не может быть установлена";
        public const string ОШИБКА_ТОРМОЗНОГО_УСТРОЙСТВА = "Ошибка тормозного устройства";
        public const string ОШИБКА_КОПИРОВАПНИЯ_ПРАМЕТРОВ = "Ошибка копирования параметров";
        public const string ОШИБКА_ОБНАРУЖЕНИЯ_ТОКА = "Ошибка обнаружения тока холла";
        public const string ОШИБКА_PG = "Ошибка PG";

        public const string НЕТ_ПРЕДУПРЕЖДЕНИЯ_ЧАСТОТНИКА = "Нет предупреждения";
        public const string ПРЕДУПРЕЖДЕНИЕ_НЕДОСТАТОЧНОГО_НАПРЯЖЕНИЯ_ШИНЫ = "Предупреждение недостаточного напряжения шины";
        public const string ПРЕДУПРЕЖДЕНИЕ_ПЕРЕГРУЗКИ_ПРЕОБРАЗОВАТЕЛЯ = "Предупреждение перегрузки преобразователя";
        public const string ПРЕДУПРЕЖДЕНИЕ_ПЕРЕГРЕВА_ПРЕОБРАЗОВАТЕЛЯ = "Предупреждение перегрева преобразователя";
        public const string ПРЕДУПРЕЖДЕНИЕ_ВЫХОДНЫЕ_КЛЕММЫ_НЕ_ВЫПОЛНЯЮТ = "Выходные клеммы не выполняют одновременно функцию 10";

        public const string РЕГИСТ_ОШИБКИ_ITD = "Ошибка ITD";
        public const string РЕГИСТ_ОШИБКИ_ЧАСТОТНИКА = "Ошибка ITD";
        public const string РЕГИСТ_ОШИБКИ_ISD = "Ошибка ISD";
        public const string РЕГИСТ_ОШИБКИ_PMG = "Ошибка PMG";
        public const string РЕГИСТ_ПРЕДУПРЕЖДЕНИЯ_ITD = "Предупреждение";
        public const string РЕГИСТР_ТОК_ITD = "ITD";
        public const string РЕГИСТР_ТОК_ISD = "ISD";
        public const string ERROR_FREQ = "Ошибка";
        public const string РЕГИСТР_ТОК_ISD_MINI = "ISD Mini";
        public const string РЕГИСТР_ТОК_ISD_MINI_PLUS = "ISD Mini Plus";
        public const string РЕГИСТР_ТОК_PMG = "PMG";
        #endregion

        #endregion


        public static List<string> CoolectionErrorsAndFlags2 = new List<string>()
        {
            НИЗКОЕ_ДАВЛЕНИЕ,
            ОГОНЬ_В_БУНКЕРЕ,
            НЕТ_220,
            ВКЛЮЧЕНА_ПОДПИТКА_ВОДЫ,
            ОШИБКА_АНАЛ_ДАТЧИКА_ПОДАЧИ,
            ОШИБКА_АНАЛ_ДАТЧИКА_ШНЕКА,
            НЕТ_ПРОТОКА_ВОДЫ_ПО_2_ДАТЧИКУ,
           // АВАРИЯ_КРИТИЧЕСКОЕ_СНИЖЕНИЕ,
            РЕЖИМ_РУЧНОГО_УПРАВЛЕНИЯ,

            ОШИБКА_RAM,
            ОГОНЬ_В_ШНЕКЕ,
            АВАРИЯ_В_ШНЕКЕ,
            НЕТ_ПРОТОКА_ВОДЫ,
            АВАРИЯ_ПОДДУВА,
            АВАРИЯ_ДЫМОСОСА,
            ОШИБКА_ДАТЧИКОВ,
            ПРЕВЫШЕНИЕ_РАЗНИЦЫ,

            //ГАШЕНИЕ_КОТЕЛЬНОЙ,

            ДЫМОСОС_ВКЛЮЧЕН_ПОСТОЯННО,
            РЕВЕРС_РАБОТАЕТ,
            ЕСТЬ_ДАТЧИК_ГОРЯЧЕЙ_ВОДЫ,
            ПРОИЗОШЛО_ДОБАВЛЕНИЕ_УГЛЯ,
            ДАТЧИК_ДАВЛЕНИЯ_АВАРИИ,
            РЕГУЛИРОВКА_ПОДДУВА,
            ПЛАВНАЯ_РЕГУЛИРОВКА,
            //ПОТЕРЯ_МОЩНОСТИ,

            ДАТЧИК_ВРАЩЕНИЯ,
            ВОДЯНОЙ_НАСОС,
            ДАТЧИК_ТЕМПЕРАТУРЫ,
            АВАРИЯ_РЕГУЛИРОВАНИЯ,
            РАЗРЕШЕНИЕ_НИЗКОЕ_ДАВЛЕНИЕ,
            РАЗРЕШЕНИЕ_АВАРИИ_ЗОЛЬНИКА,

            ПЕРЕГРЕВ_ПОМЕЩЕНИЯ,
            ОШИБКА_ЗОЛЬНИКА
        };
    }
}

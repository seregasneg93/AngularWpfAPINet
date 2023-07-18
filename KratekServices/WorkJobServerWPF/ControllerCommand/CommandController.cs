using KratekServices.Logger;
using KratekServices.WorkJobServerWPF.RegisterConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.ControllerCommand
{
    internal class CommandController
    {
        public byte[] PreparationCommandForReadRegisters(int modbuss)
        {
            byte[] registers = new byte[6];

            registers[0] = (byte)modbuss;
            registers[1] = 0x03;
            registers[2] = 0x00;
            registers[3] = 0x00;
            registers[4] = 0x00;
            registers[5] = 0x54;

            return registers;
        }

        public byte[] PreparationCommandForReadRegistersCRC(byte[] praparationArray)
        {
            ConvertRegister convertRegister = new();

            byte[] crc = new byte[8];

            byte[] data = new byte[8];

            crc[0] = praparationArray[0];
            crc[1] = praparationArray[1];
            crc[2] = praparationArray[2];
            crc[3] = praparationArray[3];
            crc[4] = praparationArray[4];
            crc[5] = praparationArray[5];


            UInt16 crc2 = 0xFFFF;

            for (int pos = 0; pos < praparationArray.Length; pos++)
            {
                crc2 ^= (UInt16)praparationArray[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)      // Loop over each bit
                {
                    if ((crc2 & 0x0001) != 0)        // If the LSB is set
                    {
                        crc2 >>= 1;                    // Shift right and XOR 0xA001
                        crc2 ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                    {
                        crc2 >>= 1;                    // Just shift right
                    }
                }
            }

            string int16 = Convert.ToString(crc2, 16);

            while (int16.Length != 4)
                int16 = int16.Insert(0, "0");

            string reglo = int16.Substring(0, 2);
            string reghi = int16.Substring(2, 2);

            var resLo = convertRegister.ReceiveConvertNumber(reglo); // пр
            var resHi = convertRegister.ReceiveConvertNumber(reghi);

            crc[6] = (byte)resHi;
            crc[7] = (byte)resLo;

            return crc;
        }


        public byte[] ReceiveValidArrayByteChastotnick(int slaveId, string typeFreq)
        {
            byte[] Read = null;
            Read = new byte[6];
            if (typeFreq.Equals(ConstatansVariables.ENG_ITD))
            {
                Read[0] = (byte)slaveId;
                Read[1] = 0x03;
                Read[2] = 0x00;
                Read[3] = 33;//
                Read[4] = 0x00;
                Read[5] = 9;
            }
            else if (typeFreq.Equals(ConstatansVariables.ENG_ISD) || typeFreq.Equals(ConstatansVariables.ENG_ISD_MINI) || typeFreq.Equals(ConstatansVariables.ENG_ISD_MINI_PLUS))
            {
                Read[0] = (byte)slaveId;
                Read[1] = 0x03;
                Read[2] = 0x00;
                Read[3] = 0x01;
                Read[4] = 0x00;
                Read[5] = 0x12;
            }
            else if (typeFreq.Equals(ConstatansVariables.ENG_PMG))
            {
                Read[0] = (byte)slaveId;
                Read[1] = 0x03;
                Read[2] = 0x00;
                //Read[3] = 0x01;
                //Read[4] = 0x00;
                //Read[5] = 0x05;
                Read[3] = 0x08; // посылка на чтение регистра тока и ошибок
                Read[4] = 0x00;
                Read[5] = 0x08;
            }

            return Read;
        }


        public byte[] PreparationCommandForReadPollFreq(byte[] arrayChastotnick)
        {
            ConvertRegister convertRegister = new();

            byte[] arrayCRC = new byte[arrayChastotnick.Length + 2];

            //crc[0] = requestFromController[0];
            //crc[1] = requestFromController[1];
            //crc[2] = requestFromController[2];
            //crc[3] = requestFromController[3];
            //crc[4] = requestFromController[4];
            //crc[5] = requestFromController[5];
            //crc[6] = requestFromController[6];
            //crc[7] = requestFromController[7];
            //crc[8] = requestFromController[8];


            UInt16 crc2 = 0xFFFF;

            for (int pos = 0; pos < arrayChastotnick.Length; pos++)
            {
                crc2 ^= (UInt16)arrayChastotnick[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)      // Loop over each bit
                {
                    if ((crc2 & 0x0001) != 0)        // If the LSB is set
                    {
                        crc2 >>= 1;                    // Shift right and XOR 0xA001
                        crc2 ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                    {
                        crc2 >>= 1;                    // Just shift right
                    }
                }
            }

            string int16 = Convert.ToString(crc2, 16);

            while (int16.Length != 4)
                int16 = int16.Insert(0, "0");

            string reglo = int16.Substring(0, 2);
            string reghi = int16.Substring(2, 2);

            var resLo = convertRegister.ReceiveConvertNumber(reglo); // пр
            var resHi = convertRegister.ReceiveConvertNumber(reghi);

            int indexHi = arrayCRC.Length - 2;
            int indexLo = arrayCRC.Length - 1;

            for (int i = 0; i < arrayCRC.Length; i++)
            {
                if (i == indexHi)
                {
                    arrayCRC[i] = (byte)resHi;
                    continue;
                }
                else if (i == indexLo)
                {
                    arrayCRC[i] = (byte)resLo;
                    continue;
                }

                arrayCRC[i] = arrayChastotnick[i];
            }

            //  arrayCRC[9] = (byte)resHi;
            // arrayCRC[10] = (byte)resLo;

            return arrayCRC;

            //byte[] crc = new byte[8];

            //byte[] data = new byte[8];

            //crc[0] = arrayChastotnick[0];
            //crc[1] = arrayChastotnick[1];
            //crc[2] = arrayChastotnick[2];
            //crc[3] = arrayChastotnick[3];
            //crc[4] = arrayChastotnick[4];
            //crc[5] = arrayChastotnick[5];


            //UInt16 crc2 = 0xFFFF;

            //for (int pos = 0; pos < arrayChastotnick.Length; pos++)
            //{
            //    crc2 ^= (UInt16)arrayChastotnick[pos];          // XOR byte into least sig. byte of crc

            //    for (int i = 8; i != 0; i--)      // Loop over each bit
            //    {
            //        if ((crc2 & 0x0001) != 0)        // If the LSB is set
            //        {
            //            crc2 >>= 1;                    // Shift right and XOR 0xA001
            //            crc2 ^= 0xA001;
            //        }
            //        else                            // Else LSB is not set
            //        {
            //            crc2 >>= 1;                    // Just shift right
            //        }
            //    }
            //}

            //string int16 = Convert.ToString(crc2, 16);

            //while (int16.Length != 4)
            //    int16 = int16.Insert(0, "0");

            //string reglo = int16.Substring(0, 2);
            //string reghi = int16.Substring(2, 2);

            //var resLo = _convertNumberRegisters.ReceiveConvertNumber(reglo); // пр
            //var resHi = _convertNumberRegisters.ReceiveConvertNumber(reghi);

            //crc[6] = (byte)resHi;
            //crc[7] = (byte)resLo;

            //return crc;
        }


        public int ReceiveValidCRC(byte[] arrayFromTerminal, string nameTerminal)
        {
            byte[] validArray = new byte[171];

            for (int i = 0; i < arrayFromTerminal.Length - 84; i++)
            {
                validArray[i] = arrayFromTerminal[i];
            }


            UInt16 crc2 = 0xFFFF;

            for (int pos = 0; pos < validArray.Length; pos++)
            {
                crc2 ^= (UInt16)validArray[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)      // Loop over each bit
                {
                    if ((crc2 & 0x0001) != 0)        // If the LSB is set
                    {
                        crc2 >>= 1;                    // Shift right and XOR 0xA001
                        crc2 ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                    {
                        crc2 >>= 1;                    // Just shift right
                    }
                }
            }

            string int16 = Convert.ToString(crc2, 16);

            string int162 = Convert.ToString(arrayFromTerminal[171], 16);
            string int163 = Convert.ToString(arrayFromTerminal[172], 16);

            while (int162.Length != 2)
                int162 = int162.Insert(0, "0");

            while (int163.Length != 2)
                int163 = int163.Insert(0, "0");

            while (int16.Length != 4)
                int16 = int16.Insert(0, "0");

            string res = int163 + int162;

            if (int16.ToUpper().Equals(res.ToUpper()))
            {
                LoggerApp.LogValidCRCTerminal.Information($"CRC совпали с терминала - {res} На стороне сервера - {int16} - Имя терминала {nameTerminal}");
                return 1;
            }
            else
            {
                LoggerApp.LogValidCRCTerminal.Error($"CRC не совпали с терминала - {res} На стороне сервера - {int16} - Имя терминала {nameTerminal}");
                return -1;
            }
        }

    }
}

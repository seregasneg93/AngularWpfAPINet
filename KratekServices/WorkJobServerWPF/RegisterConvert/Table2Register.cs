using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.RegisterConvert
{
    internal class Table2Register
    {
        readonly double[] _arrayTableRegister = {1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7,7.5,8,8.5,9,9.5,10,11,12,13,14,15,16,17,18,19,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52,54,56,58,60,62,64,66,68,70,72,74,76,
                                            78,80,82,84,86,88,90,92,94,96,98,100,110,120,130,140,150,160,170,180,190,200};

        public void TableRegister(ref Dictionary<string, double> registersArray, byte register)
        {
            double validIndex = _arrayTableRegister.ElementAtOrDefault(register);

            registersArray.Add(ConstatansVariables.НОМЕР_МАКСИМАЛЬНОГО_ВРЕМЕНИ, validIndex);
        }
    }
}

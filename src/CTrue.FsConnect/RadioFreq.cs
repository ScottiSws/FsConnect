using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrue.FsConnect
{
    public static class RadioFreq
    {
        public static uint Mhz2Hz(decimal freqMhz)
        {
            return (uint)(freqMhz * 1000000);
        }

        public static decimal Bcd32Khz2Mhz(uint bcd32)
        {
            var freqOutUint = Bcd.Bcd2UInt(bcd32); 
            return (Decimal)freqOutUint / 10000;
        }
    }
}

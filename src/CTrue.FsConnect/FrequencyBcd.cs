using System;

namespace CTrue.FsConnect
{
    public class FrequencyBcd
    {
        private decimal _value = 0;
        private uint _bcd16Value = 0;
        private uint _bcd32Value = 0;

        public decimal Value => _value;

        /// <summary>
        /// Gets the BCD encoded as 32 bit.
        /// </summary>
        public uint Bcd32Value => _bcd32Value;

        /// <summary>
        /// Gets the BCD encoded as 16 bit.
        /// </summary>
        public uint Bcd16Value => _bcd16Value;

        public FrequencyBcd(Decimal freqValue)
        {
            _value = freqValue;

            uint uintFreq = (uint)(freqValue * 1000);
            _bcd32Value = Bcd.UInt2Bcd(uintFreq);
            _bcd16Value = (_bcd32Value >> 4) & 0xFFFF;

            /*uint encodable = (uint)((_value - 100) * 100);
            double remainder = ((_value * 100) - encodable) / 100.0;

            _bcd16Value = Bcd.UInt2Bcd(encodable);

            Byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(freqValue * 1000000));
            _bcd32Value = BitConverter.ToUInt32(bytes, 0);*/
        }

        public FrequencyBcd(uint bcd32Value)
        {
            _bcd32Value = bcd32Value;
            var freqOutUint = Bcd.Bcd2UInt(_bcd32Value);
            _value = (Decimal)freqOutUint / 10000;
        }

        public FrequencyBcd(ushort bcd16Value)
        {
            _bcd16Value = bcd16Value;
            _bcd32Value = (_bcd16Value << 4) | 0x10000;
            _value = ((Decimal)Bcd.Bcd2UInt(_bcd32Value)) / 1000;


            /*var freqOutUint = Bcd.Bcd2UInt(_bcd16Value);
            var tmp = freqOutUint + 10000;
            _value = (double)tmp / 100;*/
            //_value = Math.Round(_value * 4, MidpointRounding.ToEven) / 4;
        }

        public override string ToString() => $"{base.ToString()}, Bcd32Value = {Bcd32Value}:0x{Bcd32Value:X8}, Bcd16Value = {Bcd16Value}:0x{Bcd16Value:X8}";
    }
}
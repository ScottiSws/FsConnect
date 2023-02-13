using System;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class BcdTests
    {
        static uint[] testFreqGood = new uint[]
        {
            128775,
            128770,
            12775,
            1277,
            127,
            12,
            1,
            0,
            10000000,
            99999999,
            11111111,
        };

        // Number that have to many digits for BCD32
        static uint[] testFreqBad = new uint[]
        {
            123456789,
            100000000,
            111111111,
            1000000000,
            1111111111,
        };

        [Test]
        [TestCaseSource(nameof(testFreqGood))]
        public void Test(uint testFreq)
        {

            uint bcdFreq = Bcd.UInt2Bcd(testFreq);
            
            //Packed BCD32 will convert to Hex
            String bcdHex = bcdFreq.ToString("X8");
            String uintDec = testFreq.ToString("D8");
            Assert.That(bcdHex, Is.EqualTo(uintDec));

            uint uintFreq = Bcd.Bcd2UInt(bcdFreq);
            Assert.That(uintFreq, Is.EqualTo(testFreq));
        }

        [Test]
        [TestCaseSource(nameof(testFreqBad))]
        public void Test2(uint testFreqBad)
        {
            uint bcdFreq = Bcd.UInt2Bcd(testFreqBad);

            //Packed BCD32 will convert to Hex
            String bcdHex = bcdFreq.ToString("X8");
            String uintDec = testFreqBad.ToString("D8");
            //Numbers that have more than 8 digits will fail and be truncated on MSB
            String uintDecTrunc = uintDec.Substring(Math.Max(0, uintDec.Length - 8));
            Assert.That(bcdHex, Is.EqualTo(uintDecTrunc));
        }

        /*[Test]
        public void Test1()
        {
            /*
            def to_radio_bcd16(val):
              encodable = int(val * 100)
              remainder = ((val * 100) - encodable) / 100.0
              return int(str(encodable), 16), round(remainder,3), val
             #1#
            double freq = 128.775;
            uint freq1 = (uint)(freq * 100);
            double remainder = ((freq * 100) - freq1) / 100.0;
            var bcd = Bcd.UInt2Bcd(freq1);
            var freq2 = Bcd.Bcd2UInt(bcd);
            

            Assert.That(freq2, Is.EqualTo(freq1));

            //Assert.That(ToRadioBcd(128.775), Is.EqualTo(75895));

        }*/

        /*[Test]
        public void Test2()
        {
            double freq = 128.775;

            // Act
            var bcd = Bcd.UInt2Bcd(freq);

            // Assert
            var freqOutUint = Bcd.Bcd2UInt(bcd);
            var freqOutDouble = (double)freqOutUint / 1000;
            
            Assert.That(freqOutDouble, Is.EqualTo(freq));
        }*/
    }
}
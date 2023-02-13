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

    }
}
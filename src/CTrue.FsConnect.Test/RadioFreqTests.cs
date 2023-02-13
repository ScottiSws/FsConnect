using System;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class RadioFreqTests
    {
        private static Decimal[][] testFreqDec = new decimal[][]
        {
            new decimal[] { 1237770m, 123.777m },
            new decimal[] { 1230000m, 123.0m },
            new decimal[] { 1230001m, 123.0001m },
        };

        [Test]
        [TestCaseSource(nameof(testFreqDec))]
        public void Test(Decimal[] testData)
        {
            Decimal freqHz = testData[0];
            Decimal freqMhz = testData[1];

            uint freqBcd32 = Bcd.UInt2Bcd((uint)freqHz);

            Decimal freqTest = RadioFreq.Bcd32Khz2Mhz(freqBcd32);

            Assert.That(freqTest, Is.EqualTo(freqMhz));
        }

        [Test]
        public void Test2()
        {
            Decimal freqMhz = 123.777m;

            uint freqHz = RadioFreq.Mhz2Hz(freqMhz);

            Assert.That(freqHz, Is.EqualTo(123777000));
        }

    }
}
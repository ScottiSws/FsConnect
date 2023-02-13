using System;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class FrequencyBcdTest
    {

        static Object[][] testFreqGood = new Object[][]
        {
            new Object[] { 128.775m, "00128775", "00002877" },
            new Object[] { 128.770m, "00128770", "00002877" },
            new Object[] { 128.77m, "00128770", "00002877" },
            new Object[] { 128.7m, "00128700", "00002870" },
            new Object[] { 128.0m, "00128000", "00002800" },
            new Object[] { 1.1m, "00001100", "00000110" },
        };

        [Test]
        [TestCaseSource(nameof(testFreqGood))]
        public void Test(Object[] testFreq)
        {
            Decimal doubleFreq = (Decimal)testFreq[0];
            String hexBcd32 = (String)testFreq[1];
            String hexBcd16 = (String)testFreq[2];

            FrequencyBcd freq = new FrequencyBcd(doubleFreq);

            String bcd32Hex = freq.Bcd32Value.ToString("X8");
            String bcd16Hex = freq.Bcd16Value.ToString("X8");


            Assert.That(freq.Value, Is.EqualTo(doubleFreq));
            Assert.That(bcd32Hex, Is.EqualTo(hexBcd32));
            Assert.That(bcd16Hex, Is.EqualTo(hexBcd16));
        }


        /*[Test]
        public void Test1()
        {
            FrequencyBcd freq = new FrequencyBcd(128.775);

            Assert.That(freq.Bcd16Value, Is.EqualTo(75895));

            FrequencyBcd freq2 = new FrequencyBcd(freq.Bcd16Value);

            Assert.That(freq2.Value, Is.EqualTo(128.75));
        }

        [Test]
        public void Test2([Values(124.00, 127.90)] double frequency)
        {
            // Act
            FrequencyBcd freq = new FrequencyBcd(frequency);
            FrequencyBcd freq2 = new FrequencyBcd(freq.Bcd16Value);

            // Assert
            Assert.That(freq2.Value, Is.EqualTo(frequency));
        }*/
    }
}
using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFGenerator;

namespace ZmanimTest
{
    [TestClass]
    public class ZmanimTester
    {
        private ZmanimMock z = new ZmanimMock();

        [TestMethod]
        public void GetSunriseTest()
        {
            z.GetSunrise(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("8:15 AM");
            z.GetSunrise(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("6:31 AM");
            z.GetSunrise(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("5:24 AM");
        }
        
        [TestMethod]
        public void GetSofShemaTest()
        {
            z.GetSofShema(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("10:36 AM");
            z.GetSofShema(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("9:44 AM");
            z.GetSofShema(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("9:10 AM");
        }

        [TestMethod]
        public void GetZmanTefillahTest()
        {
            z.GetZmanTefillah(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("11:23 AM");
            z.GetZmanTefillah(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("10:48 AM");
            z.GetZmanTefillah(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("10:26 AM");
        }

        [TestMethod]
        public void GetChatzotTest()
        {
            z.GetChatzot(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("12:57 PM");
            z.GetChatzot(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("12:57 PM");
            z.GetChatzot(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("12:57 PM");
        }

        [TestMethod]
        public void GetMGedolaTest()
        {
            z.GetMGedolah(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("1:20 PM");
            z.GetMGedolah(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("1:29 PM");
            z.GetMGedolah(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("1:34 PM");
        }

        [TestMethod]
        public void GetMKetanaTest()
        {
            z.GetMKetana(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("3:41 PM");
            z.GetMKetana(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("4:42 PM");
            z.GetMKetana(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("5:21 PM");
        }

        [TestMethod]
        public void GetPlagTest()
        {
            z.GetPlag(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("4:40 PM");
            z.GetPlag(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("6:02 PM");
            z.GetPlag(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("6:55 PM");
        }

        [TestMethod]
        public void GetSunsetTest()
        {
            z.GetSunset(new DateTime(2021, 1, 1)).ToShortTimeString().Should().Be("5:39 PM");
            z.GetSunset(new DateTime(2021, 4, 15)).ToShortTimeString().Should().Be("7:23 PM");
            z.GetSunset(new DateTime(2021, 6, 21)).ToShortTimeString().Should().Be("8:30 PM");
        }
    }
}
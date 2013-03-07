using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.DataAccess;
using DataService.Model;
using NUnit.Framework;

namespace DataService.Io
{
    [TestFixture]
    public class XmlBuilderSaveTester
    {
        private readonly DummyFileSystem _dummyFileSystem;

        public XmlBuilderSaveTester()
        {
            _dummyFileSystem = new DummyFileSystem();

            XmlBuilder.ResolveFileSystem = () => _dummyFileSystem;
        }

        private DateTime BuildTestDateTime()
        {
            var dateTime = new DateTime(2009, 11, 7, 12, 0, 0);
            return dateTime;
        }

        private AthleteData BuildAthleteData()
        {
            var athlete = new Athlete
                              {
                                  ID = 1, 
                                  DateOfBirth = BuildTestDateTime(), 
                                  FirstName = "Gryffe", 
                                  LastName = "Hansen", 
                                  RtVersion = 1, 
                                  Preference = null
                              };
            var run = new Run {ID = 1, Athlete = null, Labels = (int)LabelEnumeration.None,Distance = 10000, RtVersion = 1, Shoe = null, Start  = BuildTestDateTime(),Time = 45 *60 };

            return new AthleteData {Athlete = athlete, Runs = new List<Run>(){run}};
        }

        private const string ExpectedXml =
            "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><AthleteData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Athlete><ID>1</ID><FirstName>Gryffe</FirstName><LastName>Hansen</LastName><DateOfBirth>2009-11-07T12:00:00</DateOfBirth><RtVersion>1</RtVersion><Name>Gryffe Hansen</Name></Athlete><Runs><Run><ID>1</ID><Time>2700</Time><Distance>10000</Distance><Start>2009-11-07T12:00:00</Start><Labels>0</Labels><LastChanged>0001-01-01T00:00:00</LastChanged><RtVersion>1</RtVersion></Run></Runs></AthleteData>";

        [Test]
        public void ShouldBuildDownloadXml()
        {
            RunTrackEnvironment.MappedFullyQualifiedDownloadDirectory = "whatever";
            _dummyFileSystem.SaveXmlWasCalled = false;

            var e = new XmlBuilder(BuildAthleteData());

            e.Save();

            Assert.True(_dummyFileSystem.SaveXmlWasCalled);
        }
    }
}

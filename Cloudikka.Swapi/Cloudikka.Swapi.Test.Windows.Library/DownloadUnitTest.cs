﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using Cloudikka.Swapi.Data;

namespace Cloudikka.Swapi.Test.Windows.Library
{
    [TestClass]
    public class DownloadUnitTest {
        private SwapiClient Client = new SwapiClient();

        [TestMethod]
        public async Task GetRootTest() {
            var reference = new SwapiEntityReference<Root>() { Url = new Uri("http://swapi.co/api/") };
            var result = await Client.GetAsync<Root>(reference);
        }

        [TestMethod]
        public async Task GetRootWithValuesTest() {
            var reference = new SwapiEntityReference<Root>() { Url = new Uri("http://swapi.co/api/") };
            var root = await Client.GetAsync<Root>(reference);

            await Client.GetAsync(root.Characters);
            await Client.GetAsync(root.Movies);
            await Client.GetAsync(root.Planets);
            await Client.GetAsync(root.Species);
            await Client.GetAsync(root.Starships);
            await Client.GetAsync(root.Vehicles);

            var result = root;
        }

        [TestMethod]
        public async Task GetPeopleTest() {
            var reference = new SwapiEntityReference<CharacterCollectionPage>() { Url = new Uri("http://swapi.co/api/people/") };
            var result = await Client.GetAsync<CharacterCollectionPage>(reference);
        }

        [TestMethod]
        public async Task GetPersonTest() {
            var reference = new SwapiEntityReference<Character>() { Url = new Uri("http://swapi.co/api/people/1/") };
            var result = await Client.GetAsync<Character>(reference);
        }
    }
}

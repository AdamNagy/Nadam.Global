﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StreamSeeking.Tests.MockClasses;
using System;
using System.IO;

namespace StreamSeeking.Tests.JsonSeekerTests
{
    [TestClass]
    public class SetValueTests
    {
        private static string TEST_FILE = "..\\..\\App_Data\\SetValue_Mock.json";

        [TestInitialize]
        public void BeforeAll()
        {
            File.WriteAllText(TEST_FILE, ToJString(TestJsonModel.GetDefault()));
        }

        public static string ToJString(Object subject)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.None
            };

            return JsonConvert.SerializeObject(subject, jsonSerializerSettings);
        }

        [TestMethod]
        public void Write_String_Begining()
        {
            JsonSeeker.SetValue("stringProp", TEST_FILE, "\"Hello change!!\"");
            var result = JsonSeeker.ReadValue("stringProp", TEST_FILE);

            Assert.AreEqual("Hello change!!", result);
        }

        [TestMethod]
        public void Write_Number_Middle()
        {
            JsonSeeker.SetValue("numberProp", TEST_FILE, "666");
            var result = JsonSeeker.ReadValue("numberProp", TEST_FILE);

            Assert.AreEqual("666", result);
        }

        [TestMethod]
        public void Write_Complex_Middle()
        {
            JsonSeeker.SetValue("complexProp", TEST_FILE, "{\"newProp1\": 1234}");
            var result = JsonSeeker.ReadValue("complexProp", TEST_FILE);

            Assert.AreEqual("{\"newProp1\": 1234}", result);
        }

        [TestMethod]
        public void Write_NumberArray_Middle()
        {
            JsonSeeker.SetValue("numberArrayProp", TEST_FILE, "[1,2,3,4,5]");
            var result = JsonSeeker.ReadValue("numberArrayProp", TEST_FILE);

            Assert.AreEqual("[1,2,3,4,5]", result);
        }

        [TestMethod]
        public void Write_StringArray_Middle()
        {
            JsonSeeker.SetValue("stringArrayProp", TEST_FILE, "[\"Adam\",\"Janos\", \"Diablo\"]");
            var result = JsonSeeker.ReadValue("stringArrayProp", TEST_FILE);

            Assert.AreEqual("[\"Adam\",\"Janos\", \"Diablo\"]", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Exception()
        {
            JsonSeeker.SetValue("textProp", TEST_FILE, "\"some longer text to check\"");
            var result = JsonSeeker.ReadValue("textProp", TEST_FILE);
        }
    }
}

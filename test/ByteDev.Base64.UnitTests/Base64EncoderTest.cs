﻿using System;
using NUnit.Framework;

namespace ByteDev.Base64.UnitTests
{
    [TestFixture]
    public class Base64EncoderTest
    {
        [TestFixture]
        public class IsBase64Encoded
        {
            [Test]
            public void WhenIsNull_ThenReturnFalse()
            {
                var result = Act(null);

                Assert.IsFalse(result);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnFalse()
            {
                var result = Act(string.Empty);

                Assert.IsFalse(result);
            }

            [TestCase("Sm9obiBTbWl0aA-=")]
            [TestCase("Sm9obiBTbWl0aA$=")]
            public void WhenContainsNonBase64Char_ThenReturnFalse(string notBase64)
            {
                var result = Act(notBase64);

                Assert.IsFalse(result);
            }

            [TestCase("Sm9obiBTbWl0aA")]
            [TestCase("Sm9obiBTbWl0aA=")]
            public void WhenLengthIsNotMultipleOfFour_ThenReturnFalse(string notBase64)
            {
                var result = Act(notBase64);

                Assert.IsFalse(result);
            }

            [Test]
            public void WhenContainsMoreThanTwoEquals_ThenReturnFalse()
            {
                const string notBase64 = "Sm9obiBTbWl0a===";

                var result = Act(notBase64);

                Assert.IsFalse(result);
            }

            [TestCase("Sm9obiBTbWl0aA==")]              // "John Smith"
            [TestCase("Sm9obiBTbWl0aAA=")]
            [TestCase("Sm9obiBTbWl0aAAA")]
            public void WhenIsBase64Encoded_ThenReturnTrue(string base64)
            {
                var result = Act(base64);
                
                Assert.IsTrue(result);
            }

            private static bool Act(string str)
            {
                return Base64Encoder.IsBase64Encoded(str);
            }
        }

        [TestFixture]
        public class CalcBase64EncodedSize
        {
            [TestCase(-1, 0)]
            [TestCase(0, 0)]
            [TestCase(10, 16)]
            [TestCase(15, 20)]
            [TestCase(16, 24)]
            [TestCase(50, 68)]
            public void WhenOriginalSizeProvided_ThenReturnExpectedBase64Size(long originalSize, long expected)
            {
                var result = Base64Encoder.CalcBase64EncodedSize(originalSize);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ConvertUtf8ToBase64
        {
            [Test]
            public void WhenArgIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Base64Encoder.ConvertToBase64(null));
            }

            [TestCase("", "")]
            [TestCase("John Smith", "Sm9obiBTbWl0aA==")]
            [TestCase("John Smith12345", "Sm9obiBTbWl0aDEyMzQ1")]
            public void WhenUtf8StringIsNotNull_ThenReturnBased64(string text, string expected)
            {
                var result = Base64Encoder.ConvertToBase64(text);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ConvertBase64ToUtf8
        {
            [Test]
            public void WhenArgIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Base64Encoder.ConvertFromBase64(null));
            }

            [TestCase("", "")]
            [TestCase("Sm9obiBTbWl0aA==", "John Smith")]
            [TestCase("Sm9obiBTbWl0aDEyMzQ1", "John Smith12345")]
            public void WithBase64_ThenReturnText(string base64, string expected)
            {
                var result = Base64Encoder.ConvertFromBase64(base64);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}

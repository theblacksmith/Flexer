using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Flexer.RuleSets;
using NUnit.Framework;

namespace Flexer.Tests
{
	[TestFixture]
	public class UncamelizeTests : InflectorTestBase
	{
		[Test]
		public void Uncamelize()
		{
			foreach (var pair in TestData)
			{
				Assert.AreEqual(pair.Value, inflector.Uncamelize(pair.Key));
			}
		}

		public UncamelizeTests()
		{
			inflector = new Flexer(new PortugueseRuleSet());

			// pluralizables
			TestData.Add("Camel", "camel");
			TestData.Add("TwoCamels", "two_camels");
			TestData.Add("ANiceCamel", "a_nice_camel");
		}
	}
}

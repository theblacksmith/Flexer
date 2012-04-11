using Flexer.RuleSets;
using NUnit.Framework;

namespace Flexer.Tests
{
	[TestFixture]
	public class PascalizeAndCamelizeTests : InflectorTestBase
	{
		private readonly Flexer _inflector;
		
		[Test]
		public void Pascalize()
		{
			foreach (var pair in TestData)
			{
				Assert.AreEqual(pair.Value, _inflector.Pascalize(pair.Key));
			}
		}

		/// <summary>
		/// Same as pascalize, except first char is lowercase
		/// </summary>
		[Test]
		public void Camelize()
		{
			foreach (var pair in TestData)
			{
				Assert.AreEqual(pair.Value, _inflector.Camelize(pair.Key));
			}
		}

		public PascalizeAndCamelizeTests()
		{
			_inflector = new Flexer(new EnglishRuleSet());
			
			TestData.Add("customer", "Customer");
			TestData.Add("CUSTOMER", "CUSTOMER");
			TestData.Add("CUStomer", "CUStomer");
			TestData.Add("customer_name", "CustomerName");
			TestData.Add("customer_first_name", "CustomerFirstName");
			TestData.Add("customer_first_name_goes_here", "CustomerFirstNameGoesHere");
			TestData.Add("customer name", "Customer name");
		}
	}
}
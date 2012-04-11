using Flexer.RuleSets;
using NUnit.Framework;

namespace Flexer.Tests
{
	[TestFixture]
	public class PluralizePtTests : InflectorTestBase
	{
		[Test]
		public void Pluralize()
		{
			foreach (var pair in TestData)
			{
				Assert.AreEqual(pair.Value, inflector.Pluralize(pair.Key));
			}
		}

		[Test]
		public void Singularize()
		{
			foreach (var pair in TestData)
			{
				Assert.AreEqual(pair.Key, inflector.Singularize(pair.Value));
			}
		}

		public PluralizePtTests()
		{
			inflector = new Flexer(new PortugueseRuleSet());

			// pluralizables
			TestData.Add("Compra", "Compras");
			TestData.Add("Caminhao", "Caminhoes");
			TestData.Add("Motor", "Motores");
			TestData.Add("Bordel", "Bordeis");
			TestData.Add("palavra_chave", "palavra_chaves");
			TestData.Add("Abril", "Abris");
			TestData.Add("Azul", "Azuis");
			TestData.Add("Alcool", "Alcoois");

			// irregulars
			TestData.Add("Perfil", "Perfis");
			TestData.Add("Alemao", "Alemaes");
			TestData.Add("Mao", "Maos");
			TestData.Add("Cao", "Caes");
			TestData.Add("Reptil", "Repteis");
			TestData.Add("Sotao", "Sotaos");
			TestData.Add("Pais", "Paises");
			TestData.Add("Pai", "Pais");

			// uncountables
			TestData.Add("Atlas", "Atlas");
			TestData.Add("Lapis", "Lapis");
			TestData.Add("Onibus", "Onibus");
			TestData.Add("Pires", "Pires");
			TestData.Add("Virus", "Virus");
			TestData.Add("Torax", "Torax");
		}
	}
}

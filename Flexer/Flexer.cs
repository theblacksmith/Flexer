/**
 * This file is part of Flexer - An extensible inflector for .Net
 * Copyright (C) 2012 Saulo Vallory <me@saulovallory.com>
 * 
 * Flexer is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * Flexer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Flexer. If not, see <http://www.gnu.org/licenses/>.
 */
namespace Flexer
{
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	public class Flexer
	{
		private readonly RuleSet _ruleset;

		public Flexer(RuleSet ruleset)
		{
			this._ruleset = ruleset;
		}

		public string Pluralize(string word)
		{
			return ApplyRules(_ruleset.Plurals, word);
		}

		public string Singularize(string word)
		{
			return ApplyRules(_ruleset.Singulars, word);
		}

		private string ApplyRules(List<Rule> rules, string word)
		{
			if (!_ruleset.Uncountables.Contains(word.ToLower()))
			{
				string result;

				for (int i = rules.Count - 1; i >= 0; i--)
				{
					if ((result = rules[i].Apply(word)) != null)
					{
						return result;
					}
				}
			}

			return word;
		}

		public string Titleize(string word)
		{
			return Regex.Replace(Humanize(Underscore(word)), @"\b([a-z])",
								 match => match.Captures[0].Value.ToUpper());
		}

		public string Humanize(string lowercaseAndUnderscoredWord)
		{
			return Capitalize(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
		}

		public string Pascalize(string lowercaseAndUnderscoredWord)
		{
			return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)",
								 match => match.Groups[1].Value.ToUpper());
		}

		public string Camelize(string lowercaseAndUnderscoredWord)
		{
			return Pascalize(lowercaseAndUnderscoredWord);
		}

		public string Uncamelize(string camelCasedWord)
		{
			return Regex.Replace(camelCasedWord.Substring(0,1).ToLower() + camelCasedWord.Substring(1), "[A-Z]", "_$0").ToLower();
		}

		public string Underscore(string pascalCasedWord)
		{
			return Regex.Replace(
				Regex.Replace(
					Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])",
					"$1_$2"), @"[-\s]", "_").ToLower();
		}

		public string Capitalize(string word)
		{
			return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
		}

		public string Uncapitalize(string word)
		{
			return word.Substring(0, 1).ToLower() + word.Substring(1);
		}

		public string Ordinalize(string numberString)
		{
			return Ordanize(int.Parse(numberString), numberString);
		}

		public string Ordinalize(int number)
		{
			return Ordanize(number, number.ToString());
		}

		private string Ordanize(int number, string numberString)
		{
			int nMod100 = number % 100;

			if (nMod100 >= 11 && nMod100 <= 13)
			{
				return numberString + "th";
			}

			switch (number % 10)
			{
				case 1:
					return numberString + "st";
				case 2:
					return numberString + "nd";
				case 3:
					return numberString + "rd";
				default:
					return numberString + "th";
			}
		}

		public string Dasherize(string underscoredWord)
		{
			return underscoredWord.Replace('_', '-');
		}

	}
}
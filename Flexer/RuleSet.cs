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

	public class RuleSet
	{
		private readonly List<Rule> _plurals = new List<Rule>();
		protected internal List<Rule> Plurals
		{
			get { return _plurals; }
		}

		private readonly List<Rule> _singulars = new List<Rule>();
		protected internal List<Rule> Singulars
		{
			get { return _singulars; }
		}

		private readonly List<string> _uncountables = new List<string>();
		protected internal List<string> Uncountables
		{
			get { return _uncountables; }
		}

		public void AddUncountable(string word)
		{
			Uncountables.Add(word.ToLower());
		}

		public void AddUncountables(IEnumerable<string> words)
		{
			foreach (var word in words)
			{
				Uncountables.Add(word.ToLower());
			}
		}

		public void AddPlural(string rule, string replacement)
		{
			Plurals.Add(new Rule(rule, replacement));
		}

		public void AddPlurals(IEnumerable<Rule> rules)
		{
			Plurals.AddRange(rules);
		}

		public void AddSingular(string rule, string replacement)
		{
			Singulars.Add(new Rule(rule, replacement));
		}

		public void AddSingulars(IEnumerable<Rule> rules)
		{
			Singulars.AddRange(rules);
		}

		public void AddIrregular(string singular, string plural)
		{
			AddPlural("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
			AddSingular("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
		}

		public void AddIrregulars(Dictionary<string, string> list)
		{
			foreach (KeyValuePair<string, string> pair in list)
			{
				AddIrregular(pair.Key, pair.Value);
			}
		}
	}
}

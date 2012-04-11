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
	using System.Text.RegularExpressions;

	public class Rule
	{
		private readonly Regex _regex;
		private readonly string _replacement;

		private readonly string representation;

		public Rule(string pattern, string replacement)
		{
			_regex = new Regex(pattern, RegexOptions.IgnoreCase);
			_replacement = replacement;
			representation = pattern + " => " + replacement;
		}

		public string Apply(string word)
		{
			return !_regex.IsMatch(word) ? null : _regex.Replace(word, _replacement);
		}

		public override string ToString()
		{
			return representation;
		}
	}
}

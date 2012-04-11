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
using System.Collections.Generic;

namespace Flexer.RuleSets
{
	public class PortugueseRuleSet : RuleSet
	{
		public PortugueseRuleSet()
		{
			AddSingulars(new List<Rule> {
				new Rule("^(.*)s$","$1"),
				new Rule("^(.*)ns$","$1m"),
				new Rule("^(.*)(r|s|z)es$","$1$2"),
				new Rule("^(.*)e?is$","$1il"),
				new Rule("^(.*)(a|e|o|u)is$","$1$2l"),
				new Rule("^(.*)(oes|aes|aos)$", "$1ao"),
				new Rule("^.*x", "$0"),
				new Rule("^(as)es$", "$1")
			});

			AddPlurals(new List<Rule> {
				new Rule("^(.*)$", "$1s"),
				new Rule("^(.*)s$", "$1s"),
				new Rule("^(.*)(m|n)$", "$1ns"),
				new Rule("^(.*)il$", "$1is"),
				new Rule("^(.*)(a|e|o|u)l$", "$1$2is"),
				new Rule("^(.*)(r|z)$", "$1$2es"),
			    new Rule("^(.*)ao$", "$1oes"),
				new Rule("^.*x", "$0"),
				new Rule("^(as)$", "$1es")
			});

			AddIrregulars(new Dictionary<string, string>() {
				{"mao","maos"},
				{"alemao","alemaes"},
				{"abdomens","abdomen"},
				{"artesa","artesaos"},
				{"bencao","bencaos"},
				{"cao","caes"},
				{"capelao","capelaes"},
				{"capitao","capitaes"},
				{"chao","chaos"},
				{"charlatao","charlataes"},
				{"cidadao","cidadaos"},
				{"consul","consules"},
				{"cristao","cristaos"},
				{"dificil","dificeis"},
				{"email","emails"},
				{"escrivao","escrivaes"},
				{"fossel","fosseis"},
				{"germens","germen"},
				{"grao","graos"},
				{"hifens","hifen"},
				{"irmao","irmaos"},
				{"liquens","liquen"},
				{"mal","males"},
				{"orfao","orfaos"},
				{"pais","paises"},
				{"pai","pais"},
				{"pao","paes"},
				{"perfil","perfis"},
				{"projetil","projeteis"},
				{"reptil","repteis"},
				{"sacristao","sacristaes"},
				{"sotao","sotaos"},
				{"tabeliao","tabeliaes"}    		
			});

			Uncountables.AddRange(new List<string> {
				"atlas", "lapis", "onibus", "pires", "virus", "status"
			});
		}
	}
}
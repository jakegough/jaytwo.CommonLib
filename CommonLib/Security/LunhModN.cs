using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.CommonLib.Security
{
	public class LuhnModN
	{
		public static readonly LuhnModN Base10 = new LuhnModN("0123456789");
		public static readonly LuhnModN Base16 = new LuhnModN("0123456789ABCDEF");
		public static readonly LuhnModN Base36 = new LuhnModN("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");

		public string CharacterMap
		{
			get;
			private set;
		}

		private LuhnModN(string characterMap)
		{
			CharacterMap = characterMap;
		}

		private int GetCodePointFromCharacter(char character)
		{
			int result = CharacterMap.IndexOf(character);
			if (result < 0)
			{
				throw new Exception("Character not in map: '" + character + "'");
			}
			else
			{
				return result;
			}
		}


		public char GenerateCheckCharacter(string input)
		{
			int factor = 2;
			int sum = 0;
			int n = CharacterMap.Length;

			// Starting from the right and working leftwards is easier since 
			// the initial "factor" will always be "2" 
			for (int i = input.Length - 1; i >= 0; i--)
			{
				int codePoint = GetCodePointFromCharacter(input[i]);
				int addend = factor * codePoint;

				// Alternate the "factor" that each "codePoint" is multiplied by
				factor = (factor == 2) ? 1 : 2;

				// Sum the digits of the "addend" as expressed in base "n"
				addend = (addend / n) + (addend % n);
				sum += addend;
			}

			// Calculate the number that must be added to the "sum" 
			// to make it divisible by "n"
			int remainder = sum % n;
			int checkCodePoint = n - remainder;
			checkCodePoint %= n;

			return CharacterMap[checkCodePoint]; ;
		}

		public bool ValidateCheckCharacter(string input)
		{
			int factor = 1;
			int sum = 0;
			int n = CharacterMap.Length;

			// Starting from the right, work leftwards
			// Now, the initial "factor" will always be "1" 
			// since the last character is the check character
			for (int i = input.Length - 1; i >= 0; i--)
			{
				int codePoint = GetCodePointFromCharacter(input[i]);
				int addend = factor * codePoint;

				// Alternate the "factor" that each "codePoint" is multiplied by
				factor = (factor == 2) ? 1 : 2;

				// Sum the digits of the "addend" as expressed in base "n"
				addend = (addend / n) + (addend % n);
				sum += addend;
			}

			int remainder = sum % n;

			return (remainder == 0);
		}
	}
}

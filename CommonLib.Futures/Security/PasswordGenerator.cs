using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jaytwo.Common.Extensions;

namespace jaytwo.Common.Futures.Security
{
	public class PasswordGenerator
	{
		private char[] lower = "abcdefghijklmnopqrxtuvwxyz".ToArray();
		private char[] upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
		private char[] numeric = "0123456789".ToArray();
		private char[] punctuation = "!@#$%^&*()_+-={}|[]<>?.,;".ToArray();
		private char[] similarCharacters = "|1lIoO0".ToArray();

		private int passwordLength = 8;
		public int PasswordLength
		{
			get
			{
				return passwordLength;
			}
			set
			{
				passwordLength = value;
			}
		}

		private bool includeLetters = true;
		public bool IncludeLetters
		{
			get
			{
				return includeLetters;
			}
			set
			{
				includeLetters = value;
			}
		}

		private bool beginWithLetter = true;
		public bool BeginWithLetter
		{
			get
			{
				return beginWithLetter;
			}
			set
			{
				beginWithLetter = value;
			}
		}

		private bool includeMixedCase = true;
		public bool IncludeMixedCase
		{
			get
			{
				return includeMixedCase;
			}
			set
			{
				includeMixedCase = value;
			}
		}

		private bool includeNumeric = true;
		public bool IncludeNumeric
		{
			get
			{
				return includeNumeric;
			}
			set
			{
				includeNumeric = value;
			}
		}

		private bool includePunctuation = false;
		public bool IncludePunctuation
		{
			get
			{
				return includePunctuation;
			}
			set
			{
				includePunctuation = value;
			}
		}

		private bool noSimilarCharacters = true;
		public bool NoSimilarCharacters
		{
			get
			{
				return noSimilarCharacters;
			}
			set
			{
				noSimilarCharacters = value;
			}
		}

		private char GetRandomCharacter()
		{
			var sets = new List<char[]>();

			if (IncludeLetters)
			{
				sets.Add(lower);

				if (IncludeMixedCase)
				{
					sets.Add(upper);
				}
			}

			if (IncludeNumeric)
			{
				sets.Add(numeric);
			}

			if (IncludePunctuation)
			{
				sets.Add(punctuation);
			}

			var randomSet = sets.FirstRandom();
			return GetRandomCharacter(randomSet);
		}

		private char GetRandomCharacter(char[] chars)
		{
			if (NoSimilarCharacters)
			{
				var safeChars = chars
					.Where(x => similarCharacters.All(y => x != y))
					.ToArray();

				return safeChars.FirstRandom();
			}
			else
			{
				return chars.FirstRandom();
			}
		}

		public static string GenerateDefault()
		{
			return new PasswordGenerator().Generate();
		}

		public static string GenerateDefault(int passwordLength)
		{
			var generator = new PasswordGenerator()
			{
				PasswordLength = passwordLength,
			};

			return generator.Generate();
		}

		public int GetComplexity()
		{
			int result = 0;

			if (IncludeLetters)
			{
				result++;

				if (IncludeMixedCase)
				{
					result++;
				}
			}

			if (IncludeNumeric)
			{
				result++;
			}

			if (IncludePunctuation)
			{
				result++;
			}

			return result;
		}

		public string Generate()
		{
			int complexity = GetComplexity();
			if (complexity == 0)
			{
				throw new Exception("Password complexity must be greater than zero.");
			}
			else if (complexity > PasswordLength)
			{
				throw new Exception("Password length insufficient for complexity of " + complexity);
			}

			var result = new StringBuilder();

			if (IncludeLetters)
			{
				result.Append(GetRandomCharacter(lower));

				if (IncludeMixedCase)
				{
					result.Append(GetRandomCharacter(upper));
				}
			}

			if (IncludeNumeric)
			{
				result.Append(GetRandomCharacter(numeric));
			}

			if (IncludePunctuation)
			{
				result.Append(GetRandomCharacter(punctuation));
			}

			while (result.Length < passwordLength)
			{
				result.Append(GetRandomCharacter());
			}

			return Scramble(result.ToString());
		}

		private string Scramble(string plain)
		{
			char[] result;

			if (BeginWithLetter && IncludeLetters)
			{
				var orderedByIsLetter = plain
					.OrderByRandom()
					.OrderByDescending(x => char.IsLetter(x))
					.ToList();

				var resultList = new List<char>();
				resultList.Add(orderedByIsLetter.First());
				resultList.AddRange(orderedByIsLetter.Skip(1).OrderByRandom());

				result = resultList.ToArray();
			}
			else
			{
				result = plain
					.OrderByRandom()
					.ToArray();
			}

			return new string(result.ToArray());
		}
	}
}
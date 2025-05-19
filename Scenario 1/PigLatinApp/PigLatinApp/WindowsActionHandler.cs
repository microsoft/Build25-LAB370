using Microsoft.AI.Actions.Annotations;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinApp
{
    [ActionProvider]
    public sealed class WindowsActionHandler
    {
        [WindowsAction(Description = "Rewrite in Piglatin", Icon = "ms-resource://Files/Assets/LockScreenLogo.png", UsesGenerativeAI = false)]
        [WindowsActionInputCombination(Inputs = ["message"], Description = "Rewrite '${message.ShortText}' in Piglatin")]
        public async Task<RewriteInPiglatinResult> RewriteInPiglatin(string message)
        {
            return new RewriteInPiglatinResult
            {
                Response = ConvertPhraseToPigLatin(message),
            };
        }

        private static string ConvertPhraseToPigLatin(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            string[] words = input.Split(' ');
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                string piglatinWord = ConvertWordToPigLatin(word);
                result.Append(piglatinWord + " ");
            }

            return result.ToString().Trim();
        }

        private static string ConvertWordToPigLatin(string word)
        {
            string lowerWord = word.ToLower();
            string vowels = "aeiou";

            if (vowels.Contains(lowerWord[0]))
            {
                return word + "way";
            }
            else
            {
                int vowelIndex = -1;
                for (int i = 0; i < lowerWord.Length; i++)
                {
                    if (vowels.Contains(lowerWord[i]))
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                if (vowelIndex == -1)
                {
                    return word + "ay"; // No vowels found
                }

                string prefix = word.Substring(0, vowelIndex);
                string suffix = word.Substring(vowelIndex);
                return suffix + prefix + "ay";
            }
        }

    }

    public record RewriteInPiglatinResult
    {
        public required string Response { get; init; }
    }
}

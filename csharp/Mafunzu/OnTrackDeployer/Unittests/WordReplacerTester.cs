using FlexHelper;
using NUnit.Framework;

namespace Unittests
{
    [TestFixture]
    public class WordReplacerTester
    {
        [Test]
        public void WhenSeachNotFoundShouldReturnNull()
        {
            var text = "gryf";
            var search = "gryffe";
            var wordReplacement = "";
            var e = new WordReplacer(search, wordReplacement);
            e.Replace(text);
            Assert.IsFalse(e.Success());

            var result = e.ReplacedText;
            Assert.AreEqual(null, result);
        }


        string BuildMultilineText(string text)
        {
            var result = new[] {text, text, text}; 
            return string.Join("\n", result);
        }

        [Test]
        public void ShouldReplaceAllOccurences()
        {
            const string fox = "fox";
            const string textTemplate = "the quick brown {0}, a sentence with{1}animals followed by another {2}..";
            var text = string.Format(textTemplate, fox, fox, fox);
            text = BuildMultilineText(text);

            const string search = fox;

            const string dog = "dog";
            var expectedResult = string.Format(textTemplate, dog, fox, dog);
            expectedResult = BuildMultilineText(expectedResult);


            var e = new WordReplacer(search, dog);

            e.Replace(text);
            
            Assert.IsTrue(e.Success());

            var result = e.ReplacedText;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenWordContainsDotCharacterShouldReplaceAllOccurences()
        {
            const string wordWithDotChars = "dk.ontrack.model.interfaces.IClientModel";
            const string textTemplate = "the quick brown {0}, a sentence with{1}animals followed by another {2}..";
            var text = string.Format(textTemplate, wordWithDotChars, wordWithDotChars, wordWithDotChars);
            text = BuildMultilineText(text);

            const string search = wordWithDotChars;

            const string dog = "dog";
            var expectedResult = string.Format(textTemplate, dog, wordWithDotChars, dog);
            expectedResult = BuildMultilineText(expectedResult);


            var e = new WordReplacer(search, dog);

            e.Replace(text);

            Assert.IsTrue(e.Success());

            var result = e.ReplacedText;
            Assert.AreEqual(expectedResult, result);
        }


    }
}
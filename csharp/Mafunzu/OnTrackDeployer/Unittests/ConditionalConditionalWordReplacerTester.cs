using FlexHelper;
using NUnit.Framework;

namespace Unittests
{
    [TestFixture]
    public class ConditionalConditionalWordReplacerTester
    {
        [Test]
        public void WhenSeachNotFoundShouldReturnNull()
        {
            var text = "gryf";
            var search = "gryffe";
            var wordReplacement = "";
            var e = new ConditionalWordReplacer(search, wordReplacement, text);
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

            var e = new ConditionalWordReplacer(search, dog, "quick");

            e.Replace(text);
            
            Assert.IsTrue(e.Success());

            var result = e.ReplacedText;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void AssertFalseWhenConditionNotFound()
        {
            const string fox = "fox";
            const string textTemplate = "the quick brown {0}, a sentence with{1}animals followed by another {2}..";
            var text = string.Format(textTemplate, fox, fox, fox);
            text = BuildMultilineText(text);

            const string search = fox;

            const string dog = "dog";
            var expectedResult = string.Format(textTemplate, dog, fox, dog);
            expectedResult = BuildMultilineText(expectedResult);

            const string wordThatDoesNotExistinSentence = "wordThatDoesNotExistinSentence";
            var e = new ConditionalWordReplacer(search, dog, "wordThatDoesNotExistinSentence");

            e.Replace(text);

            Assert.IsFalse(e.Success());

        }

    }
}
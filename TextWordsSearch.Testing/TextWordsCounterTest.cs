using TextWordsSearch.Library;

namespace TextWordsSearch.Testing;

public class TextWordsCounterTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestWordsCount()
    {
        string text = "This is a test text and the text is a simple string";

        uint actualCount = TextWordsCounter.GetWordCountInText("text", text);
        uint expectedCount = 2;

        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }
}
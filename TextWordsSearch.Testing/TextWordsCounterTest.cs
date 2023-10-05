//-----------------------------------------------------------------------
// <copyright file="TextWordsCounterTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Testing;

using TextWordsSearch.Library;

public class TextWordsCounterTest
{
    private const string TestContent0 = "Build. Test. Deploy.\n" +
        ".NET is the free, open-source, cross-platform framework for building modern apps and powerful cloud services.\n";

    private const string TestContent1 = "\nFree and open source\n" +
        ".NET is a free and open-source project, developed and maintained on GitHub, the home for millions of developers who want to build great things together.\n";

    private const string TestContent2 = "\nFast and cross-platform\n" +
        ".NET performs faster than any other popular framework, according to TechEmpower. You can write, run, and build on multiple platforms, including Windows, Linux, and macOS.\n";

    private const string TestContent3 = "\nModern and productive\n" +
        ".NET helps you build apps for web, mobile, desktop, cloud, and more. With its large supportive ecosystem and powerful tooling, .NET is the most productive platform for developers.\n";

    private static readonly string[] TestWordsArray0 =
    {
        "Build", "Test", "Deploy",
        "NET", "is", "the", "free", "open", "source", "cross", "platform", "framework",
        "for", "building", "modern", "apps", "and", "powerful", "cloud", "services",
    };

    private static readonly string[] TestWordsArray1 =
    {
        "Free", "and", "open", "source",
        "NET", "is", "a", "free", "and", "open", "source", "project",
        "developed", "and", "maintained", "on", "GitHub",
        "the", "home", "for", "millions", "of", "developers",
        "who", "want", "to", "build", "great", "things", "together",
    };

    private static readonly string[] TestWordsArray2 =
    {
        "Fast", "and", "cross", "platform",
        "NET", "performs", "faster", "than", "any", "other", "popular", "framework", "according", "to", "TechEmpower",
        "You", "can", "write", "run", "and", "build", "on", "multiple", "platforms",
        "including", "Windows", "Linux", "and", "macOS",
    };

    private static readonly string[] TestWordsArray3 =
    {
        "Modern", "and", "productive",
        "NET", "helps", "you", "build", "apps",
        "for", "web", "mobile", "desktop", "cloud", "and", "more",
        "With", "its", "large", "supportive", "ecosystem", "and", "powerful", "tooling",
        "NET", "is", "the", "most", "productive", "platform", "for", "developers",
    };

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetWordsArrayFromTextContent_TestCase0()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent0);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray0));
    }

    [Test]
    public void GetWordsArrayFromTextContent_TestCase1()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent1);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray1));
    }

    [Test]
    public void GetWordsArrayFromTextContent_TestCase2()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent2);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray2));
    }

    [Test]
    public void GetWordsArrayFromTextContent_TestCase3()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent3);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray3));
    }

    [Test]
    public void GetWordsDictionaryFromWordsArray_TestCase1()
    {
        string[] detectedWords =
        {
            "word1",
            "word2", "word2",
            "word3", "word3", "word3",
            "word4", "word4", "word4", "word4",
            "word5", "word5", "word5", "word5", "word5",
        };

        Dictionary<string, uint> actualWordsDictionary =
            TextWordsCounter.GetWordsDictionaryFromWordsArray(detectedWords);

        Dictionary<string, uint> expectedWordsDictionary = new ()
        {
            { "word1", 1 },
            { "word2", 2 },
            { "word3", 3 },
            { "word4", 4 },
            { "word5", 5 },
        };

        Assert.That(actualWordsDictionary, Is.EqualTo(expectedWordsDictionary));
    }

    [Test]
    public void GetWordsDictionaryFromWordsArray_TestCase2()
    {
        string[] detectedWords =
        {
            "word5", "word5", "word5", "word5", "word5",
            "word6", "word6", "word6", "word6",
            "word7", "word7", "word7",
            "word8", "word8",
            "word9",
        };

        Dictionary<string, uint> actualWordsDictionary =
            TextWordsCounter.GetWordsDictionaryFromWordsArray(detectedWords);

        Dictionary<string, uint> expectedWordsDictionary = new ()
        {
            { "word5", 5 },
            { "word6", 4 },
            { "word7", 3 },
            { "word8", 2 },
            { "word9", 1 },
        };

        Assert.That(actualWordsDictionary, Is.EqualTo(expectedWordsDictionary));
    }

    [Test]
    public void GetWordsDictionaryFromWordsArray_TestCase3()
    {
        string[] detectedWords =
        {
            "word1",
            "word2", "word2",
            "word3", "word3", "word3",
            "word4", "word4", "word4", "word4",
            "word5", "word5", "word5", "word5", "word5",
            "word6", "word6", "word6", "word6",
            "word7", "word7", "word7",
            "word8", "word8",
            "word9",
        };

        Dictionary<string, uint> actualWordsDictionary =
            TextWordsCounter.GetWordsDictionaryFromWordsArray(detectedWords);

        Dictionary<string, uint> expectedWordsDictionary = new ()
        {
            { "word1", 1 },
            { "word2", 2 },
            { "word3", 3 },
            { "word4", 4 },
            { "word5", 5 },
            { "word6", 4 },
            { "word7", 3 },
            { "word8", 2 },
            { "word9", 1 },
        };

        Assert.That(actualWordsDictionary, Is.EqualTo(expectedWordsDictionary));
    }

    [Test]
    public void GetSortedWordsListByAscending_TestCase1()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four", 4 },
            { "two", 2 },
            { "one", 1 },
            { "three", 3 },
            { "five", 5 },
            { "nine", 9 },
            { "seven", 7 },
            { "six", 6 },
            { "eigth", 8 },
        };

        List<KeyValuePair<uint, List<string>>> actualSortedWords =
            TextWordsCounter.GetSortedWordsByAscending(wordsDictionary);

        List<KeyValuePair<uint, List<string>>> expectedSortedWords = new ()
        {
            new (key: 1, value: new List<string>() { "one" }),
            new (key: 2, value: new List<string>() { "two" }),
            new (key: 3, value: new List<string>() { "three" }),
            new (key: 4, value: new List<string>() { "four" }),
            new (key: 5, value: new List<string>() { "five" }),
            new (key: 6, value: new List<string>() { "six" }),
            new (key: 7, value: new List<string>() { "seven" }),
            new (key: 8, value: new List<string>() { "eigth" }),
            new (key: 9, value: new List<string>() { "nine" }),
        };

        Assert.That(actualSortedWords, Is.EqualTo(expectedSortedWords));
    }

    [Test]
    public void GetSortedWordsListByAscending_TestCase2()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four1", 4 },
            { "four", 4 },
            { "four2", 4 },
            { "two1", 2 },
            { "two", 2 },
            { "five", 5 },
            { "five2", 5 },
            { "five3", 5 },
            { "five1", 5 },
            { "three1", 3 },
            { "three", 3 },
            { "three2", 3 },
            { "one", 1 },
            { "one1", 1 },
        };

        List<KeyValuePair<uint, List<string>>> actualSortedWords =
            TextWordsCounter.GetSortedWordsByAscending(wordsDictionary);

        List<KeyValuePair<uint, List<string>>> expectedSortedWords = new ()
        {
            new (key: 1, value: new List<string>() { "one", "one1", }),
            new (key: 2, value: new List<string>() { "two", "two1" }),
            new (key: 3, value: new List<string>() { "three", "three1", "three2" }),
            new (key: 4, value: new List<string>() { "four", "four1", "four2" }),
            new (key: 5, value: new List<string>() { "five", "five1", "five2", "five3" }),
        };

        Assert.That(actualSortedWords, Is.EqualTo(expectedSortedWords));
    }

    [Test]
    public void GetSortedWordsListByDescending_TestCase1()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four", 4 },
            { "two", 2 },
            { "one", 1 },
            { "three", 3 },
            { "five", 5 },
            { "nine", 9 },
            { "seven", 7 },
            { "six", 6 },
            { "eigth", 8 },
        };

        List<KeyValuePair<uint, List<string>>> actualSortedWords =
            TextWordsCounter.GetSortedWordsByDescending(wordsDictionary);

        List<KeyValuePair<uint, List<string>>> expectedSortedWords = new ()
        {
            new (key: 9, value: new List<string>() { "nine" }),
            new (key: 8, value: new List<string>() { "eigth" }),
            new (key: 7, value: new List<string>() { "seven" }),
            new (key: 6, value: new List<string>() { "six" }),
            new (key: 5, value: new List<string>() { "five" }),
            new (key: 4, value: new List<string>() { "four" }),
            new (key: 3, value: new List<string>() { "three" }),
            new (key: 2, value: new List<string>() { "two" }),
            new (key: 1, value: new List<string>() { "one" }),
        };

        Assert.That(actualSortedWords, Is.EqualTo(expectedSortedWords));
    }

    [Test]
    public void GetSortedWordsListByDescending_TestCase2()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four1", 4 },
            { "four", 4 },
            { "four2", 4 },
            { "two1", 2 },
            { "two", 2 },
            { "five", 5 },
            { "five2", 5 },
            { "five3", 5 },
            { "five1", 5 },
            { "three1", 3 },
            { "three", 3 },
            { "three2", 3 },
            { "one", 1 },
            { "one1", 1 },
        };

        List<KeyValuePair<uint, List<string>>> actualSortedWords =
            TextWordsCounter.GetSortedWordsByDescending(wordsDictionary);

        List<KeyValuePair<uint, List<string>>> expectedSortedWords = new ()
        {
            new (key: 5, value: new List<string>() { "five3", "five2", "five1", "five" }),
            new (key: 4, value: new List<string>() { "four2", "four1", "four" }),
            new (key: 3, value: new List<string>() { "three2", "three1", "three" }),
            new (key: 2, value: new List<string>() { "two1", "two" }),
            new (key: 1, value: new List<string>() { "one1", "one", }),
        };

        Assert.That(actualSortedWords, Is.EqualTo(expectedSortedWords));
    }

    [Test]
    public void GetInfoAboutMaximumEntryCountOfWordsInText_TestCase1()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four", 4 },
            { "two", 2 },
            { "one", 1 },
            { "three", 3 },
            { "five", 5 },
            { "nine", 9 },
            { "seven", 7 },
            { "six", 6 },
            { "eigth", 8 },
        };

        KeyValuePair<uint, List<string>> actualInfo =
            TextWordsCounter.GetInfoAboutMaximumEntryCountOfWordsInText(wordsDictionary);

        KeyValuePair<uint, List<string>> expectedInfo =
            new (key: 9, value: new List<string>() { "nine" });

        Assert.That(actualInfo, Is.EqualTo(expectedInfo));
    }

    [Test]
    public void GetInfoAboutMaximumEntryCountOfWordsInText_TestCase2()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "value_0", 100 },
            { "value_1", 25 },
            { "value_2", 100 },
            { "value_3", 50 },
            { "value_4", 100 },
            { "value_5", 75 },
            { "value_6", 100 },
            { "value_7", 75 },
            { "value_8", 100 },
            { "value_9", 50 },
        };

        KeyValuePair<uint, List<string>> actualInfo =
            TextWordsCounter.GetInfoAboutMaximumEntryCountOfWordsInText(wordsDictionary);

        KeyValuePair<uint, List<string>> expectedInfo =
            new (key: 100, value: new List<string>() { "value_0", "value_2", "value_4", "value_6", "value_8" });

        Assert.That(actualInfo, Is.EqualTo(expectedInfo));
    }

    [Test]
    public void GetInfoAboutMinimumEntryCountOfWordsInText_TestCase1()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "four", 4 },
            { "two", 2 },
            { "one", 1 },
            { "three", 3 },
            { "five", 5 },
            { "nine", 9 },
            { "seven", 7 },
            { "six", 6 },
            { "eigth", 8 },
        };

        KeyValuePair<uint, List<string>> actualInfo =
            TextWordsCounter.GetInfoAboutMinimumEntryCountOfWordsInText(wordsDictionary);

        KeyValuePair<uint, List<string>> expectedInfo =
            new (key: 1, value: new List<string>() { "one" });

        Assert.That(actualInfo, Is.EqualTo(expectedInfo));
    }

    [Test]
    public void GetInfoAboutMinimumEntryCountOfWordsInText_TestCase2()
    {
        Dictionary<string, uint> wordsDictionary = new ()
        {
            { "value_0", 100 },
            { "value_1", 75 },
            { "value_2", 50 },
            { "value_3", 25 },
            { "value_4", 25 },
            { "value_5", 50 },
            { "value_6", 75 },
            { "value_7", 100 },
            { "value_8", 25 },
            { "value_9", 25 },
        };

        KeyValuePair<uint, List<string>> actualInfo =
            TextWordsCounter.GetInfoAboutMinimumEntryCountOfWordsInText(wordsDictionary);

        KeyValuePair<uint, List<string>> expectedInfo =
            new (key: 25, value: new List<string>() { "value_3", "value_4", "value_8", "value_9" });

        Assert.That(actualInfo, Is.EqualTo(expectedInfo));
    }
}

//-----------------------------------------------------------------------
// <copyright file="TextWordsCounterTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Testing;

using System.Collections.Immutable;
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
}

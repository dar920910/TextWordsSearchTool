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
    public void CalculateWordCount_TestCase0()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent0);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray0));
    }

    [Test]
    public void CalculateWordCount_TestCase1()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent1);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray1));
    }

    [Test]
    public void CalculateWordCount_TestCase2()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent2);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray2));
    }

    [Test]
    public void CalculateWordCount_TestCase3()
    {
        string[] actualWordsArray = TextWordsCounter.GetWordsArrayFromTextContent(TestContent3);
        Assert.That(actualWordsArray, Is.EqualTo(TestWordsArray3));
    }
}

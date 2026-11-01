using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new()
        {
            { "apple", 1 },
            { "banana", 2 }
        };

        // Act
        Dictionary<string, int> result1 = DictionaryIntersection.Intersect(dict1, dict2);
        Dictionary<string, int> result2 = DictionaryIntersection.Intersect(dict2, dict1);

        // Assert
        Assert.That(result1, Is.Empty);
        Assert.That(result2, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            { "apple", 1 },
            { "banana", 2 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "cherry", 3 },
            { "date", 4 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            { "apple", 1 },
            { "banana", 2 },
            { "cherry", 3 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "banana", 2 },
            { "cherry", 3 },
            { "date", 4 }
        };

        Dictionary<string, int> expected = new()
        {
            { "banana", 2 },
            { "cherry", 3 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            { "apple", 1 },
            { "banana", 2 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "apple", 10 },
            { "banana", 20 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
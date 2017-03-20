using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Algorithms.UnionFind
{
    [TestClass]
    public abstract class UnionFindTestsBase
    {
        [Test]
        public void ShouldUnionFindOnTinyData()
        {
            // Given
            var expectedCount = 2;
            var fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"..\..\..\..\TestData\tinyUF.txt";
            IUnionFind uf;

            // When
            using (var sr = new StreamReader(fileName))
            {
                var nodesCountStr = sr.ReadLine();
                if (nodesCountStr == null)
                {
                    return;
                }

                var nodesCount = int.Parse(nodesCountStr);
                uf = GetUnionFind(nodesCount);
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var pq = Regex.Split(line, @"\W+").Select(int.Parse).ToList();
                    var p = pq[0];
                    var q = pq[1];

                    if (uf.Connected(p, q))
                    {
                        continue;
                    }

                    uf.Union(p, q);
                }
            }

            // Then
            uf.Count.ShouldBe(expectedCount);
        }

        public abstract IUnionFind GetUnionFind(int n);
    }
}
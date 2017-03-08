using System;
using System.Linq;
using Algorithms.Std.Collections;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class ListQueueTests : BaseQueueTests
    {
        protected override IQueue<T> GetQueue<T>()
        {
            return new ListQueue<T>();
        }
    }
}
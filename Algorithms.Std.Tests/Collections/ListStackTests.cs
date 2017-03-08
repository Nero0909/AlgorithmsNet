using System;
using System.Linq;
using Algorithms.Std.Collections;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class ListStackTests : BaseStackTests
    {
        protected override IStack<T> GetStack<T>()
        {
            return new ListStack<T>();
        }
    }
}
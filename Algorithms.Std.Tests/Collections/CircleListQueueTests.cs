using Algorithms.Std.Collections;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class CircleListQueueTests : BaseQueueTests
    {
        protected override IQueue<T> GetQueue<T>()
        {
            return new CircleListQueue<T>();
        }
    }
}
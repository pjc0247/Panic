using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Panic.Marshal;

namespace tests
{
    [TestClass]
    public class ByteBufferTest
    {
        [TestMethod]
        public void Push()
        {
            var buffer = new ByteBuffer();

            for(int i = 1; i <= 3; i++)
            {
                buffer.Push(new byte[64]);
                Assert.AreEqual(
                    i * 64, buffer.Size);
            }
        }

        [TestMethod]
        public void Consume()
        {
            var buffer = new ByteBuffer();

            for (int i = 1; i <= 3; i++)
            {
                buffer.Push(new byte[64]);
            }

            for (int i = 1; i <= 3; i++)
            {
                var data = buffer.Consume(64);

                Assert.AreEqual(
                    64, data.Length);
            }

            Assert.AreEqual(
                    0, buffer.Size);
        }
    }
}
  
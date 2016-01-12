using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Protocol.Marshal
{
    public class ByteBuffer
    {
        protected byte[] Buffer { get; set; }
        protected int Ptr { get; set; }

        public int Size
        {
            get
            {
                return Ptr;
            }
        }

        public ByteBuffer()
        {
            Buffer = new byte[1024];
            Ptr = 0;
        }

        public byte[] Peek(int length)
        {
            if (length > Ptr)
                throw new InvalidOperationException("buffer underflowed");

            var data = new byte[length];

            Array.Copy(Buffer, data, length);

            return data;
        }
        public byte[] Consume(int length)
        {
            var data = Peek(length);

            Array.Copy(Buffer, Ptr, Buffer, 0, Ptr);
            Ptr -= length;

            return data;
        }
        public void Push(byte[] data)
        {
            if(Ptr + data.Length > Buffer.Length)
                throw new InvalidOperationException("buffer overflowed");

            Array.Copy(data, Buffer, data.Length);
            Ptr += data.Length;
        }
    }
}

﻿namespace ObjectDB
{
    internal class BufferPool
    {
        private static object _lock;
        private static ArrayPool<byte> _bytePool;

        static BufferPool()
        {
            _lock = new object();
            _bytePool = new ArrayPool<byte>();
        }

        public static byte[] Rent(int count)
        {
            lock (_lock)
            {
                return _bytePool.Rent(count);
            }
        }

        public static void Return(byte[] buffer)
        {
            lock (_lock)
            {
                _bytePool.Return(buffer);
            }
        }
    }

}


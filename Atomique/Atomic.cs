using System;
using System.Threading;

namespace Atomique
{
    /// <summary>
    /// Provides atomic operations based on the C++11 memory model.
    /// </summary>
    public static unsafe class Atomic
    {
        /// <summary>
        /// Inserts an acquire barrier.
        /// </summary>
        public static void AcquireBarrier()
        {
            Interlocked.MemoryBarrier();
        }

        /// <summary>
        /// Inserts a release barrier.
        /// </summary>
        public static void ReleaseBarrier()
        {
            Interlocked.MemoryBarrier();
        }

        /// <summary>
        /// Inserts an acquire/release barrier.
        /// </summary>
        public static void SequentialBarrier()
        {
            Interlocked.MemoryBarrier();
        }

        /// <summary>
        /// Provides atomic operations for <see cref="bool" />.
        /// </summary>
        public static class Boolean
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="bool" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static bool ReadRelaxed(ref bool ptr)
            {
                return ptr;
            }

            public static bool ReadAcquire(ref bool ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static bool ReadSequential(ref bool ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref bool ptr, bool val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref bool ptr, bool val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref bool ptr, bool val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="char" />.
        /// </summary>
        public static class Char
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="char" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static char ReadRelaxed(ref char ptr)
            {
                return ptr;
            }

            public static char ReadAcquire(ref char ptr)
            {
                fixed (char* p = &ptr)
                    return (char)Volatile.Read(ref *(short*)p);
            }

            public static char ReadSequential(ref char ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref char ptr, char val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref char ptr, char val)
            {
                fixed (char* p = &ptr)
                    Volatile.Write(ref *(short*)p, (short)val);
            }

            public static void WriteSequential(ref char ptr, char val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="sbyte" />.
        /// </summary>
        public static class SByte
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="sbyte" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            [CLSCompliant(false)]
            public static sbyte ReadRelaxed(ref sbyte ptr)
            {
                return ptr;
            }

            [CLSCompliant(false)]
            public static sbyte ReadAcquire(ref sbyte ptr)
            {
                return Volatile.Read(ref ptr);
            }

            [CLSCompliant(false)]
            public static sbyte ReadSequential(ref sbyte ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            [CLSCompliant(false)]
            public static void WriteRelaxed(ref sbyte ptr, sbyte val)
            {
                ptr = val;
            }

            [CLSCompliant(false)]
            public static void WriteRelease(ref sbyte ptr, sbyte val)
            {
                Volatile.Write(ref ptr, val);
            }

            [CLSCompliant(false)]
            public static void WriteSequential(ref sbyte ptr, sbyte val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="byte" />.
        /// </summary>
        public static class Byte
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="byte" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static byte ReadRelaxed(ref byte ptr)
            {
                return ptr;
            }

            public static byte ReadAcquire(ref byte ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static byte ReadSequential(ref byte ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref byte ptr, byte val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref byte ptr, byte val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref byte ptr, byte val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="short" />.
        /// </summary>
        public static class Int16
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="short" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static short ReadRelaxed(ref short ptr)
            {
                return ptr;
            }

            public static short ReadAcquire(ref short ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static short ReadSequential(ref short ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref short ptr, short val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref short ptr, short val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref short ptr, short val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="ushort" />.
        /// </summary>
        public static class UInt16
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="ushort" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            [CLSCompliant(false)]
            public static ushort ReadRelaxed(ref ushort ptr)
            {
                return ptr;
            }

            [CLSCompliant(false)]
            public static ushort ReadAcquire(ref ushort ptr)
            {
                return Volatile.Read(ref ptr);
            }

            [CLSCompliant(false)]
            public static ushort ReadSequential(ref ushort ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            [CLSCompliant(false)]
            public static void WriteRelaxed(ref ushort ptr, ushort val)
            {
                ptr = val;
            }

            [CLSCompliant(false)]
            public static void WriteRelease(ref ushort ptr, ushort val)
            {
                Volatile.Write(ref ptr, val);
            }

            [CLSCompliant(false)]
            public static void WriteSequential(ref ushort ptr, ushort val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="int" />.
        /// </summary>
        public static class Int32
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="int" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static int ReadRelaxed(ref int ptr)
            {
                return ptr;
            }

            public static int ReadAcquire(ref int ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static int ReadSequential(ref int ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref int ptr, int val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref int ptr, int val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref int ptr, int val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }

            public static int ExchangeRelaxed(ref int ptr, int val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static int ExchangeAcquire(ref int ptr, int val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static int ExchangeRelease(ref int ptr, int val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static int ExchangeSequential(ref int ptr, int val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static int CompareExchangeRelaxed(ref int ptr, int val, int cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static int CompareExchangeAcquire(ref int ptr, int val, int cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static int CompareExchangeRelease(ref int ptr, int val, int cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static int CompareExchangeSequential(ref int ptr, int val, int cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static int AddRelaxed(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static int AddAcquire(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static int AddRelease(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static int AddSequential(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static int SubtractRelaxed(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static int SubtractAcquire(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static int SubtractRelease(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static int SubtractSequential(ref int ptr, int val)
            {
                return Interlocked.Add(ref ptr, -val);
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="uint" />.
        /// </summary>
        public static class UInt32
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="uint" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            [CLSCompliant(false)]
            public static uint ReadRelaxed(ref uint ptr)
            {
                return ptr;
            }

            [CLSCompliant(false)]
            public static uint ReadAcquire(ref uint ptr)
            {
                return Volatile.Read(ref ptr);
            }

            [CLSCompliant(false)]
            public static uint ReadSequential(ref uint ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            [CLSCompliant(false)]
            public static void WriteRelaxed(ref uint ptr, uint val)
            {
                ptr = val;
            }

            [CLSCompliant(false)]
            public static void WriteRelease(ref uint ptr, uint val)
            {
                Volatile.Write(ref ptr, val);
            }

            [CLSCompliant(false)]
            public static void WriteSequential(ref uint ptr, uint val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }

            [CLSCompliant(false)]
            public static uint ExchangeRelaxed(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Exchange(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint ExchangeAcquire(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Exchange(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint ExchangeRelease(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Exchange(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint ExchangeSequential(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Exchange(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint CompareExchangeRelaxed(ref uint ptr, uint val, uint cmp)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.CompareExchange(ref *(int*)p, (int)val, (int)cmp);
            }

            [CLSCompliant(false)]
            public static uint CompareExchangeAcquire(ref uint ptr, uint val, uint cmp)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.CompareExchange(ref *(int*)p, (int)val, (int)cmp);
            }

            [CLSCompliant(false)]
            public static uint CompareExchangeRelease(ref uint ptr, uint val, uint cmp)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.CompareExchange(ref *(int*)p, (int)val, (int)cmp);
            }

            [CLSCompliant(false)]
            public static uint CompareExchangeSequential(ref uint ptr, uint val, uint cmp)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.CompareExchange(ref *(int*)p, (int)val, (int)cmp);
            }

            [CLSCompliant(false)]
            public static uint AddRelaxed(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint AddAcquire(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint AddRelease(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint AddSequential(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, (int)val);
            }

            [CLSCompliant(false)]
            public static uint SubtractRelaxed(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, -(int)val);
            }

            [CLSCompliant(false)]
            public static uint SubtractAcquire(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, -(int)val);
            }

            [CLSCompliant(false)]
            public static uint SubtractRelease(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, -(int)val);
            }

            [CLSCompliant(false)]
            public static uint SubtractSequential(ref uint ptr, uint val)
            {
                fixed (uint* p = &ptr)
                    return (uint)Interlocked.Add(ref *(int*)p, -(int)val);
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="long" />.
        /// </summary>
        public static class Int64
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="long" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return IntPtr.Size == sizeof(long); }
            }

            public static long ReadRelaxed(ref long ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static long ReadAcquire(ref long ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static long ReadSequential(ref long ptr)
            {
                return Interlocked.Read(ref ptr);
            }

            public static void WriteRelaxed(ref long ptr, long val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteRelease(ref long ptr, long val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref long ptr, long val)
            {
                Interlocked.Exchange(ref ptr, val);
            }

            public static long ExchangeRelaxed(ref long ptr, long val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static long ExchangeAcquire(ref long ptr, long val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static long ExchangeRelease(ref long ptr, long val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static long ExchangeSequential(ref long ptr, long val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static long CompareExchangeRelaxed(ref long ptr, long val, long cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static long CompareExchangeAcquire(ref long ptr, long val, long cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static long CompareExchangeRelease(ref long ptr, long val, long cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static long CompareExchangeSequential(ref long ptr, long val, long cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static long AddRelaxed(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static long AddAcquire(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static long AddRelease(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static long AddSequential(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, val);
            }

            public static long SubtractRelaxed(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static long SubtractAcquire(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static long SubtractRelease(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, -val);
            }

            public static long SubtractSequential(ref long ptr, long val)
            {
                return Interlocked.Add(ref ptr, -val);
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="ulong" />.
        /// </summary>
        public static class UInt64
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="ulong" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return IntPtr.Size == sizeof(ulong); }
            }

            [CLSCompliant(false)]
            public static ulong ReadRelaxed(ref ulong ptr)
            {
                return Volatile.Read(ref ptr);
            }

            [CLSCompliant(false)]
            public static ulong ReadAcquire(ref ulong ptr)
            {
                return Volatile.Read(ref ptr);
            }

            [CLSCompliant(false)]
            public static ulong ReadSequential(ref ulong ptr)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Read(ref *(long*)p);
            }

            [CLSCompliant(false)]
            public static void WriteRelaxed(ref ulong ptr, ulong val)
            {
                Volatile.Write(ref ptr, val);
            }

            [CLSCompliant(false)]
            public static void WriteRelease(ref ulong ptr, ulong val)
            {
                Volatile.Write(ref ptr, val);
            }

            [CLSCompliant(false)]
            public static void WriteSequential(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    Interlocked.Exchange(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong ExchangeRelaxed(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Exchange(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong ExchangeAcquire(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Exchange(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong ExchangeRelease(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Exchange(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong ExchangeSequential(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Exchange(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong CompareExchangeRelaxed(ref ulong ptr, ulong val, ulong cmp)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.CompareExchange(ref *(long*)p, (long)val, (long)cmp);
            }

            [CLSCompliant(false)]
            public static ulong CompareExchangeAcquire(ref ulong ptr, ulong val, ulong cmp)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.CompareExchange(ref *(long*)p, (long)val, (long)cmp);
            }

            [CLSCompliant(false)]
            public static ulong CompareExchangeRelease(ref ulong ptr, ulong val, ulong cmp)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.CompareExchange(ref *(long*)p, (long)val, (long)cmp);
            }

            [CLSCompliant(false)]
            public static ulong CompareExchangeSequential(ref ulong ptr, ulong val, ulong cmp)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.CompareExchange(ref *(long*)p, (long)val, (long)cmp);
            }

            [CLSCompliant(false)]
            public static ulong AddRelaxed(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong AddAcquire(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong AddRelease(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong AddSequential(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, (long)val);
            }

            [CLSCompliant(false)]
            public static ulong SubtractRelaxed(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, -(long)val);
            }

            [CLSCompliant(false)]
            public static ulong SubtractAcquire(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, -(long)val);
            }

            [CLSCompliant(false)]
            public static ulong SubtractRelease(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, -(long)val);
            }

            [CLSCompliant(false)]
            public static ulong SubtractSequential(ref ulong ptr, ulong val)
            {
                fixed (ulong* p = &ptr)
                    return (ulong)Interlocked.Add(ref *(long*)p, -(long)val);
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="float" />.
        /// </summary>
        public static class Single
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="float" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static float ReadRelaxed(ref float ptr)
            {
                return ptr;
            }

            public static float ReadAcquire(ref float ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static float ReadSequential(ref float ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref float ptr, float val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref float ptr, float val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref float ptr, float val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }

            public static float ExchangeRelaxed(ref float ptr, float val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static float ExchangeAcquire(ref float ptr, float val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static float ExchangeRelease(ref float ptr, float val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static float ExchangeSequential(ref float ptr, float val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static float CompareExchangeRelaxed(ref float ptr, float val, float cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static float CompareExchangeAcquire(ref float ptr, float val, float cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static float CompareExchangeRelease(ref float ptr, float val, float cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static float CompareExchangeSequential(ref float ptr, float val, float cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }
        }

        /// <summary>
        /// Provides atomic operations for <see cref="double" />.
        /// </summary>
        public static class Double
        {
            /// <summary>
            /// Determines whether atomic operations on <see cref="double" /> are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return IntPtr.Size == sizeof(double); }
            }

            public static double ReadRelaxed(ref double ptr)
            {
                return ptr;
            }

            public static double ReadAcquire(ref double ptr)
            {
                return Volatile.Read(ref ptr);
            }

            public static double ReadSequential(ref double ptr)
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed(ref double ptr, double val)
            {
                ptr = val;
            }

            public static void WriteRelease(ref double ptr, double val)
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential(ref double ptr, double val)
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }

            public static double ExchangeRelaxed(ref double ptr, double val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static double ExchangeAcquire(ref double ptr, double val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static double ExchangeRelease(ref double ptr, double val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static double ExchangeSequential(ref double ptr, double val)
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static double CompareExchangeRelaxed(ref double ptr, double val, double cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static double CompareExchangeAcquire(ref double ptr, double val, double cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static double CompareExchangeRelease(ref double ptr, double val, double cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static double CompareExchangeSequential(ref double ptr, double val, double cmp)
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }
        }

        /// <summary>
        /// Provides atomic operations for reference types.
        /// </summary>
        public static class Object
        {
            /// <summary>
            /// Determines whether atomic operations on reference types are lock-free.
            /// </summary>
            /// <value><c>true</c> if operations are lock-free; otherwise, <c>false</c>.</value>
            public static bool IsLockFree
            {
                get { return true; }
            }

            public static T ReadRelaxed<T>(ref T ptr)
                where T : class
            {
                return ptr;
            }

            public static T ReadAcquire<T>(ref T ptr)
                where T : class
            {
                return Volatile.Read(ref ptr);
            }

            public static T ReadSequential<T>(ref T ptr)
                where T : class
            {
                SequentialBarrier();

                var val = ptr;

                SequentialBarrier();

                return val;
            }

            public static void WriteRelaxed<T>(ref T ptr, T val)
                where T : class
            {
                ptr = val;
            }

            public static void WriteRelease<T>(ref T ptr, T val)
                where T : class
            {
                Volatile.Write(ref ptr, val);
            }

            public static void WriteSequential<T>(ref T ptr, T val)
                where T : class
            {
                SequentialBarrier();

                ptr = val;

                SequentialBarrier();
            }

            public static T ExchangeRelaxed<T>(ref T ptr, T val)
                where T : class
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static T ExchangeAcquire<T>(ref T ptr, T val)
                where T : class
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static T ExchangeRelease<T>(ref T ptr, T val)
                where T : class
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static T ExchangeSequential<T>(ref T ptr, T val)
                where T : class
            {
                return Interlocked.Exchange(ref ptr, val);
            }

            public static T CompareExchangeRelaxed<T>(ref T ptr, T val, T cmp)
                where T : class
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static T CompareExchangeAcquire<T>(ref T ptr, T val, T cmp)
                where T : class
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static T CompareExchangeRelease<T>(ref T ptr, T val, T cmp)
                where T : class
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }

            public static T CompareExchangeSequential<T>(ref T ptr, T val, T cmp)
                where T : class
            {
                return Interlocked.CompareExchange(ref ptr, val, cmp);
            }
        }
    }
}

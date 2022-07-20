using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FenomPlus.Helpers
{
    public class RingBuffer : ContentPage
    {
        private Timer TimeoutTimer;
        private int BufferTimeout;
        private int MaxBufferSize;
        private int BufferIndex;
        private short[] Buffer;
        private SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="timeout"></param>
        public RingBuffer(int maxSize, int timeout)
        {
            BufferTimeout = timeout;
            BufferIndex = 0;
            MaxBufferSize = maxSize;
            Buffer = new short[MaxBufferSize];
            TimeoutTimer = new Timer((state) => Add(0), null, BufferTimeout, BufferTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int Add(short val)
        {
            int totalValue = 0;
            _lock.WaitAsync();

            Buffer[BufferIndex] = val;
            BufferIndex++;
            if (BufferIndex >= MaxBufferSize) BufferIndex = 0;
            for (int tmpIndex = 0; tmpIndex < MaxBufferSize; tmpIndex++)
            {
                totalValue += Buffer[tmpIndex];
            }

            TimeoutTimer.Change(BufferTimeout, BufferTimeout);
            _lock.Release();
            return totalValue / MaxBufferSize;
        }

    }
}


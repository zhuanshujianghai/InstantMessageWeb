using Snowflake.Core;
using System;

namespace InstantMessage.Common
{
    public class IdGenerator
    {
        private static readonly object Singleton_Lock = new object();
        private static volatile IdWorker woker = null;
        public static long GetSnowflakeID()
        {
            if (woker == null)
            {
                lock (Singleton_Lock)
                {
                    if (woker == null)
                    {
                        woker = new IdWorker(DateTime.Now.Millisecond % 30, DateTime.Now.Second % 30);
                    }
                }
            }
            //lock (woker)
            //{
            //    if (Singleton<IdWorker>.Instance == null)
            //    {
            //        Singleton<IdWorker>.Instance = new IdWorker(1, 1);
            //    }
            //}
            return woker.NextId();
        }
    }
}

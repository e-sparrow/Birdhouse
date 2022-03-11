﻿using System;

namespace Tools.DateAndTime.Timestamps
{
    public class Timestamp : TimestampBase
    {
        public Timestamp(TimeSpan initialTime, Func<TimeSpan> getCurrentTime) : base(initialTime)
        {
            _getCurrentTime = getCurrentTime;
        }

        private readonly Func<TimeSpan> _getCurrentTime;

        protected override TimeSpan GetCurrentTime()
        {
            return _getCurrentTime.Invoke();
        }
    }
}
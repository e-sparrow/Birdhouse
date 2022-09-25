﻿using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Tense.Controllers;
using Birdhouse.Tools.Tense.Controllers.Interfaces;
using Birdhouse.Tools.Tense.Enums;
using Birdhouse.Tools.Tense.Expiration;
using Birdhouse.Tools.Tense.Expiration.Interfaces;
using Birdhouse.Tools.Tense.Timestamps;
using UnityEngine;

namespace Birdhouse.Common.Helpers
{
    public static class TenseHelper
    {
        public static class Terms
        {
            public static ITermInfo CreateTermInfo()
            {
                return new TermInfo();
            }

            public static ITermInfo CreateTermInfo(TimeSpan lifetime)
            {
                return new TermInfo(GetExpirationTime());

                DateTime GetExpirationTime()
                {
                    return DateTime.Now.Add(lifetime);
                }
            }
        }
        
        public static class Controllers
        {
            public static readonly IDictionary<ETenseType, ITenseController<DateTime>> DateTimeTenseControllers
                = new Dictionary<ETenseType, ITenseController<DateTime>>()
            {   
                [ETenseType.Default] = NowTenseController,
                [ETenseType.Utc] = UtcNowTenseController
            };
            
            public static readonly IDictionary<ETenseType, ITenseController<float>> FloatTenseControllers 
                = new Dictionary<ETenseType, ITenseController<float>>()
            {
                [ETenseType.InGame] = InGameTenseController,
                [ETenseType.InGameRealtime] = RealtimeTenseController
            };

            public static readonly ITenseController<float> InGameTenseController = CreateTenseController(() => Time.time);
            public static readonly ITenseController<float> RealtimeTenseController = CreateTenseController(() => Time.realtimeSinceStartup);
            public static readonly ITenseController<DateTime> NowTenseController = CreateTenseController(() => DateTime.Now);
            public static readonly ITenseController<DateTime> UtcNowTenseController = CreateTenseController(() => DateTime.UtcNow);

            public static ITenseController<T> CreateTenseController<T>(Func<T> func)
            {
                return new TenseController<T>(func);
            }
        }
        
        public static class Unix
        {
            public static readonly DateTime Origin = new DateTime(1970, 1, 1);

            public static long ToUnix(DateTime value)
            {
                return (long) (value - Origin).TotalSeconds;
            }

            public static DateTime FromUnix(long value)
            {
                return Origin.AddSeconds(value);
            }

            public static Timestamp CreateDefaultUnixTimestamp()
            {
                var origin = GetCurrentTimeSpan();
                return new Timestamp(origin, GetCurrentTimeSpan);

                TimeSpan GetCurrentTimeSpan()
                {
                    return DateTime.Now.ToUnixTimeSpan();
                }
            }

            public static ITenseController<long> AsUnixTenseController(ITenseController<DateTime> tenseController)
            {
                return Controllers.CreateTenseController(() => tenseController.Now().ToUnix());
            }
            
            public static ITenseController<TimeSpan> AsUnixTimeSpanTenseController(ITenseController<DateTime> tenseController)
            {
                return Controllers.CreateTenseController(() => tenseController.Now().ToUnixTimeSpan());
            }
        }
    }
}
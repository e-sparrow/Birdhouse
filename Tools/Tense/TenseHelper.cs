﻿using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Tense.Controllers;
using Birdhouse.Tools.Tense.Controllers.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Tense
{
    public static class TenseHelper
    {
        public static readonly ITenseProvider<float> InGameTenseProvider = Time.time.Get().AsTenseController();
        public static readonly ITenseProvider<float> RealtimeTenseProvider = CreateTenseController(() => Time.realtimeSinceStartup);

        public static readonly ITenseProvider<DateTime> NowTenseProvider = DateTime.Now.Get().AsTenseController();
        public static readonly ITenseProvider<DateTime> UtcNowTenseProvider = DateTime.UtcNow.Get().AsTenseController();
        
        public static ITenseProvider<T> CreateTenseController<T>(Func<T> func)
        {
            var result = new TenseProvider<T>(func);
            return result;
        }
    }
}
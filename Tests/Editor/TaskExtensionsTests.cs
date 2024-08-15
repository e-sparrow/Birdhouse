using System;
using System.Threading.Tasks;
using Birdhouse.Common.Tasks;
using NUnit.Framework;

namespace Birdhouse.Tests.Editor
{
    public class TaskExtensionsTests
    {
        private int _sampleTaskCount = 0;
        
        [Test]
        public async Task TestTaskExtensions()
        {
            // TODO: FIX
            await SampleTask()
                .RetryIfCatch(10)
                .Handle();
            
            await SampleResultingTask()
                .RetryIfCatch(10)
                .Handle();
        }

        private Task SampleTask()
        {
            _sampleTaskCount++;
            
            if (_sampleTaskCount < 5)
            {
                throw new Exception();
            }

            return Task.CompletedTask;
        }

        private Task<bool> SampleResultingTask()
        {
            _sampleTaskCount++;
            
            if (_sampleTaskCount < 5)
            {
                throw new Exception();
            }

            return Task.FromResult(true);
        }
    }
}
﻿using System.Collections.Generic;
using Dev2.Common;
using Dev2.Common.Interfaces.Monitoring;

namespace Dev2.PerformanceCounters.Counters
{
    public class WarewolfCurrentExecutionsPerformanceCounter : MyPerfCounter, IPerformanceCounter
    {
        bool _started;
        readonly WarewolfPerfCounterType _perfCounterType;

        public WarewolfCurrentExecutionsPerformanceCounter(IRealPerformanceCounterFactory performanceCounterFactory)
            :base(performanceCounterFactory)
        {
            _started = false;
            IsActive = true;
            _perfCounterType = WarewolfPerfCounterType.ConcurrentRequests;
        }

        public WarewolfPerfCounterType PerfCounterType => _perfCounterType;

        public IEnumerable<(string, string, PerformanceCounterType)> CreationData()
        {
            yield return (
                Name,
                Name,
                PerformanceCounterType.NumberOfItems32
            );
        }

        public void Reset()
        {
            if (_counter != null)
            {
                _counter.RawValue = 0;
            }
        }
        #region Implementation of IPerformanceCounter

        public void Increment()
        {
   
                if (IsActive)
            {
                _counter.Increment();
            }
        }

        public void IncrementBy(long ticks)
        {

            if(IsActive)
            {
                _counter.IncrementBy(ticks);
            }
        }

        public void Setup()
        {
            if (!_started)
            {
                _counter = _counterFactory.New(GlobalConstants.Warewolf, Name, GlobalConstants.GlobalCounterName);

                _started = true;
            }
        }

        public void Decrement()
        {

            if (IsActive && _counter.RawValue > 0)
            {

                _counter.Decrement();
            }

        }

        public string Category => "Warewolf";
        public string Name => "Concurrent requests currently executing";

        #endregion
    }
}


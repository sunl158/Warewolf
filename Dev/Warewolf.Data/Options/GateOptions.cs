﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warewolf.Data.Options.Enums;
using Warewolf.Options;

namespace Warewolf.Data.Options
{
    public class GateOptions 
    {
        public GateOptions()
        { }
        public YesNo Resume { get; set; } = YesNo.No;
        public Guid ResumeEndpoint { get; set; } = Guid.Empty;
        public int Count { get; set; } = 2;

        [DataValue(nameof(RetryAlgorithmBase.RetryAlgorithm))]
        [MultiDataProvider(typeof(NoBackoff), typeof(ConstantBackoff), typeof(LinearBackoff), typeof(FibonacciBackoff), typeof(QuadraticBackoff))]
        public RetryAlgorithmBase Strategy { get; set; } = new NoBackoff();
    }

    public enum YesNo
    {
        Yes = 1,
        No = 0
    }

    public abstract class RetryAlgorithmBase
    {
        public RetryAlgorithm RetryAlgorithm { get; set; }

        public abstract IEnumerable<bool> Create();
    }

    public class NoBackoff : RetryAlgorithmBase
    {
        public NoBackoff()
        {
            RetryAlgorithm = RetryAlgorithm.NoBackoff;
        }

        public int TimeOut { get; set; } = 60000;
        public int MaxRetries { get; set; } = 3;
        public override IEnumerable<bool> Create()
        {
            for (var i = 0; i < MaxRetries; i++)
            {
                yield return true;
            }

            yield return false;
        }
    }

    public class ConstantBackoff : RetryAlgorithmBase
    {
        public ConstantBackoff()
        {
            RetryAlgorithm = RetryAlgorithm.ConstantBackoff;
        }

        public int TimeOut { get; set; } = 60000;

        public int Increment { get; set; } = 100;
        public int MaxRetries { get; set; } = 2;
        public override IEnumerable<bool> Create()
        {
            for (var i = 0; i < MaxRetries; i++)
            {
                Task.Delay(Increment).Wait();
                yield return true;
            }

            yield return false;
        }
    }

    public class LinearBackoff : RetryAlgorithmBase
    {
        public LinearBackoff()
        {
            RetryAlgorithm = RetryAlgorithm.LinearBackoff;
        }

        public int TimeOut { get; set; } = 60000;
        public int Increment { get; set; } = 50;

        public int MaxRetries { get; set; } = 2;

        public override IEnumerable<bool> Create()
        {
            for (var i=0; i < MaxRetries; i++)
            {
                Task.Delay(i * Increment).Wait();
                yield return true;
            }

            yield return false;
        }
    }

    public class FibonacciBackoff : RetryAlgorithmBase
    {
        public FibonacciBackoff()
        {
            RetryAlgorithm = RetryAlgorithm.FibonacciBackoff;
        }

        public int TimeOut { get; set; } = 60000;
        public int MaxRetries { get; set; } = 2;
        public override IEnumerable<bool> Create()
        {
            var increment = 0;
            for (var i = 0; i < MaxRetries; i++)
            {
                Task.Delay(i * increment).Wait();
                yield return true;
            }

            yield return false;
        }
    }

    public class QuadraticBackoff : RetryAlgorithmBase
    {
        public QuadraticBackoff()
        {
            RetryAlgorithm = RetryAlgorithm.QuadraticBackoff;
        }

        public int TimeOut { get; set; } = 60000;
        public int MaxRetries { get; set; } = 2;
        public override IEnumerable<bool> Create()
        {
            var increment = 0;
            for (var i = 0; i < MaxRetries; i++)
            {
                Task.Delay(i * increment).Wait();
                yield return true;
            }

            yield return false;
        }
    }

    public class ConditionExpression : IOptionConvertable
    {
        public string Left { get; set; }

        [DataValue(nameof(Condition.MatchType))]
        [MultiDataProvider(typeof(ConditionMatch), typeof(ConditionBetween))]
        public Condition Cond { get; set; }

        public IOption[] ToOptions()
        {
            var option = new OptionConditionExpression
            {
                Left = Left
            };
            Cond?.SetOptions(option);
            return new[] {
                option
            };
        }
    }

    public abstract class Condition
    {
        public enDecisionType MatchType { get; set; }
        public abstract void SetOptions(OptionConditionExpression option);
    }
    public class ConditionMatch : Condition
    {
        public string Right { get; set; }
        public override void SetOptions(OptionConditionExpression option)
        {
            option.MatchType = MatchType;
            option.Right = Right;
        }
    }

    public class ConditionBetween : Condition
    {
        public string From { get; set; }
        public string To { get; set; }
        public override void SetOptions(OptionConditionExpression option)
        {
            option.MatchType = MatchType;
            option.From = From;
            option.To= To;
        }
    }

}

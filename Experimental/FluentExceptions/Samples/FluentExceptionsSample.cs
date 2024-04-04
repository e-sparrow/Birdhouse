using System;
using UnityEngine;

namespace Birdhouse.Experimental.FluentExceptions.Samples
{
    public sealed class FluentExceptionsSample
        : MonoBehaviour
    {
        [ContextMenu("Execute sample")]
        private void ExecuteSample()
        {
            var counter = 0;

            for (var i = 0; i < 10; i++)
            {
                FluentExceptions
                    .Try(Try)
                    .CaughtType<FirstException>(CatchFirst)
                    .Or<SecondException>(CatchSecond)
                    .Or<ThirdException>(CatchThird)
                    .Default(CatchOther)
                    .Finally(Finally)
                    .Handle();

                counter++;
            }

            void Try()
            {
                switch (counter % 10)
                {
                    case 0:
                        throw new FirstException();
                    
                    case 1:
                        throw new SecondException();
                    
                    case 2:
                        throw new ThirdException();
                    
                    default:
                        throw new Exception();
                }
            }

            void CatchFirst(FirstException exception)
            {
                Debug.LogWarning($"We caught the first exception!");
            }

            void CatchSecond(SecondException exception)
            {
                Debug.LogWarning($"We caught the second exception!");
            }

            void CatchThird(ThirdException exception)
            {
                Debug.LogWarning($"We caught the third exception!");
            }

            void CatchOther(Exception exception)
            {
                Debug.LogWarning($"Hm. We caught an unknown exception");
            }

            void Finally()
            {
                Debug.Log($"Finally block just executed");
            }
        }

        [ContextMenu("Execute resulting sample")]
        private void ExecuteResultingSample()
        {
            var counter = 0;

            for (var i = 0; i < 10; i++)
            {
                var code = FluentExceptions<EResultCode>
                    .Try(Try)
                    .CaughtType<FirstException>(CatchFirst)
                    .Or<SecondException>(CatchSecond)
                    .Or<ThirdException>(CatchThird)
                    .Default(CatchOther)
                    .Finally(Finally)
                    .Handle();

                Debug.Log($"Result code is \"{code}\"");
                
                counter++;
            }
            
            EResultCode Try()
            {
                switch (counter % 10)
                {
                    case 0:
                        break;
                    
                    case 1:
                        throw new FirstException();
                    
                    case 2:
                        throw new SecondException();
                    
                    case 3:
                        throw new ThirdException();
                    
                    default:
                        throw new Exception();
                }

                return EResultCode.Success;
            }

            EResultCode CatchFirst(FirstException exception) => EResultCode.FirstException;
            EResultCode CatchSecond(SecondException exception) => EResultCode.SecondException;
            EResultCode CatchThird(ThirdException exception) => EResultCode.ThirdException;
            EResultCode CatchOther(Exception exception) => EResultCode.UnknownException;
            

            void Finally()
            {
                Debug.Log($"Finally block just executed");
            }
        }

        private enum EResultCode
        {
            Success,
            FirstException,
            SecondException,
            ThirdException,
            UnknownException
        }

        private sealed class FirstException
            : Exception
        {
            
        }

        private sealed class SecondException
            : Exception
        {
            
        }

        private sealed class ThirdException
            : Exception
        {
            
        }
    }
}
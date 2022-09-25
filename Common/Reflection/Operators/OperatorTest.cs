namespace Birdhouse.Common.Reflection.Operators

{
    public class OperatorTest
    {
        public OperatorTest()
        {

        }

        public static implicit operator int(OperatorTest test)
        {
            return 0;
        }
        
        public static explicit operator OperatorTest(int value)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator +(OperatorTest test)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator -(OperatorTest test)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator !(OperatorTest test)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator ++(OperatorTest test)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator --(OperatorTest test)
        {
            return new OperatorTest();
        }

        public static bool operator true(OperatorTest test)
        {
            return true;
        }

        public static bool operator false(OperatorTest test)
        {
            return false;
        }

        public static OperatorTest operator +(OperatorTest left, OperatorTest right)
        {
            return new OperatorTest();
        }

        public static int operator +(OperatorTest left, int right)
        {
            return 0;
        }

        public static OperatorTest operator -(OperatorTest left, OperatorTest right)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator *(OperatorTest left, OperatorTest right)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator /(OperatorTest left, OperatorTest right)
        {
            return new OperatorTest();
        }

        public static OperatorTest operator %(OperatorTest left, OperatorTest right)
        {
            return new OperatorTest();
        }

        public static bool operator &(OperatorTest left, OperatorTest right)
        {
            return false;
        }

        public static bool operator |(OperatorTest left, OperatorTest right)
        {
            return false;
        }

        public static bool operator ^(OperatorTest left, OperatorTest right)
        {
            return false;
        }

        public static bool operator <<(OperatorTest left, int right)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator >>(OperatorTest left, int right)
        {
            return false;
        }

        public static bool operator !=(OperatorTest left, OperatorTest right)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator ==(OperatorTest left, OperatorTest right)
        {
            return false;
        }

        public static bool operator <(OperatorTest left, OperatorTest right)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator >(OperatorTest left, OperatorTest right)
        {
            return false;
        }

        public static bool operator <=(OperatorTest left, OperatorTest right)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator >=(OperatorTest left, OperatorTest right)
        {
            return false;
        }
    }
}
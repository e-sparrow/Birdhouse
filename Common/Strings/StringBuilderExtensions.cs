using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Birdhouse.Common.Strings
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendJoin
            (this StringBuilder self, string separator, IEnumerable<string> values)
        {
            var count = values.Count();
            
            var i = 0;
            foreach (var value in values)
            {
                self = self.Append(value);
                
                if (i != count - 1)
                {
                    self = self.Append(separator);
                }

                i++;
            }

            return self;
        }
        
        public static StringBuilder AppendJoin
            (this StringBuilder self, char separator, IEnumerable<string> values)
        {
            var count = values.Count();
            
            var i = 0;
            foreach (var value in values)
            {
                self = self.Append(value);
                
                if (i != count - 1)
                {
                    self = self.Append(separator);
                }

                i++;
            }

            return self;
        }

        public static StringBuilder AppendJoin
            (this StringBuilder self, string separator, params string[] values)
        {
            var result = self.AppendJoin(separator, (IEnumerable<string>) values);
            return result;
        }

        public static StringBuilder AppendJoin
            (this StringBuilder self, char separator, params string[] values)
        {
            var result = self.AppendJoin(separator, (IEnumerable<string>) values);
            return result;
        }
    }
}
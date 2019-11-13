using System;

namespace Cortside.Core.Util {
    /// <summary>
    /// Reprsents a range with a specific start and end
    /// </summary>
    public class Range<T> where T : IComparable<T> {
        public readonly T Start;
        public readonly T End;

        public Range(T start, T end) {
            if (start.CompareTo(end) == 1) {
                throw new ArgumentException("Invalid Range. Start must be before End.");
            }
            this.Start = start;
            this.End = end;
        }
    }

    public static class Range {
        public static bool Overlap<T>(Range<T> left, Range<T> right) where T : IComparable<T> {
            if (left.Start.CompareTo(right.Start) == 0) {
                return true;
            } else if (left.Start.CompareTo(right.Start) > 0) {
                return left.Start.CompareTo(right.End) <= 0;
            } else {
                return right.Start.CompareTo(left.End) <= 0;
            }
        }
    }
}
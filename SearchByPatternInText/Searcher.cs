using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string text, string pattern, bool overlap)
        {
            if (text is null || pattern is null)
            {
                throw new ArgumentException($"Text or pattern can not be null.");
            }

            var culture = StringComparison.InvariantCultureIgnoreCase;
            var list = new List<int>();
            var startIndex = 0;
            while (true)
            {
                var match = text.IndexOf(pattern, startIndex, culture);
                if (match == -1)
                {
                    break;
                }

                list.Add(match + 1);

                if (overlap)
                {
                    startIndex = match + 1;
                }
                else
                {
                    startIndex = match + pattern.Length;
                }
            }

            return list.ToArray();
        }
    }
}

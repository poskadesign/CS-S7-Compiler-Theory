// 
//   ListExtensions.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reverie.Exceptions;
using Reverie.SyntaxProcessing.Constructs;
using Reverie.Traits;

namespace Reverie.LexicalAnalysis.Extensions {
    public static class ListExtensions {

        /// <summary>
        /// Removes the first item in the list and checks if it matches the expected item.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="list">Current list.</param>
        /// <param name="expected">Expected list item.</param>
        /// <param name="exToThrow">Exception to throw, if assertion fails.</param>
        /// <returns></returns>
        public static T FirstWithAssert<T>(this IList<T> list, T expected, Exception exToThrow) where T : class {
            var first = list.First();
            if (first != expected)
                throw exToThrow;
            list.RemoveAt(0);
            return first;
        }

        /// <summary>
        /// Removes every other occurance of an element in a collection.
        /// Example: 1, 2, 2, 2, 3 --> 1, 2, 3
        /// </summary>
        public static IList<T> RemoveEveryOther<T>(this IList<T> list, T element) {
            var c = list.Count;
            var flagged = false;
            for (var i = 0; i < c; i++) {

                if (flagged &&  EqualityComparer<T>.Default.Equals(list[i], element)) {
                    list.RemoveAt(i);
                    c--;
                    i--;
                    continue;
                }
                flagged = EqualityComparer<T>.Default.Equals(list[i], element);
            }
            return list;
        }

        public static IList<ResolvedToken> RemoveEveryOtherToken(this IList<ResolvedToken> list, Token element)
        {
            var c = list.Count;
            var flagged = false;
            for (var i = 0; i < c; i++)
            {

                if (flagged && list[i].Type == element)
                {
                    list.RemoveAt(i);
                    c--;
                    i--;
                    continue;
                }
                flagged = list[i].Type == element;
            }
            return list;
        }

    }
}
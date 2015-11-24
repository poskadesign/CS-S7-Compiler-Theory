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

    }
}
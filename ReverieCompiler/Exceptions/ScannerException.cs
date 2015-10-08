// 
//   ScannerException.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-08
//   

using System;

namespace Reverie.Exceptions {
    public class ScannerException : Exception {
        public ScannerException(ErrorCode e) : base(e.ToString()) {}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Liskov_Example {
    public class CoffeeException : Exception{
        public CoffeeException(string message) : base(message) {

        }
    }
}

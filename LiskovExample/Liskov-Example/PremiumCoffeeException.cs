using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Liskov_Example {
    public class PremiumCoffeeException : Exception {
        public PremiumCoffeeException(string message) : base(message) {

        }
    }
}

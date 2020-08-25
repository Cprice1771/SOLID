using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Liskov_Example {
    public class Grinder {
        public GroundCoffee grind(CoffeeBean coffeeBean, double quantityCoffee) {
            return new GroundCoffee(coffeeBean.getName(), quantityCoffee);
        }
    }
}

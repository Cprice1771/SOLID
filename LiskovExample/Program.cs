using LiskovExample.Liskov_Example;
using SolidExamples.Liskov_Example;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovExample {
    public class Program {
        private static void BrewBasic() {
            BasicCoffeeMachine machine = new BasicCoffeeMachine();

            machine.AddCoffee(CoffeeSelection.FILTER_COFFEE, new GroundCoffee("My favorite filter coffee bean", 1000));
            
            
            CoffeeApp app = new CoffeeApp(machine);

          

            app.prepareCoffee(CoffeeSelection.FILTER_COFFEE);
        }

        private static void BrewPremium() {
            BasicCoffeeMachine machine = new PremiumCoffeeMachine();
            machine.AddCoffee(CoffeeSelection.ESPRESSO, new CoffeeBean("My favorite espresso bean", 1000));
            machine.AddCoffee(CoffeeSelection.FILTER_COFFEE, new CoffeeBean("My favorite filter coffee bean", 1000));

            CoffeeApp app = new CoffeeApp(machine);
            app.prepareCoffee(CoffeeSelection.ESPRESSO);
           
        }

        public static void Main(string[] args) {
            BrewBasic();
            BrewPremium();
        }
    }
}

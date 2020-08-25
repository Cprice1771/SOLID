using LiskovExample.Liskov_Example;
using System;
using System.Collections.Generic;

namespace SolidExamples.Liskov_Example {

    public class CoffeeApp {
        private BasicCoffeeMachine coffeeMachine;

        public CoffeeApp(BasicCoffeeMachine coffeeMachine) {
            this.coffeeMachine = coffeeMachine;
        }

        public CoffeeDrink prepareCoffee(CoffeeSelection selection) {
            try {
                CoffeeDrink coffee = this.coffeeMachine.BrewCoffee(selection);
                Console.WriteLine("Coffee is ready!");
                return coffee;
            } catch(CoffeeException e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
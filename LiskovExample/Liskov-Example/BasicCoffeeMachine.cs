using SolidExamples.Liskov_Example;
using System.Collections.Generic;

namespace LiskovExample.Liskov_Example {

    public interface ICoffeMacine {

    }

    public class BasicCoffeeMachine : ICoffeMacine {
        protected Dictionary<CoffeeSelection, Configuration> configMap;

        protected Dictionary<CoffeeSelection, Coffee> coffee;

        protected BrewingUnit brewingUnit;

        public BasicCoffeeMachine() {
            this.coffee = new Dictionary<CoffeeSelection, Coffee>(); ;
            this.brewingUnit = new BrewingUnit();

            this.configMap = new Dictionary<CoffeeSelection, Configuration> {
                { CoffeeSelection.FILTER_COFFEE, new Configuration(30, 480) }
            };
        }

        public virtual CoffeeDrink BrewCoffee(CoffeeSelection selection) {
            switch (selection) {
                case CoffeeSelection.FILTER_COFFEE:
                    return BrewFilterCoffee();

                default:
                    throw new CoffeeException($"CoffeeSelection [{selection}] not supported!");
            }
        }

        private CoffeeDrink BrewFilterCoffee() {
            Configuration config = configMap[(CoffeeSelection.FILTER_COFFEE)];
            GroundCoffee groundCoffee = (GroundCoffee)this.coffee[(CoffeeSelection.FILTER_COFFEE)];
            return this.brewingUnit.brew(CoffeeSelection.FILTER_COFFEE, groundCoffee, config.getQuantityWater());
        }

        public virtual void AddCoffee(CoffeeSelection sel, Coffee newCoffee) {
            if(!(newCoffee is GroundCoffee)) {
                throw new CoffeeException("Basic Coffee Machine only supports Ground Coffee");
            }

            InsertCoffee(sel, newCoffee);
        }

        protected void InsertCoffee(CoffeeSelection sel, Coffee newCoffee) {
            var existingCoffee = this.coffee.GetValueOrDefault(sel);
            if (existingCoffee != null) {
                if (existingCoffee.getName() == (newCoffee.getName())) {
                    existingCoffee.setQuantity(existingCoffee.getQuantity() + newCoffee.getQuantity());
                } else {
                    throw new CoffeeException("Only one kind of coffee	 supported for each CoffeeSelection.");
                }
            } else {
                this.coffee.Add(sel, newCoffee);
            }
        }
    }
}
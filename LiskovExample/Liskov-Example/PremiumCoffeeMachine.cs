using LiskovExample.Liskov_Example;
using System;
using System.Collections.Generic;

namespace SolidExamples.Liskov_Example {

    public class PremiumCoffeeMachine : ICoffeMacine {

        private Grinder grinder;


        public PremiumCoffeeMachine() : base() {
            this.grinder = new Grinder();
            this.brewingUnit = new BrewingUnit();

            this.configMap = new Dictionary<CoffeeSelection, Configuration>();
            this.configMap.Add(CoffeeSelection.FILTER_COFFEE, new Configuration(30, 480));
            this.configMap.Add(CoffeeSelection.ESPRESSO, new Configuration(8, 28));
        }

        public List<CoffeeSelection> GetBrewOptions() {
            return new List<CoffeeSelection> { CoffeeSelection.ESPRESSO, CoffeeSelection.FILTER_COFFEE };
        }

        public override CoffeeDrink BrewCoffee(CoffeeSelection selection) {
            switch (selection) {
                case CoffeeSelection.ESPRESSO:
                    return BrewEspresso();

                case CoffeeSelection.FILTER_COFFEE:
                    return BrewFilterCoffee();

                default:
                    throw new PremiumCoffeeException($"CoffeeSelection [{selection}] not supported!");
            }
        }

        private CoffeeDrink BrewEspresso() {
            Configuration config = configMap[CoffeeSelection.ESPRESSO];

            GroundCoffee groundCoffee = this.grinder.grind((CoffeeBean)this.coffee[CoffeeSelection.ESPRESSO], config.getQuantityCoffee());

            return this.brewingUnit.brew(CoffeeSelection.ESPRESSO, groundCoffee,
                    config.getQuantityWater());
        }

        private CoffeeDrink BrewFilterCoffee() {
            Configuration config = configMap[CoffeeSelection.FILTER_COFFEE];

            GroundCoffee groundCoffee = this.grinder.grind(
                    (CoffeeBean)this.coffee[CoffeeSelection.FILTER_COFFEE],
                    config.getQuantityCoffee());

            return this.brewingUnit.brew(CoffeeSelection.FILTER_COFFEE, groundCoffee,
                    config.getQuantityWater());
        }

        public override void AddCoffee(CoffeeSelection sel, Coffee coffee) {
            if (!(coffee is CoffeeBean)) {
                throw new PremiumCoffeeException("Basic Coffee Machine only supports Coffee Beans");
            }

            base.InsertCoffee(sel, coffee);
        }
    }
}
namespace SolidExamples.Liskov_Example {

    public interface ICoffeeMachine {

        CoffeeDrink brewCoffee(CoffeeSelection selection);
    }
}
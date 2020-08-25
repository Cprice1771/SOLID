namespace SolidExamples.Liskov_Example {

    public class Coffee {
        private string name;
        private double quantity;

        public Coffee(string name, double quantity) {
            this.name = name;
            this.quantity = quantity;
        }

        public string getName() {
            return name;
        }

        public double getQuantity() {
            return quantity;
        }

        public void setQuantity(double quantity) {
            this.quantity = quantity;
        }
    }
}
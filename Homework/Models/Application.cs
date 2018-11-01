namespace Homework.Models
{
    public struct Application
    {
        public int Identifier { get; }
        public int StartParcelNumber { get; }
        public int EndParcelNumber { get; }
        public int Price { get; }

        public Application(int identifier, int startParcelNumber, int endParcelNumber, int price)
        {
            this.Identifier = identifier;
            this.StartParcelNumber = startParcelNumber;
            this.EndParcelNumber = endParcelNumber;
            this.Price = price;
        }

        public Application(int identifier, string line)
        {
            Identifier = identifier;

            string[] data = line.Split(' ');

            StartParcelNumber = int.Parse(data[0]);
            EndParcelNumber = int.Parse(data[1]);
            Price = int.Parse(data[2]);
        }

        public bool Is(Application other)
        {
            return Identifier == other.Identifier;
        }

        public bool Intersects(Application other)
        {
            return ! Misses(other);
        }

        public bool Misses(Application other)
        {
            return StartParcelNumber < other.StartParcelNumber && EndParcelNumber < other.StartParcelNumber
                || StartParcelNumber > other.EndParcelNumber;
        }
    }
}

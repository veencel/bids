using Homework.Utils;

namespace Homework.Models
{
    public struct Combination
    {
        public Array<Application> Applications { get; }

        public Combination(Array<Application> applications)
        {
            Applications = applications;
        }

        public Combination Copy()
        {
            var copy = new Array<Application>();

            foreach (var application in Applications)
            {
                copy.Add(application);
            }

            return new Combination(copy);
        }

        public void Add(Application application)
        {
            Applications.Add(application);
        }

        public bool SameAs(Combination combination)
        {
            if (combination.Applications.Length != Applications.Length)
            {
                return false;
            }

            foreach (var application in Applications)
            {
                if (! combination.Applications.Has((app) => app.Identifier == application.Identifier))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Contains(Application application)
        {
            foreach (var other in Applications)
            {
                if (other.Is(application))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Intersects(Application application)
        {
            foreach (var other in Applications)
            {
                if (other.Intersects(application))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

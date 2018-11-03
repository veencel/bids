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

        public Combination(Combination combination)
        {
            var applications = new Array<Application>();

            foreach (var application in combination.Applications)
            {
                applications.Add(application);
            }

            Applications = applications;
        }

        public Combination Add(Application application)
        {
            Applications.Add(application);

            return this;
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

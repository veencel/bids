using System;
using System.Collections.Generic;

namespace Homework.Utils
{
    public class Array<T>
    {
        public T this[int key]
        {
            get { return items[key]; }
            set { items[key] = value; }
        }

        public int Length {
            get { return items.Length; }
        }

        T[] items;

        public Array()
        {
            items = new T[0];
        }

        public Array(T[] items)
        {
            this.items = items;
        }

        public Array<T> Add(T item)
        {
            Expand();

            items[Length - 1] = item;

            return this;
        }

        public T PopFirst()
        {
            T[] newItems = new T[Length - 1];

            T first = items[0];

            for (int i = 1; i < Length; i++)
            {
                newItems[i - 1] = items[i];
            }

            items = newItems;

            return first;
        }

        public T[] All()
        {
            return items;
        }

        public bool Has(Func<T, bool> predicate)
        {
            foreach (T item in items)
            {
                if (predicate.Invoke(item))
                {
                    return true;
                }
            }

            return false;
        }

        public Array<T> Merge(Array<T> other)
        {
            foreach (T item in other)
            {
                Add(item);
            }

            return this;
        }

        public Array<R> Map<R>(Func<T, R> callback)
        {
            var result = new Array<R>();

            foreach (T item in items)
            {
                result.Add(callback.Invoke(item));
            }

            return result;
        }

        public R Reduce<R>(Func<T, R, R> callback, R carry)
        {
            foreach (T item in items)
            {
                carry = callback(item, carry);
            }

            return carry;
        }

        public Array<T> Filter(Func<T, bool> callback)
        {
            var result = new Array<T>();

            foreach (T item in items)
            {
                if (callback.Invoke(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public T Max(Func<T, T, Boolean> callback)
        {
            T max = items[0];

            for (int i = 1; i < items.Length; ++i)
            {
                if (callback(items[i], max))
                {
                    max = items[i];
                }
            }

            return max;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Length; ++i)
            {
                yield return items[i];
            }
        }


        private void Expand()
        {
            T[] expanded = new T[items.Length + 1];

            for (int i = 0; i < items.Length; i++)
            {
                expanded[i] = items[i];
            }

            items = expanded;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Homework.Utils
{
    public class Array<T>
    {
        public T this[int key]
        {
            get => _items[key];
            set => _items[key] = value;
        }

        public int Length => _items.Length;

        T[] _items;

        public Array()
        {
            _items = new T[0];
        }

        public Array(T[] items)
        {
            this._items = items;
        }

        public Array<T> Add(T item)
        {
            Expand();

            _items[Length - 1] = item;

            return this;
        }

        public T PopFirst()
        {
            T[] newItems = new T[Length - 1];

            T first = _items[0];

            for (int i = 1; i < Length; i++)
            {
                newItems[i - 1] = _items[i];
            }

            _items = newItems;

            return first;
        }

        public T[] All()
        {
            return _items;
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

            foreach (T item in _items)
            {
                result.Add(callback.Invoke(item));
            }

            return result;
        }

        public R Reduce<R>(Func<T, R, R> callback, R carry)
        {
            foreach (T item in _items)
            {
                carry = callback(item, carry);
            }

            return carry;
        }

        public Array<T> Filter(Func<T, bool> callback)
        {
            var result = new Array<T>();

            foreach (T item in _items)
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
            T max = _items[0];

            for (int i = 1; i < _items.Length; ++i)
            {
                if (callback(_items[i], max))
                {
                    max = _items[i];
                }
            }

            return max;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Length; ++i)
            {
                yield return _items[i];
            }
        }


        private void Expand()
        {
            T[] expanded = new T[_items.Length + 1];

            for (int i = 0; i < _items.Length; i++)
            {
                expanded[i] = _items[i];
            }

            _items = expanded;
        }
    }
}

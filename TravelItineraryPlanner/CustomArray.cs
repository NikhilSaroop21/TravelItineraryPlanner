using System;
using System.Collections;
using System.Collections.Generic;

namespace TravelItineraryPlanner
{
    /// <summary>
    /// A simple generic dynamic array with add, search, remove, output, and optional resizing.
    /// </summary>
    public class CustomArray<T> : IEnumerable<T>
    {
        private T[] _items;
        public int Count { get; private set; }
        public int Capacity => _items.Length;

        public CustomArray(int initialCapacity = 4)
        {
            if (initialCapacity < 0) throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            _items = initialCapacity == 0 ? Array.Empty<T>() : new T[initialCapacity];
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)Count) throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
            set
            {
                if ((uint)index >= (uint)Count) throw new ArgumentOutOfRangeException(nameof(index));
                _items[index] = value;
            }
        }

        /// <summary>Adds an item, automatically resizing if needed.</summary>
        public void Add(T item)
        {
            EnsureCapacity(Count + 1);
            _items[Count++] = item;
        }

        /// <summary>Returns the index of the item or -1 if not found.</summary>
        public int IndexOf(T item, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            for (int i = 0; i < Count; i++)
            {
                if (comparer.Equals(_items[i], item))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item, IEqualityComparer<T>? comparer = null)
            => IndexOf(item, comparer) >= 0;

        /// <summary>Find the first item matching a condition; returns default if none.</summary>
        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            for (int i = 0; i < Count; i++)
                if (match(_items[i])) return _items[i];
            return default;
        }

        /// <summary>Remove first occurrence of item; returns true if removed.</summary>
        public bool Remove(T item, IEqualityComparer<T>? comparer = null)
        {
            int idx = IndexOf(item, comparer);
            if (idx < 0) return false;
            RemoveAt(idx);
            return true;
        }

        /// <summary>Remove item at index.</summary>
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)Count) throw new ArgumentOutOfRangeException(nameof(index));
            int moveCount = Count - index - 1;
            if (moveCount > 0)
                Array.Copy(_items, index + 1, _items, index, moveCount);
            _items[--Count] = default!; // clear last
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
        }

        /// <summary>Write all elements to the console.</summary>
        public void Output()
        {
            if (Count == 0)
            {
                Console.WriteLine("[Empty]");
                return;
            }
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{i}: {_items[i]}");
            }
        }

        /// <summary>Optional manual resize if the client wants to expand in advance.</summary>
        public void Resize(int newCapacity)
        {
            if (newCapacity < Count)
                throw new ArgumentException("New capacity cannot be less than Count.", nameof(newCapacity));

            if (newCapacity != _items.Length)
            {
                var newArr = new T[newCapacity];
                if (Count > 0)
                    Array.Copy(_items, newArr, Count);
                _items = newArr;
            }
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            if (Count > 0) Array.Copy(_items, arr, Count);
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureCapacity(int min)
        {
            if (_items.Length >= min) return;

            int newCap = _items.Length == 0 ? 4 : _items.Length * 2;
            if (newCap < min) newCap = min;
            Resize(newCap);
        }
    }
}

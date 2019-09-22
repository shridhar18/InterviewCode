using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public struct KeyValue2<K, V> {
        public K Key { get; set; }
        public V Value { get; set; }

    }

    public class FixedSizeHasTabel<K, V> {
        public int Size = 0;
        public readonly LinkedList<KeyValue2<K, V>>[] items;

        public FixedSizeHasTabel(int size) {
            Size = size;
            items = new LinkedList<KeyValue2<K, V>>[Size];
        }

        public void Add(K key, V value)
        {
            int position = keyPosition(key);
            LinkedList<KeyValue2<K, V>> ll = linkedList(position);
            foreach (KeyValue2<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    Console.WriteLine($"Duplicate {key} found");
                    return;
                }
            }
            ll.AddLast(new KeyValue2<K, V> { Key = key, Value = value });
        }

        public void Remove(K key)
        {
            int position = keyPosition(key);
            LinkedList<KeyValue2<K, V>> ll = linkedList(position);
            foreach (KeyValue2<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    ll.Remove(item);
                    break;
                }
            }
        }

        public V FindValue(K key)
        {
            int position = keyPosition(key);
            LinkedList<KeyValue2<K, V>> ll = linkedList(position);
            foreach (KeyValue2<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }
        public LinkedList<KeyValue2<K, V>> linkedList(int keyPosition)
        {
            LinkedList<KeyValue2<K, V>> item = items[keyPosition];
            if (item == null)
            {
                item = new LinkedList<KeyValue2<K, V>>();
                items[keyPosition] = item;
            }

            return item;
        }

        public int keyPosition(K key) {
            return Math.Abs(key.GetHashCode() % Size);
        }
    }
}
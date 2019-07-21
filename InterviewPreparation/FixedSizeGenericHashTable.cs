using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public struct KeyValue<K, V> {
        public  K Key { get; set; }
        public V Value { get; set; }
    }
    
    public class FixedSizeGenericHashTable<K, V>
    {

        private int Size;
        private readonly LinkedList<KeyValue<K, V>>[] Items;

        public FixedSizeGenericHashTable(int size) {
            Size = size;
            Items = new LinkedList<KeyValue<K, V>>[Size];
        }


        public void Add(K key, V value)
        {
            int position = ItemPosition(key);
            LinkedList<KeyValue<K, V>> ll = linkedList(position);
            foreach (KeyValue<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    Console.WriteLine("Duplicate value found");
                    return;
                }
            }
            KeyValue<K, V> kv = new KeyValue<K, V>() { Key = key, Value = value };
            ll.AddLast(kv);
        }

        public void Remove(K key)
        {
            int position = ItemPosition(key);
            LinkedList<KeyValue<K, V>> ll = linkedList(position);
            foreach (KeyValue<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    ll.Remove(item);
                    break;
                }
            }
        }

        public V Find(K key)
        {
            int position = ItemPosition(key);
            LinkedList<KeyValue<K, V>> ll = linkedList(position);
            foreach (KeyValue<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                   return item.Value;
                }
            }

            return default(V);
        }

        public int ItemPosition(K key)
        {
            return Math.Abs(key.GetHashCode() % Size);
        }

        public LinkedList<KeyValue<K, V>> linkedList(int  position)
        {
            LinkedList<KeyValue<K, V>> item = Items[position];

            if (item == null)
            {
                item = new LinkedList<KeyValue<K, V>>();
                Items[position] = item;
            }
            return item;
        }
    }

    public class TestHash
    {
        public void GetTestHash()
        {
            FixedSizeGenericHashTable<string, string> hash = new FixedSizeGenericHashTable<string, string>(20);

            hash.Add("1", "item 1");
            hash.Add("2", "item 2");
            hash.Add("2", "item 2");
            hash.Add("dsfdsdsd", "sadsadsadsad");

            string one = hash.Find("1");
            string two = hash.Find("2");
            string dsfdsdsd = hash.Find("dsfdsdsd");
            hash.Remove("dsfdsdsd");
            Console.WriteLine("Done");
        }
    }
}

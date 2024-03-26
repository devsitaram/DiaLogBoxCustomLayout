using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_workshop
{
    internal class Class2
    {   
        private Dictionary<string, int> userDictionary = new Dictionary<string, int>();

        public void AddValue(string key, int value)
        {
            userDictionary.Add(key, value);
        }

        public int GetValue(string key)
        {
            return userDictionary[key];
        }

        public void PrintValue()
        {
            foreach(var item in userDictionary)
            {
                Console.WriteLine($"{item.Value}: {item.Key}");
            }
        }
    }
}

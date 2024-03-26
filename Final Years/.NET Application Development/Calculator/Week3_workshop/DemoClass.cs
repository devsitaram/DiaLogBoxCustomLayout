using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_workshop
{

    internal class DemoClass
    {
        // variable
        public string FullName = "Sita Ram Thing";
        private string FirstName = "Sita Ram";
        string LastName = "Thing";
        public readonly string CollegeName = "Islington College";

        // data stractural
        string[] arrayExample = new string[5];
        List<string> listExample = new List<string>();
        Dictionary<string, int> dictionaryExample = new Dictionary<string, int>();

        public Dictionary<string, int> DictMethod(string moduleName, int moduleMark)
        {
            arrayExample[0] = moduleName;
            listExample.Add(moduleName);
            dictionaryExample.Add(moduleName, moduleMark);
            return dictionaryExample;
        }


        // funcations/methods
        public void NonReturnMethod()
        {
            Console.WriteLine(FullName);
        }

        public string ReturnableMethod()
        {
            if(FirstName == LastName)
            {
                return FirstName;
            }
            else
            {
                return FullName;
            }            
        }

        public void ParemMethod(string firstname)
        {
            FirstName = firstname;
        }

        public void OutParameterMethod(string firstName, string lastNale, out string newName)
        {
            newName = $"{firstName} {lastNale}";
        }

        public void OptionalParameterMethod(string fullName = "No Name", string collegeName = "No College Name")
        {
            FullName = fullName;
        }

        public void ExceptionMethod(string firstname)
        {
            if(firstname == "Santosh")
            {
                throw new Exception($"{firstname} is not allow");
            } 
            else
            {
                FirstName = firstname;
            }
        }
    }
}

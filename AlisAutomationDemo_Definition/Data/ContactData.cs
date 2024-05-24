using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisAutomationDemo_Definition.Data
{
    public class ContactData
    {
        public static IEnumerable<object[]> ContactDemoRequestData()
        {
            // [1] First Name, [2] Last Name, [3] Company Name, [4] Phone Number, [5] Email Address, [6] Communities, [7] Total Beds, [8] Message
            yield return new object[] { "Isaac", "Tester", "Test Company", "1234567890", "tillema97@gmail.com", "6", "40", "This is a test, please irgnore this demo request." };
        }

        public static IEnumerable<object[]> ContactDemoRequestData_NegativePath()
        {
            // [1] First Name, [2] Last Name, [3] Company Name, [4] Phone Number, [5] Email Address, [6] Communities, [7] Total Beds, [8] Message
            yield return new object[] { "Isaac", "Tester", "Test Company", "test", "testemail", "abc!@#", "def$%^", "This is a test, please irgnore this demo request." };
        }
    }
}

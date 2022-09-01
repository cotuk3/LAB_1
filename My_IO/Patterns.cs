using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace My_IO
{
    public static class Patterns
    {
        static string paternStudent = "Student [A-Za-z]+\\s+" +
                "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
                "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
                "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
                "\"residence\": \"(?<residence>\\w+)\",\\s+" +
                "\"course\": \"(?<course>[1-6]{1})\",\\s+" +
                "\"studentId\": \"(?<studentId>[A-Za-z]{2}\\s\\d{8})\"};";

        static string paternStudentDorm = "Student [A-Za-z]+\\s+" +
            "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
            "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
            "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
            "\"residence\": \"(?<residence>\\d{1,2}-\\d{3})\",\\s+" +
            "\"course\": \"(?<course>[1-6]{1})\",\\s+" +
            "\"studentId\": \"(?<studentId>[A-Za-z]{2}\\s\\d{8})\"};";

        static string paternGardener = "Gardener [A-Za-z]+\\s+" +
            "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
            "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
            "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
            "\"residence\": \"(?<residence>[A-Za-z]+)\",\\s+" +
            "\"employer\": \"(?<employer>[A-Za-z]+\\s*[A-Za-z]+)\"};";

        static string paternSeller = "Seller [A-Za-z]+\\s+" +
            "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
            "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
            "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
            "\"residence\": \"(?<residence>[A-Za-z]+)\",\\s+" +
            "\"product\": \"(?<product>[A-Za-z]+)\"};";

        static string paternPerson = "\\w+ [A-Za-z]+\\s+" +
            "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
            "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
            "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
            "\"residence\": ";

        static string patern3D = "Student [A-Za-z]+\\s+" +
                "{ \"firstname\": \"(?<firstname>[A-Za-z]+)\",\\s+" +
                "\"lastname\": \"(?<lastname>[A-Za-z]+)\",\\s+" +
                "\"sex\": \"(?<sex>[A-Za-z]+)\",\\s+" +
                "\"residence\": \"(?<residence>\\d{1,2}-\\d{3})\",\\s+" +
                "\"course\": \"(?<course>[3])\",\\s+" +
                "\"studentId\": \"(?<studentId>[A-Za-z]{2}\\s\\d{8})\"};";

        public static Regex regex3D = new Regex(patern3D);
        public static Regex regexSt = new Regex(paternStudent);
        public static Regex regexG = new Regex(paternGardener);
        public static Regex regexSe = new Regex(paternSeller);
        public static Regex regexStD = new Regex(paternStudentDorm);
        public static Regex regexPer = new Regex(paternPerson);
    }
}

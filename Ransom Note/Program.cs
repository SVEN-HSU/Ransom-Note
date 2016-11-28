//https://leetcode.com/problems/ransom-note/
//Accepted
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ransom_Note
{
    class Program
    {
        static void Main(string[] args)
        {

            //"fffbfg" "effjfggbffjdgbjjhhdegh"
            string a = "fffbfg";
            string b = "effjfggbffjdgbjjhhdegh";
            Program p = new Program();
            Console.WriteLine("p.CanConstruct(" + a + ", " + b + ")=" + p.CanConstruct(a, b));
            Console.Read();
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            // expected falses:
            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }

            if (magazine == "" || ransomNote == "")
            {
                return true;
            }

            char[] _ransomNote = ransomNote.ToCharArray();
            char[] _magazine = magazine.ToCharArray();
            
            Dictionary<char, int> dic_r = new Dictionary<char, int>(0);
            Dictionary<char, int> dic_m = new Dictionary<char, int>(0);
            
            // building 2 dictionaries... (char, count of same chars)
            for (int i = 0; i < _ransomNote.Length; i++)
            {
                if (dic_r.ContainsKey(_ransomNote[i]))
                {
                    dic_r[_ransomNote[i]]++;
                }
                else
                {
                    dic_r.Add(_ransomNote[i], 1);
                }
            }

            for (int i = 0; i < _magazine.Length; i++)
            {
                if (dic_m.ContainsKey(_magazine[i]))
                {
                    dic_m[_magazine[i]]++;
                }
                else
                {
                    dic_m.Add(_magazine[i], 1);
                }
            }

            foreach (var x in dic_r)
            {
                if (dic_m.ContainsKey(x.Key))
                {
                    // if same key found in magazine, get the value of key in magazine
                    // this value should larger than the value of key in ransom note.
                    int p;
                    dic_m.TryGetValue(x.Key, out p);
                    if (p < x.Value)
                    {
                        return false;
                    }
                }
                else
                {
                    // every keys in ransom note should be contained in magazine
                    return false;
                }
            }

            return true;
        }
    }
}

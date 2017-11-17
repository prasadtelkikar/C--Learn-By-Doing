using System;
using System.Collections.Generic;
using System.Text;
namespace C_Sharp_Data_Structure
{
    public class stackoverflow
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        public static void Main()
        {
            int valu;
            bool test = Enum.TryParse<Days>("sun", true, out valu);
            Console.WriteLine(test.ToString());
            Console.WriteLine(valu);
            Console.ReadKey();

    }

}
        //List<string> list = new List<string>();
        //list.Add("This is a string.");
        //list.Add("String words occurrences needs to be checked.");
        //list.Add("how many times do this string text conatin words?");
        //list.Add("how how how");
        //StringBuilder sb = new StringBuilder();


        //Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        //dict.Add("how",4 );
        //dict.Add("this",2); 
        //dict.Add("string",2);
        //dict.Add("words",2);
        //dict.Add("occurrences",1);
        //dict.Add("checked",1);

        //FindSentenceWithMaxOcc(list, dict);

    //}
        //Function to print maximum occurances of word from dictionary with sentence
        //public static void FindSentenceWithMaxOcc(List<string> list, Dictionary<string, int>dict){

        //    int maxSentenceIndex = 0, index = 0;
        //    int maxCount = int.MinValue;
        //    string word = "";
        //    Dictionary<string, int> result = new Dictionary<string, int>();

        //    //Iterate through dictionary containing words with total occurances
        //    foreach(KeyValuePair<string, int> kv in dict){
                
        //        //Iterating through sentences present in list
        //        foreach(string element in list){
        //            //Split all words using space
        //            string[] words = element.Split(' ');
        //            //Count all occurrances of dictionary key in sentence
        //            int temp = Array.FindAll(words, s => s.Equals(kv.Key.Trim())).Length;
                    
        //            //Get max occurrances 
        //            if(temp > maxCount){
        //                maxCount = temp;
        //                maxSentenceIndex = index;
        //                word = kv.Key;
        //            }
        //            index++;
        //        }
        //        index = 0;
        //    }

        //    //Print result
        //    Console.WriteLine("Maximum count: " +maxSentenceIndex);
        //    Console.WriteLine("Word: " +word);
        //    Console.WriteLine("Sentence" +list[maxSentenceIndex]);
        //}
    //}
}

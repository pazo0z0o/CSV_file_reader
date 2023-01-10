using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOP_tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] file = ReadFile("values.csv");
            List<Person> people = new List<Person>();

            people=GetPeople(file);
            
            PrintPeople(people);
            
            Console.ReadKey();


        }
        //read from file - return lines | file name = path to file
        static string[] ReadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }
       
        //get people from file and returns list of people (string[])
        static List<Person> GetPeople(string[] file )
        {   


            //key : int and the value is the List element
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Person> people = new List<Person>();
           
            //get items from file
         for(int i =0; i < file.Length; i++) file_items.Add(i, GetItems(file[i]));
            
         //create person objects
            for(int i = 1; i < file.Length; i++)
            {
                Person p;
                string firstname = "", lastname="", occupation="";
                int age=0;
                
                for(int j = 0; j < file_items[0].Count; j++)
                {
                    switch (file_items[0][j].ToLower())
                    {
                        case "firstname":
                            firstname = file_items[i][j];
                            break;
                        case "lastname":
                            lastname = file_items[i][j];
                            break;
                        case "occupation":
                            occupation= file_items[i][j];
                            break;
                        case "age":
                            age =int.Parse( file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($" Header '{file_items[0][j]} is invalid header");
                            break;

                    }
                    p = new Person(firstname,lastname,age,occupation);
                    people.Add(p);
                }
              
               
            }

            //return new instance of people
            return new List<Person>(people);
        }
        
        //returns string list of items from the words it passes through the values.csv file
        static List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();
            
            foreach (char c in line)
            { 
                if (c == ',')
                {
                    if(current_word != "")
                    {
                     items.Add(current_word);
                     current_word = "";
                    }
                }
                else 
                { 
                current_word += c.ToString(); //converts  ',' into a string
                }             
            }
            if(current_word != "") {items.Add(current_word); } // we do that for the last field of the csv that doesn't have a , 
            //return new instance of items list to avoid overwritting the one we took lines from
            return new List<string> (items);
        }
        
        // print the info of the people in the PERSON list
        static void PrintPeople(List<Person> people) 
        {
        foreach(Person p in people) 
            {
                Console.WriteLine($"{p.Firstname} {p.Lastname} is {p.Age.ToString()} and works as a(n) {p.Occupation}" );
            
            }
        
        }

    }
}

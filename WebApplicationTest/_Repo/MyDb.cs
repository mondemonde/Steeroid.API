using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest._Repo
{
    public class DbManager
    {
        public List<string> GetResults()
        {
           

            return MyDb.Results.AsEnumerable().Reverse().ToList();
            //var myList = MyDb.Results.ToArray();
            //myList.Reverse();
            //return myList.ToList();

        }
    }

    //in-memory list
    public static class MyDb
    {   
        public  static List<string> Results { get; set; }


    }
}
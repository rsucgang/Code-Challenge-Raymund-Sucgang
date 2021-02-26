using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Code_Challenge_Raymund_Sucgang.Helper
{
    class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}

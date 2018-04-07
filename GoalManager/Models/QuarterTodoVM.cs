using System;
using System.Collections.Generic;

namespace GoalManager.Models
{
    public class QuarterTodoVM
    {
        public QuarterTodoVM()
        {
        }


        public List<Goal> Todos { get; set; }
        public string Intro { get { return "Quarter Goals"; } }
        public string Summary { get { return " There is " + Todos.Count + " Goals this quarter"; } }
    }
}

using System;
using System.Collections.Generic;

namespace GoalManager.Models
{
    public class WeekTodoVM
    {
        public WeekTodoVM()
        {
        }

        public List<Goal> Todos { get; set; }
        public string Intro { get { return "Weekly Goals"; } }
        public string Summary { get { return " There is " + Todos.Count + " Goals this week"; } }
    }
}

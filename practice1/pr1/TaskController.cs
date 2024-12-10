using pr1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz1
{
    class TaskController
    {
        private ITask[] tasks;

        public TaskController(ITask[] tasks)
        {
            this.tasks = tasks;
        }

        public void RunAll()
        {
            foreach (var task in tasks)
            {
                task.Execute();
                Console.WriteLine();
            }
        }
    }
}
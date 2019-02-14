using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTemplate.Models
{
    public abstract class Combinator
    {
        //Template method
        public void Combine()
        {
            //Steps
            OpenFiles();
            CreateFiles();
            CloseFiles();
        }

        public abstract void OpenFiles();
        public abstract void CreateFiles();
        public abstract void CloseFiles();
    }
}

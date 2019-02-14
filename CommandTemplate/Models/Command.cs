using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTemplate.Models
{
    public abstract class Command
    {
        public string Name { get; set; }
        public string SysName { get; set; }

        public abstract Task ExecuteAsync();
    }
}

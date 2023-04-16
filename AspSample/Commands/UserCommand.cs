using CqrsInvolve.Pattern;
using Sample.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Commands
{
    public class UserCommand:ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

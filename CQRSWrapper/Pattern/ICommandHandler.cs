using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CQRS.Pattern
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {

        Task Handle(TCommand command);
    }
}

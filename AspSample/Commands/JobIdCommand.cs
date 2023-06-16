using CQRS.Pattern;

namespace AspSample.Commands
{
    public class JobIdCommand :ICommand
    {
        public int JobId { get; set; }

        public string JobName { get; set; }
        public bool IsFail { get; set; }

    }
}

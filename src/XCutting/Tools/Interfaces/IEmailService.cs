using System.Threading.Tasks;

namespace IssuesManager.Tools
{
    public interface IEmailService
    {
        Task SendAsync(string To, string subject, string body);
    }
}
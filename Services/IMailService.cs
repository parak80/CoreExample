//this is the extraction interface of class NullMailService
namespace CoreExample.Services
{
	public interface IMailService
	{
		void SendMessage(string to, string subject, string body);
	}
}
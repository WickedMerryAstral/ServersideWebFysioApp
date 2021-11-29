using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
	public interface ICommentRepository
	{
		IEnumerable<Comment> GetComments();
		IEnumerable<Comment> GetCommentsByPatient(Patient p);
		int AddComment(Comment c);
	}
}

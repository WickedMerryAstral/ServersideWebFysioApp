using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Domain;

namespace Infrastructure.EF.Fysio
{
    public class EFCommentRepository : ICommentRepository
    {
        private FysioDBContext context;
        public EFCommentRepository(FysioDBContext db)
        {
            this.context = db;
        }

        public int AddComment(Comment c)
        {
            context.Add(c);
            context.SaveChanges();
            return c.commentId;
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.comments;
        }

        public IEnumerable<Comment> GetCommentsByPatient(Patient p)
        {
            return context.comments.Where(comm =>
            comm.patient.patientId == p.patientId);
        }
    }
}

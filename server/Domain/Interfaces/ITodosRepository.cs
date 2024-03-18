using Domain.Models;

namespace Domain.Interfaces {
    public interface ITodosRepository : IRepository<Todo> {
        Task<Todo> GetDuplicate( Todo model );
        void ChangeCompletedOrNot ( Todo model );
    }
}

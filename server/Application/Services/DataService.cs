using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services {
    public class DataService : IDataService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ITodoGroupsServices TodoGroupsServices { get; }
        public ITodoListsServices TodoListsServices { get; }

        public DataService (
            IUnitOfWork unitOfWork,
            IMapper mapper,

            IRepository<TodoGroup> TodoGroupsRepository,
            IRepository<TodoList> TodoListsRepository

        ) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            TodoGroupsServices = new TodoGroupsServices ( _unitOfWork, _mapper, TodoGroupsRepository);
            TodoListsServices = new TodoListsServices ( _unitOfWork, _mapper, TodoListsRepository );
        }
    }
}

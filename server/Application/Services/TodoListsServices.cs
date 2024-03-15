using Application.Dtos.TodoGroup;
using Application.Dtos.TodoList;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class TodoListsServices : Service<TodoList, TodoListDTO, TodoListViewModel>, ITodoListsServices {
        public TodoListsServices (
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<TodoList> repository
        ) : base ( unitOfWork, mapper, repository ) { }

        public async Task<TodoListViewModel> GetDuplicate ( TodoListDTO dto ) {
            if ( dto == null ) return null;

            var model = _mapper.Map<TodoList>( dto );
            var matchinhModel = await _unitOfWork
                .TodoListsRepository
                .GetDuplicate(model);

            if ( matchinhModel == null ) return null;
            var viewModel = _mapper.Map<TodoListViewModel>(matchinhModel);
            return viewModel;
        }
    }
}

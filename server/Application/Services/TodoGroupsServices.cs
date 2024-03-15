using Application.Dtos.TodoGroup;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class TodoGroupsServices : Service<TodoGroup, TodoGroupDTO, TodoGroupViewModel>, ITodoGroupsServices {
        public TodoGroupsServices ( 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IRepository<TodoGroup> repository 
        ) : base ( unitOfWork, mapper, repository ) { }

        public async Task<TodoGroupViewModel> GetDuplicate ( TodoGroupDTO dto ) {
            if ( dto == null ) return null;

            var model = _mapper.Map<TodoGroup>( dto );
            var matchinhModel = await _unitOfWork
                .TodoGroupsRepository
                .GetDuplicate(model);

            if ( matchinhModel == null ) return null;
            var viewModel = _mapper.Map<TodoGroupViewModel>(matchinhModel);
            return viewModel;
        }
    }
}

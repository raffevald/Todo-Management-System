using Application.Dtos.Todo;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services {
    public class TodosServices : Service<Todo, TodoDTO, TodoViewModel>, ITodosServices {
        public TodosServices (
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Todo> repository
        ) : base ( unitOfWork, mapper, repository ) { }

        public async Task<TodoViewModel> GetDuplicate ( TodoDTO dto ) {
            if ( dto == null ) return null;

            var model = _mapper.Map<Todo>( dto );
            var matchinhModel = await _unitOfWork
                .TodosRepository
                .GetDuplicate(model);

            if ( matchinhModel == null ) return null;
            var viewModel = _mapper.Map<TodoViewModel>(matchinhModel);
            return viewModel;
        }

        public async Task<TodoViewModel> ChangeCompletedOrNot ( int id, bool isCompleted ) {
            if ( id <= 0 ) return default;

            var model = await _repository.Get( id );
            if ( model == null ) return default;

            model.Completed = isCompleted;

            _unitOfWork.TodosRepository
                .ChangeCompletedOrNot ( model );

            var rowsAffected = await _unitOfWork.SaveChanges();
            if ( rowsAffected <= 0 ) return default;

            var updateDto = _mapper.Map<TodoViewModel>( model );
            return updateDto;
        }
    }
}

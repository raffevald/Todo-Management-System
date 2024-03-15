using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services {
    public class Service<TModel, TDto, TViewModel> : IService<TModel, TDto, TViewModel> where TModel : class {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepository<TModel> _repository;

        public Service (
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<TModel> repository
            ) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<TViewModel>> Get ( ) {
            var models = await _repository.Get();

            if ( models == null || models.Count <= 0 ) return null;

            var viewModel = _mapper.Map<List<TViewModel>>( models );
            return viewModel;
        }

        public async Task<TDto> Get ( int id ) {
            var model = await _repository.Get(id);

            if ( model == null ) return default;

            var dto = _mapper.Map<TDto>( model );
            return dto;
        }

        public async Task<TDto> Create ( TDto dto ) {
            if ( dto == null ) return default;

            var model = _mapper.Map<TModel>( dto );
            _repository.Create( model );

            var rowsAffected = await _unitOfWork.SaveChanges();
            if ( rowsAffected <= 0 ) return default;

            var createDto = _mapper.Map<TDto>( model );
            return createDto;
        }

        public async Task<TDto> Update ( TDto dto ) {
            if ( dto == null ) return default;

            var model = _mapper.Map<TModel>( dto );
            _repository.Update ( model );

            var rowsAffected = await _unitOfWork.SaveChanges();
            if ( rowsAffected <= 0 ) return default;

            var updateDto = _mapper.Map<TDto>( model );
            return updateDto;
        }

        public async Task<int> Delete ( int id ) {
            if ( id <= 0 ) return -1;

            var model = await _repository.Get( id );
            if ( model == null ) return -1;

            _repository.Delete( model );
            var rowsDelete = await _unitOfWork.SaveChanges();
            return rowsDelete;
        }

        public async Task<List<TDto>> CreateRange ( List<TDto> dtos ) {
            if ( dtos == null || dtos.Count <= 0 ) return null;

            var models = _mapper.Map<List<TModel>>( dtos );
            _repository.CreateRange ( models );

            var rowsAffected = await _unitOfWork.SaveChanges();
            if ( rowsAffected <= 0 ) return null;

            var createDtos = _mapper.Map<List<TDto>>( models );
            return createDtos;
        }

        public async Task<List<TDto>> UpdateRange ( List<TDto> dtos ) {
            if ( dtos == null || dtos.Count <= 0 ) return null;

            var models = _mapper.Map<List<TModel>>( dtos );
            _repository.UpdateRange ( models );

            var rowsAffected = await _unitOfWork.SaveChanges();
            if ( rowsAffected <= 0 ) return null;

            var updateDtos = _mapper.Map<List<TDto>>( models );
            return updateDtos;
        }

        public async Task<int> DeleteRange ( List<TDto> dtos ) {
            if ( dtos == null || dtos.Count <= 0 ) return -1;

            var models = _mapper.Map<List<TModel>>( dtos );

            _repository.DeleteRange ( models );
            var rowsDelete = await _unitOfWork.SaveChanges();
            return rowsDelete;
        }

    }
}

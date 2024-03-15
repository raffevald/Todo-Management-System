using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IService<TModel, TDto, TViewModel> where TModel : class {
        Task<List<TViewModel>> Get ( );
        Task<TDto> Get ( int id );
        Task<TDto> Create ( TDto dto );
        Task<TDto> Update ( TDto dto );
        Task<int> Delete ( int id );
        Task<List<TDto>> CreateRange ( List<TDto> dtos );
        Task<List<TDto>> UpdateRange ( List<TDto> dtos );
        Task<int> DeleteRange ( List<TDto> dtos );
    }
}

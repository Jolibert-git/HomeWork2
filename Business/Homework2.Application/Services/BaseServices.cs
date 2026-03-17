using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;


namespace Homework2.Application.Services
{
    public class BaseServices<TEntities, TDTO>: IBaseServices<TEntities,TDTO>
        where TEntities: class, IHasId
        where TDTO: class
    {
        public readonly IMapper _mapper;
        public readonly IGenericRepository<TEntities> _repository;
        public readonly UnitOfWork _work;

        public BaseServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<TEntities> repository
                           )
        {
            this._mapper = mapper;
            this._work = work;
            this._repository = repository;
        }


        public async Task<ApiResponses<IEnumerable<TDTO>>> GetAllEntityAsync()
        {
            var varieble = await _repository.GetAllAsync();
            var variebleDTO = _mapper.Map<IEnumerable<TDTO>>(varieble);

            if (varieble is null)
                return ApiResponses< IEnumerable<TDTO>>.ErrorResponse("Problem for get all Entity");

            return ApiResponses<IEnumerable<TDTO>>.SuccessResponse(variebleDTO, " found secessfull");
        }

        public async Task<ApiResponses<TDTO>> GetEntityByIdAsync(int id)
        {
            var varieble = await _repository.GetAsync(id);
            var variebleDTO = _mapper.Map<TDTO>(varieble);

            if (variebleDTO is null)
            {
                return ApiResponses<TDTO>.ErrorResponse($"Propierty not found with Id: {id}");
            }

            return ApiResponses<TDTO>.SuccessResponse(variebleDTO," found secessfull");
        }

        public async Task<ApiResponses<TDTO>> PostEntityAsync(TEntities entity)
        {

            await _repository.PostAsync(entity);

            var entityDTO = _mapper.Map<TDTO>(entity);

            return ApiResponses<TDTO>.SuccessResponse(entityDTO , "Post sucessfull");    
        }

        public async Task<ApiResponses<TDTO>> UpdateEntityAsync(int id, TEntities entity)
        {
            var variebleDTO = _mapper.Map<TDTO>(entity);

            if (id != entity.Id)
            {
                return ApiResponses<TDTO>.ErrorResponse( $"Propierty not match with Ids {id} and {entity.Id} ");
            }

            await _repository.UpdateAsync(id, entity);
            return ApiResponses<TDTO>.SuccessResponse(variebleDTO, " Entity Update sucessfull");
        }

        public async Task<ApiResponses<TDTO>> DeleteEntityAsync(int id)
        {
            var varieble = _repository.GetAsync(id);

            var variebleDTO = _mapper.Map<TDTO>(varieble);

            var resul = await _repository.DeleteAsync(id);

            if (resul == 0)
            {
                return ApiResponses<TDTO>.ErrorResponse($"Not found entity with Id: {id}");
            }


            return ApiResponses<TDTO>.SuccessResponse(variebleDTO, "Deleted Succesfull");
        }
    }
}

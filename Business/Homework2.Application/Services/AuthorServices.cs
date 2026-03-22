using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Authors;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Homework2.Application.Services
{
    public class AuthorServices: BaseServices<Author, AuthorDTO>, IAuthorServices
    {
        
        public AuthorServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<Author> repository
                              )
            :base(mapper,work, repository )
        {
        }



        public async Task<ApiResponses<AuthorWithBooksDTO>> GetAuthorWithBooksAsync(int id)
        {
            var author = await _work.Author.GetAuthorBooks(id);//select Author with him books 

            if (author == null) 
                return ApiResponses<AuthorWithBooksDTO>.ErrorResponse("This author doesn't exist", 404); ;

            var dto = _mapper.Map<AuthorWithBooksDTO>(author);

            return ApiResponses<AuthorWithBooksDTO>.SuccessResponse(dto);
        }

        

        public async Task<ApiResponses<AuthorPatchDTO>> PatchAuthorAsync(int id, JsonPatchDocument<AuthorPatchDTO> patchDoc, ModelStateDictionary modelState)
        {
            // 1. Buscamos la entidad original
            var author = await _work.Author.GetAsync(id);
            if (author is null)
                  return ApiResponses<AuthorPatchDTO>.ErrorResponse($"Autor con id {id} no encontrado", 404);
            

            // 2. Mapeamos a DTO
            var authorPatchDto = _mapper.Map<AuthorPatchDTO>(author);

            // 3. Aplicamos el parche
            patchDoc.ApplyTo(authorPatchDto, modelState);

            // 4. Validamos los datos parcheados
            if (!modelState.IsValid)
                return ApiResponses<AuthorPatchDTO>.ErrorResponse("Error en la validación de los datos", 400);
            

            // 5. Mapeamos de vuelta a la entidad original y guardamos
            _mapper.Map(authorPatchDto, author);
            await _work.Complite();

            return ApiResponses<AuthorPatchDTO>.SuccessResponse(authorPatchDto, "Autor parcheado exitosamente");
        }



    }
}

namespace Eng_assessment.Services.Interface
{
    public interface IService<TEntity, TGetDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TGetDto>> GetAll();
        Task<TGetDto> GetById(long id);
        Task<TEntity> Create(TCreateDto entity);
        Task<TGetDto> Update(long id, TUpdateDto entity);
        Task Delete(long id);
    }
}

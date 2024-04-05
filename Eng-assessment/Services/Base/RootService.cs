using AutoMapper;
using Eng_assessment.Repositories.Interface;
using Eng_assessment.Services.Interface;
using Models.Entities.Base;

namespace Eng_assessment.Services.Base
{
    public abstract class RootService<TEntity, TGetDto, TCreateDto, TUpdateDto> : IService<TEntity, TGetDto, TCreateDto, TUpdateDto>
        where TEntity : DatabaseEntity
        where TGetDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        protected RootService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TGetDto>> GetAll()
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TGetDto>>(entities);
        }

        public virtual async Task<TGetDto> GetById(long id)
        {
            TEntity entity = await _repository.GetAsync(id) ?? throw new KeyNotFoundException("Entity not found for this ID");
            return _mapper.Map<TGetDto>(entity);
        }

        public virtual async Task<TEntity> Create(TCreateDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TGetDto> Update(long id, TUpdateDto dto)
        {
            TEntity entity = await _repository.GetAsync(id, true) ?? throw new KeyNotFoundException("Entity not found for this ID");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TGetDto>(entity);
        }

        public virtual async Task Delete(long id)
        {
            TEntity entity = await _repository.GetAsync(id, true) ?? throw new KeyNotFoundException("Entity not found for this ID");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}

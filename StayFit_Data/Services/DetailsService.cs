using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.DetailsDto;
using StayFit.StayFit_Data.Extension;

namespace StayFit.StayFit_Data.Services;

public class DetailsService
{
    private readonly IRepository<Details> _detailsRepository;

    public DetailsService(IRepository<Details> detailsRepository)
    {
        _detailsRepository = detailsRepository;
    }
    
    public async Task<Details> NewDetails(DetailsCreateDto newDetails)
    {
        var detailEntity = newDetails.ToDetailsEntity();
        await _detailsRepository.Add(detailEntity);
        return detailEntity;
    }

    public async Task DeleteDetail(int detailId)
    {
        await _detailsRepository.Delete(detailId);
    }

    public async Task<DetailsViewDto> GetById(int productId)
    {
        var product = await _detailsRepository.Get(productId);
        return product.ToDetailsViewDto();
    }

}
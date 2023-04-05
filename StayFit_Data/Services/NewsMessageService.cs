using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.NewsMessageDTO;
using StayFit.StayFit_Data.Extension;
namespace StayFit.StayFit_Data.Services;
public class NewsMessageService
{
    private readonly IRepository<NewsMessage> _newsMessageRepository;

    public NewsMessageService(IRepository<NewsMessage> newsMessageRepository)
    {
        _newsMessageRepository = newsMessageRepository;
    }
    public async Task<List<NewsMessageViewDto>> ListProducts()
    {
        var products = await _newsMessageRepository.GetAll();
        return products.ToListProductViewDto();
    }
    public async Task<NewsMessage> NewNewsMessage(NewsMessageCreateDto newDetails)
    {
        var detailEntity = newDetails.ToNewsMessageEntity();
        await _newsMessageRepository.Add(detailEntity);
        return detailEntity;
    }

    public async Task DeleteNewsMessage(int detailId)
    {
        await _newsMessageRepository.Delete(detailId);
    }

    public async Task<NewsMessageViewDto> GetById(int productId)
    {
        var product = await _newsMessageRepository.Get(productId);
        return product.ToNewsMessageViewDto();
    }
}
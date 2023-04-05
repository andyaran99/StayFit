using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.NewsMessageDTO;

namespace StayFit.StayFit_Data.Extension;


public static class NewsMessageExtension
{
    public static NewsMessage ToNewsMessageEntity(this NewsMessageViewDto newsMessageView)
    {
        return new NewsMessage
        {
            Id = newsMessageView.Id,
            Description = newsMessageView.Description,
            Title = newsMessageView.Title,
            
            
        };
    }

    public static NewsMessage ToNewsMessageEntity(this NewsMessageCreateDto newsMessageView)
    {
        return new NewsMessage
        {
            Description = newsMessageView.Description,
            Title = newsMessageView.Title,
        };
    }

    public static NewsMessageViewDto ToNewsMessageViewDto(this NewsMessage newsMessageEntity)
    {
        return new NewsMessageViewDto
        {
            Id = newsMessageEntity.Id,
            Description = newsMessageEntity.Description,
            Title = newsMessageEntity.Title
        };
    }
    
    public static List<NewsMessageViewDto> ToListProductViewDto(this List<NewsMessage> newsMessageEntities)
    {
        List<NewsMessageViewDto> result = new List<NewsMessageViewDto>();
        foreach (var newsMessageEntity in newsMessageEntities)
        {
            result.Add(ToNewsMessageViewDto(newsMessageEntity));
        }
        return result;
    }
}
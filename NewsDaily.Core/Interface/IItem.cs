using NewsDaily.Core.Enums;

namespace NewsDaily.Core.Interface
{
    public interface IItem
    {
        long Id { get; }
        string Headline { get; }
        string Description { get; }
        ApplicationEnums.NewsCategory NewsCategory { get; }
        ApplicationEnums.NewsPriority Priority { get; }
        ApplicationEnums.NewsPriority GetPriority();
        long GetId();
        string GetHeadLine();
        string GetDescription();
        ApplicationEnums.NewsCategory GetNewsCategory();
    }
}

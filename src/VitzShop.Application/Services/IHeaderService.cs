namespace VitzShop.Web.Services
{
    public interface IHeaderService
    {
        string LogoText { get; set; }
        event Action HeaderChanged;    
    }
}

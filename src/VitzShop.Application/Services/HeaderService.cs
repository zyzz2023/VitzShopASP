using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Collections.Specialized;

namespace VitzShop.Web.Services
{
    public class HeaderService : IHeaderService
    {
        private string _logoText = "V I T Z";

        public string LogoText
        {
            get => _logoText;
            set
            {
                if (_logoText != value)
                {
                    _logoText = value;
                    NotifyStateChanged();
                }
            }
        }
        public event Action HeaderChanged;
        private void NotifyStateChanged() => HeaderChanged?.Invoke();
    }
}

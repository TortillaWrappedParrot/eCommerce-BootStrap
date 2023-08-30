namespace eCommerceSite.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int curPage) 
        { 
            Games = games;
            LastPage = lastPage;
            CurrentPage = curPage;
        }

        public List<Game> Games { get; private set; }

        public int LastPage { get; private set;}

        public int CurrentPage { get; private set;}
    }
}

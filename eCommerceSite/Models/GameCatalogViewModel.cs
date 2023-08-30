namespace eCommerceSite.Models
{
    /// <summary>
    /// GameCatalog page with the list of showing games, last page,
    /// and the current page
    /// </summary>
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int curPage) 
        { 
            Games = games;
            LastPage = lastPage;
            CurrentPage = curPage;
        }

        /// <summary>
        /// The list of all games for the page
        /// </summary>
        public List<Game> Games { get; private set; }

        /// <summary>
        /// The last avaliable page
        /// </summary>
        public int LastPage { get; private set;}

        /// <summary>
        /// The current page being shown
        /// </summary>
        public int CurrentPage { get; private set;}
    }
}


namespace MinimalApis
{
    public class ArticleServices
    {
        private List<Article> _list = new List<Article>
        {
            new Article(1, "Marteau"),
            new Article(2, "Scie")
        };

        public List<Article> GetAll() => _list;

        public Article Add(string title)
        {
            Article article = new Article(_list.Max(article => article.Id) +1, title);
            _list.Add(article);
            return article;
        }


    }
}

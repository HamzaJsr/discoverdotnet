
namespace MinimalApis
{
    public class ArticleServices
    {
        private List<Article> list = new List<Article>
        {
            new Article(1, "Marteau"),
            new Article(2, "Scie")
        };

        public List<Article> GetAll() => list;

        public Article Add(string title)
        {
            Article article = new Article(list.Max(article => article.Id) +1, title);
            list.Add(article);
            return article;
        }


    }
}

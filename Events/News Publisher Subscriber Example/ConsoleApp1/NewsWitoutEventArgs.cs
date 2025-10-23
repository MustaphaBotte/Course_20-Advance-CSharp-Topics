namespace NewsExampleWitoutEventArgs
{ 
class NewsArticle
{
        public string NewsTitle { get;} = "";
        public DateTime NewsDate { get;}
        public string NewsContent { get;} = "";

        public NewsArticle(string newsTitle, DateTime newsDate, string newsContent)
        {
            if (newsTitle != "" && newsContent != "")
            {
                this.NewsTitle = newsTitle;
                this.NewsContent = newsContent;
                this.NewsDate = newsDate;
            }
        }
        public NewsArticle() { }
    }
class NewsPublisher
{
    public event EventHandler<NewsArticle> OnNewsAdded = delegate { };
    public void AddNews(string newsTitle, DateTime newsDate, string newsContent)
    {
        if (newsTitle != "" && newsContent != "")
        {
            
            RaiseEventOnNewsAdded(new NewsArticle( newsTitle, newsDate, newsContent));
        }
    }
    private void RaiseEventOnNewsAdded(NewsArticle newsArticle)
    {
        OnNewsAdded?.Invoke(this,newsArticle);
    }
}
class NewsChannel
{
    public void Subscribe(NewsPublisher news)
    {
        news.OnNewsAdded += HandleNews;
    }
    public void UnSubscribe(NewsPublisher news)
    {
        news.OnNewsAdded -= HandleNews;
    }
    private void HandleNews(object?sender,NewsArticle newsArticle)
    {      
        Console.WriteLine("======================================================");
        Console.WriteLine($"News Title    :{newsArticle.NewsTitle}");
        Console.WriteLine($"News DateTime :{newsArticle.NewsDate.ToString()}");
        Console.WriteLine($"News Content  :{newsArticle.NewsContent}");
        Console.WriteLine("======================================================");
    }
}
class Program
    {
        static void Main()
        {
            NewsPublisher todaynews = new NewsPublisher();
            NewsChannel moroccannews24 = new NewsChannel();
            NewsChannel AlgeriaNews = new NewsChannel();

            moroccannews24.Subscribe(todaynews);
            AlgeriaNews.Subscribe(todaynews);

            todaynews.AddNews("trump visited morocco", new DateTime(2025, 10, 15, 16, 00, 15), "any news i dont know   ");
            AlgeriaNews.UnSubscribe(todaynews);
            todaynews.AddNews("trump visited morocco", new DateTime(2025, 10, 15, 16, 00, 15), "any news i dont know   ");


        }

    }

}
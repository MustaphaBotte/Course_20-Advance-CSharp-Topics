

class NewsEventArgs:EventArgs
{
    public string NewsTitle { get; } = "";
    public DateTime NewsDate { get; }
    public string NewsContent { get; } = "";

    public NewsEventArgs(string newsTitle, DateTime newsDate, string newsContent)
    {
        NewsTitle = newsTitle;
        NewsDate = newsDate;
        NewsContent = newsContent;
    }
}
class News
{
    public event EventHandler<NewsEventArgs> OnNewsAdded= delegate { };
    public string NewsTitle { get; set; } = "";
    public DateTime NewsDate { get; set; }
    public string NewsContent { get;set; } = "";
    public void AddNews(string newsTitle, DateTime newsDate, string newsContent)
    {
        if(newsTitle!="" && newsContent!="")
        {
            this.NewsTitle = newsTitle;
            this.NewsContent = newsContent;
            this.NewsDate = newsDate;
            RaiseEventOnNewsAdded();
        }
    }
    private void RaiseEventOnNewsAdded()
    {
        OnNewsAdded?.Invoke(this,new NewsEventArgs(this.NewsTitle, this.NewsDate, this.NewsContent));
    }
}

class NewsChannel
{
    public void Subscribe(News news)
    {
        news.OnNewsAdded += HandleNews;
    }
    private void HandleNews(object? sender, EventArgs e)
    {
        NewsEventArgs newsEventArgs = (NewsEventArgs)e;
        Console.WriteLine("======================================================");
        Console.WriteLine($"News Title    :{newsEventArgs.NewsTitle}");
        Console.WriteLine($"News DateTime :{newsEventArgs.NewsDate.ToString()}");
        Console.WriteLine($"News Content  :{newsEventArgs.NewsContent}");
        Console.WriteLine("======================================================");

    }
}
class NewsWithEventArgs
{
    //static void Main()
    //{
    //    News TodayNews = new News();
    //    NewsChannel MoroccanNews24 = new NewsChannel();
    //    MoroccanNews24.Subscribe(TodayNews);
    //    TodayNews.AddNews("Trump visited morocco for the third time", new DateTime(2025, 10, 15, 16, 00, 15), "any News i dont know   ");
    //}
    // just for the entry point to be set to other file
}
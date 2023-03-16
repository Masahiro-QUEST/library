namespace BlazorDemo.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "日刊現代", "日経BP", "宝島社", 
    };

    private static readonly string[] titles = new[]
{
        "うさまる お部屋ライト BOOK (バラエティ)", "ＴＶガイドＡｌｐｈａ　EPISODE KKK (TVガイドMOOK)", "MG（NO.15） (TVガイドMOOK)",
    };

    private static readonly string[] author = new[]
{
        "大岡　玲","岡野原　大輔","Ｅｘｃｅｌ医", };

    public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            author = titles[Random.Shared.Next(Summaries.Length)],
            title = author[Random.Shared.Next(Summaries.Length)],
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }
}


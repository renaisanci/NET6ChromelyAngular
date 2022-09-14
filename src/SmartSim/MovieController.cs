// Copyright © 2017 Chromely Projects. All rights reserved.
// Use of this source code is governed by MIT license that can be found in the LICENSE file.

#pragma warning disable CA1822

using Chromely.Core.Configuration;
using Chromely.Core.Infrastructure;
using Chromely.Core.Network;
using System.Xml.Linq;

namespace SmartSim;

/// <summary>
/// The movie controller.
/// </summary>
[ChromelyController(Name = "MovieController")]
public class MovieController : ChromelyController
{
    private readonly IChromelyConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieController"/> class.
    /// </summary>
    public MovieController(IChromelyConfiguration config)
    {
        _config = config;
    }


    [ChromelyRoute(Path = "/democontroller/showdevtools")]
    public void ShowDevTools()
    {
        if (_config != null && !string.IsNullOrWhiteSpace(_config.DevToolsUrl))
        {
            BrowserLauncher.Open(_config.Platform, _config.DevToolsUrl);
        }
    }

    [ChromelyRoute(Path = "/democontroller/movies/get")]
    public IEnumerable<WeatherForecast> GetMovies()
    {
        string[] WinMonitor = { "WinMonitor", "" };
        string[] HL7 = { "HL7", "" };
        string[] Cobas = { "COBAS", "" };

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {


            Number = Guid.NewGuid(),
            Instrument = "Cobas" + Random.Shared.Next(100, 600).ToString(),
            ASTM = "ASTM",
            HL7 = Random.Shared.Next(HL7.Length - 1, HL7.Length).ToString(),
            Cobas = Random.Shared.Next(Cobas.Length - 1, Cobas.Length).ToString(),
            Poct1 = "POCT1-A",
            WinMonitor = Random.Shared.Next(WinMonitor.Length - 1, WinMonitor.Length).ToString()
        }).ToList();

    }

    [ChromelyRoute(Path = "/democontroller/movies/post")]
    public string SaveMovies(List<MovieInfo> movies)
    {
        var rowsReceived = movies != null ? movies.Count : 0;
        return $"{DateTime.Now}: {rowsReceived} rows of data successfully saved.";
    }
}

public class WeatherForecast
{
 

    public Guid Number { get; set; }
    public string? Instrument { get; set; }
    public string? ASTM { get; set; }
    public string? HL7 { get; set; }
    public string? Cobas { get; set; }
    public string Poct1 { get; set; }
    public string? WinMonitor { get; set; }

}

/// <summary>
/// The movie info.
/// </summary>
public class MovieInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovieInfo"/> class.
    /// </summary>
    public MovieInfo()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieInfo"/> class.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <param name="title">
    /// The title.
    /// </param>
    /// <param name="year">
    /// The year.
    /// </param>
    /// <param name="votes">
    /// The votes.
    /// </param>
    /// <param name="rating">
    /// The rating.
    /// </param>
    /// <param name="assembly">
    /// The assembly.
    /// </param>
    public MovieInfo(int id, string title, int year, int votes, double rating, string assembly)
    {
        Id = id;
        Title = title;
        Year = year;
        Votes = votes;
        Rating = rating;
        Date = DateTime.Now;
        RestfulAssembly = assembly;
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public int Year { get; set; }

    public int Votes { get; set; }

    public double Rating { get; set; }

    public DateTime Date { get; set; }

    public string? RestfulAssembly { get; set; }
}


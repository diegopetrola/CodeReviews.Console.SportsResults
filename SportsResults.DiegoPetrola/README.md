# Basketball Scraper

An automated .NET background service that scrapes daily basketball game summaries from 
[Basketball Reference](https://www.basketball-reference.com/boxscores/) and sends a formatted HTML report via email.
This is a project for the [C# Academy](https://www.thecsharpacademy.com/project/19/sports-results).

## Features

- **Automated Daily Scraping:** Uses `PeriodicTimer` to run once every 24 hours.
- **Headless Web Scraping:** Utilizes **Playwright** to handle TLS handshakes and avoid `403 Forbidden` errors
- **HtmlAgilityPack** for fast DOM parsing.
- **HTML Email Reports:** Generates a clean, tabled summary of Team 1 vs. Team 2, including period scores and the match winner.
- **Robust Logging:** Integrated with .NET `ILogger` for tracking service health and errors.

## Tech Stack

- **Runtime:** .NET 10.0
- **Scraping:** Microsoft Playwright & HtmlAgilityPack
- **Communication:** System.Net.Mail (SMTP)

## Prerequisites

1. **.NET SDK** (Version 9.0 or later).
2. **Playwright Browsers:** Playwright requires specific browser binaries to run.

## ⚙️ Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/diegopetrola/CodeReviews.Console.SportsResults
   cd CodeReviews.Console.SportsResults/SportsResults.DiegoPetrola
   ```

2. **Install dependencies:**
   ```bash
   dotnet restore
   ```

3. **Install Playwright Browsers:**
   This is a required step for the scraper to work:
   ```bash
   dotnet build
   ```
   *Then run (on Windows):*
   ```bash
   pwsh bin/Debug/net<YOUR_VERSION_HERE>/playwright.ps1 install firefox
   ```

## Configuration

Update your `appsettings.json` with your SMTP server details. An example file is providaded.

## Execution

To start the service:

```bash
dotnet run
```

The service will:
1. Immediately perform the first scrape.
2. Send the email report.
3. Wait 24 hours before repeating the process.

If you are testing locally using papercut, ensure the ports match and the service is running.

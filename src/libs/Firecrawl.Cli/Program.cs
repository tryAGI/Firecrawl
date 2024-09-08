﻿using System.CommandLine;
using Firecrawl.Cli.Commands;

var rootCommand = new RootCommand(
    description: "CLI tool to use Firecrawl API");
rootCommand.AddCommand(new AuthCommand());
rootCommand.AddCommand(new ScrapeCommand());

return await rootCommand.InvokeAsync(args).ConfigureAwait(false);
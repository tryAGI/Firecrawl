#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class BillingApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"billing", @"Billing endpoint commands.");
                         command.Subcommands.Add(BillingGetCreditUsageCommandApiCommand.Create());
                         command.Subcommands.Add(BillingGetTokenUsageCommandApiCommand.Create());
        return command;
    }
}
#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class BillingApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"billing", @"Billing endpoint commands.");
                         command.Subcommands.Add(BillingGetCreditUsageCommandApiCommand.Create());
                         command.Subcommands.Add(BillingGetTokenUsageCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}
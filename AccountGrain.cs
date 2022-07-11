using Orleans;
using Orleans.Runtime;
using Sphere.Interfaces;
using Sphere.Shared.Models;

namespace Sphere.Grains;

public class AccountGrain : Grain, IAccount
{
    private readonly IPersistentState<AccountState> account;

    public AccountGrain(
        [PersistentState("accounts", "accountStore")]
        IPersistentState<AccountState> persistedAccount)
    {
        account = persistedAccount;
    }

    public async Task<AccountState> RegisterAccount(AccountState newAccount)
    {
        // TODO: some validation and whatnot
        account.State = newAccount;

        await account.WriteStateAsync();

        return account.State;
    }

    public Task<AccountState> GetAccountState()
    {
        return Task.FromResult(account.State);
    }

    public async Task<AccountState> UpdateAccount(AccountState updatedAccount)
    {
        account.State = updatedAccount;

        await account.WriteStateAsync();

        return account.State;
    }
}

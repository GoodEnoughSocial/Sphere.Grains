using Orleans;
using Orleans.Runtime;
using Sphere.Interfaces;
using Sphere.Shared.Models;

namespace Sphere.Grains;

public class ProfileGrain : Grain, IUserProfile
{
    private readonly IPersistentState<UserProfileState> profile;

    public ProfileGrain(
        [PersistentState("profiles", "profilesStore")]
        IPersistentState<UserProfileState> persistedAccount)
    {
        profile = persistedAccount;
    }

    public Task<UserProfileState> GetProfile()
    {
        return Task.FromResult(profile.State);
    }

    public async Task<UserProfileState> Update(UserProfileState updatedProfile)
    {
        profile.State = updatedProfile;
        await profile.WriteStateAsync();

        return profile.State;
    }
}

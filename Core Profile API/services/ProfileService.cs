public class ProfileService : IProfileService
{
    private static List<Profile> Profiles = Profile.InitProfiles();
    private static int nextId = 3;

    public IEnumerable<Profile> GetAll()
    {
        return Profiles.ToList();
    }

    public Profile? GetById(int id)
    {
        return Profiles.FirstOrDefault(s => s.Id == id);
    }

    public Profile Create(CreateProfileDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        var newProfile = new Profile(nextId++, dto.Name, dto.Age);
        Profiles.Add(newProfile);

        return newProfile;
    }

    public bool Update(int id, UpdateProfileDto dto)
    {
        var Profile = GetById(id);
        if (Profile == null)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        Profile.Name = dto.Name;
        Profile.Age = dto.Age;

        return true;
    }

    public bool Delete(int id)
    {
        var Profile = GetById(id);
        if (Profile == null)
        {
            return false;
        }

        Profiles.Remove(Profile);
        return true;
    }
}

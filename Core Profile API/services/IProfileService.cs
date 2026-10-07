public interface IProfileService
{
    IEnumerable<Profile> GetAll();
    Profile? GetById(int id);
    Profile Create(CreateProfileDto dto);
    bool Update(int id, UpdateProfileDto dto);
    bool Delete(int id);
}

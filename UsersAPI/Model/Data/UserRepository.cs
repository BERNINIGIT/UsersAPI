namespace UsersAPI.Model.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(UsersDbContext dbContext) : base(dbContext)
        {
        }
    }
}

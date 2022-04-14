namespace UsersAPI.Model.Contracts
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user);
    }
}

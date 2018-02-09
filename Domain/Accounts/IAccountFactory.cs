namespace Domain.Accounts
{
    public interface IAccountFactory
    {
        Account Build(AccountHolder holder);
    }
}
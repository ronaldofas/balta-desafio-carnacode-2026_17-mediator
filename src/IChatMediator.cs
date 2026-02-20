namespace DesignPatternChallenge
{
    // Interface do Mediador que define os métodos de comunicação
    public interface IChatMediator
    {
        void RegisterUser(User user);
        void BroadcastMessage(User sender, string message);
        void SendPrivateMessage(User sender, User recipient, string message);
        void MuteUser(User admin, User target);
        void LeaveGroup(User user);
    }
}

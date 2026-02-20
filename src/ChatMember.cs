namespace DesignPatternChallenge
{
    // A implementação concreta do Usuário (Colleague)
    // Agora o membro só sabe da existência do Mediador, com o qual ele se acopla através da herança
    public class ChatMember : User
    {
        public ChatMember(string name) : base(name)
        {
        }
    }
}

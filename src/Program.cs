using System;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("      SISTEMA ORIGINAL (SEM DESIGN PATTERN)      ");
            Console.WriteLine("==================================================");
            
            OriginalProgram.Main(args);
            
            Console.WriteLine("\n\n==================================================");
            Console.WriteLine("    SISTEMA REFATORADO (COM PADRÃO MEDIATOR)     ");
            Console.WriteLine("==================================================");
            
            // Criando o Mediador (A Sala de Chat)
            IChatMediator chatRoom = new ChatRoom();

            // Criando Usuários
            User alice = new ChatMember("Alice");
            User bob = new ChatMember("Bob");
            User carlos = new ChatMember("Carlos");
            User diana = new ChatMember("Diana");

            Console.WriteLine("=== Usuários Entrando no Grupo ===");
            // O próprio mediador é quem os adicionará de fato à sala (Registrando)
            chatRoom.RegisterUser(alice);
            chatRoom.RegisterUser(bob);
            chatRoom.RegisterUser(carlos);
            chatRoom.RegisterUser(diana);

            Console.WriteLine("\n=== Conversação ===");
            // Notem como a chamada ficou muito mais simples a partir 
            // do próprio usuário. O Mediator faz todo o rotrameaneto interno.
            alice.SendMessage("Olá, pessoal! Como funciona o Mediator?");
            bob.SendMessage("Oi, Alice! Ele centraliza tudo!");
            carlos.SendMessage("E aí! Eu falo, ele entrega!");

            Console.WriteLine("\n=== Mensagem Privada ===");
            // Usuários não têm lista interna uns dos outros, quem os entrega ou acha é o mediador:
            alice.SendPrivateMessage(bob, "Bob, você viu a refatoração pronta?");

            Console.WriteLine("\n=== Moderação ===");
            // A moderação também é um comando para o Mediador:
            alice.MuteUser(carlos);
            carlos.SendMessage("Ainda posso falar?"); // Mediator irá bloquear

            Console.WriteLine("\n=== Saindo do Grupo ===");
            // O usuário solicita ao Mediator que quer sair e tudo resolvido internamente:
            diana.LeaveGroup();
            alice.SendMessage("Diana saiu");

            Console.WriteLine("\n=== PROBLEMAS RESOLVIDOS ===");
            Console.WriteLine("✓ Baixo Acoplamento: Usuários não conhecem lista de membros, apenas o mediador (ChatRoom).");
            Console.WriteLine("✓ Comunicação Centralizada: Todo o roteamento de mensagens passa por um único local.");
            Console.WriteLine("✓ Regras centralizadas: Moderação checada em BroadcastMessage em uma única classe.");
            Console.WriteLine("✓ SRP (Responsabilidade Única): ChatMember gasta seu esforço para focar no usuário.");
            Console.WriteLine("✓ Facilmente Extensível: Podem ser criados ChatRooms paralelos diferentes com regras distintas.");
            Console.WriteLine("==================================================\n");
        }
    }
}

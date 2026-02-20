using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // O Mediador Concreto que centraliza e gerencia a comunicação
    public class ChatRoom : IChatMediator
    {
        private readonly List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
                user.SetMediator(this);
                
                // Notifica a todos que um novo usuário entrou (exceto ele mesmo)
                foreach(var u in _users)
                {
                    if (u != user)
                    {
                        u.ReceiveNotification($"{user.Name} entrou no grupo");
                    }
                }
                Console.WriteLine($"[{user.Name}] Entrou no grupo com {_users.Count} membros");
            }
        }

        public void BroadcastMessage(User sender, string message)
        {
            if (sender.IsMuted)
            {
                Console.WriteLine($"[{sender.Name}] ❌ Você está mutado");
                return;
            }

            Console.WriteLine($"[{sender.Name}] Enviou: {message}");

            // Mediador distribui a mensagem, evitando que o usuário conheça os outros
            foreach (var user in _users)
            {
                if (user != sender && !user.IsMuted)
                {
                    user.ReceiveMessage(sender.Name, message);
                }
            }
        }

        public void SendPrivateMessage(User sender, User recipient, string message)
        {
            if (sender.IsMuted)
            {
                Console.WriteLine($"[{sender.Name}] ❌ Você está mutado");
                return;
            }

            if (_users.Contains(recipient))
            {
                Console.WriteLine($"[{sender.Name}] Enviou mensagem privada para {recipient.Name}");
                recipient.ReceivePrivateMessage(sender.Name, message);
            }
        }

        public void MuteUser(User admin, User target)
        {
            // Em uma implementação mais robusta, o mediador pode checar 'admin.IsAdmin'
            if (_users.Contains(target))
            {
                target.IsMuted = true;
                Console.WriteLine($"[{admin.Name}] Mutou {target.Name}");
                
                foreach (var user in _users)
                {
                    if (user != admin && user != target)
                    {
                        user.ReceiveNotification($"{target.Name} foi mutado por {admin.Name}");
                    }
                }
            }
        }

        public void LeaveGroup(User user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
                Console.WriteLine($"[{user.Name}] Saiu do grupo");
                
                foreach (var u in _users)
                {
                    u.ReceiveNotification($"{user.Name} saiu do grupo");
                }
            }
        }
    }
}

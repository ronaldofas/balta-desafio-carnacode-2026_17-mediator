using System;

namespace DesignPatternChallenge
{
    // Classe base (Colleague) que contém a referência ao Mediator
    public abstract class User
    {
        protected IChatMediator _mediator;
        public string Name { get; set; }
        public bool IsMuted { get; set; }

        public User(string name)
        {
            Name = name;
            IsMuted = false;
        }

        // Método para associar o mediador ao usuário
        public void SetMediator(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        // Métodos de envio que delegam a responsabilidade ao Mediador
        public virtual void SendMessage(string message)
        {
            if (_mediator == null)
            {
                Console.WriteLine($"[{Name}] ❌ Não está conectado a nenhuma sala de chat.");
                return;
            }
            _mediator.BroadcastMessage(this, message);
        }

        public virtual void SendPrivateMessage(User recipient, string message)
        {
            if (_mediator == null)
            {
                Console.WriteLine($"[{Name}] ❌ Não está conectado a nenhuma sala de chat.");
                return;
            }
            _mediator.SendPrivateMessage(this, recipient, message);
        }

        public virtual void MuteUser(User target)
        {
            if (_mediator == null)
            {
                Console.WriteLine($"[{Name}] ❌ Não está conectado a nenhuma sala de chat.");
                return;
            }
            _mediator.MuteUser(this, target);
        }

        public virtual void LeaveGroup()
        {
            if (_mediator == null)
            {
                Console.WriteLine($"[{Name}] ❌ Não está conectado a nenhuma sala de chat.");
                return;
            }
            _mediator.LeaveGroup(this);
        }

        // Métodos de recebimento
        public virtual void ReceiveMessage(string senderName, string message)
        {
            Console.WriteLine($"  → [{Name}] Recebeu de {senderName}: {message}");
        }

        public virtual void ReceivePrivateMessage(string senderName, string message)
        {
            Console.WriteLine($"  → [{Name}] 🔒 Mensagem privada de {senderName}: {message}");
        }

        public virtual void ReceiveNotification(string notification)
        {
            Console.WriteLine($"  → [{Name}] ℹ️ {notification}");
        }
    }
}

using Flunt.Notifications;

namespace BancoSimples.Domain.Conta
{
    public abstract class Entity : Notifiable <Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public double Saldo { get; set; }
    }
}

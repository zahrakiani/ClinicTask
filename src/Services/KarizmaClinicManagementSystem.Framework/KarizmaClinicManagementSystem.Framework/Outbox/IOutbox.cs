using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.Outbox;
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
using System;

namespace ENSE483Group3Fall2017.Messaging.Contracts
{
    public class Envelop
    {
        protected Envelop(object payload)
        {
            Id = Guid.NewGuid();
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        public Guid Id { get; }

        public object Payload { get; }

        public string ContentType => Payload.GetType().ToString();
    }

    public class Envelop<T> : Envelop
    {
        public Envelop(T payload)
            : base(payload)
        {
        }

        new public T Payload => (T)base.Payload;
    }
}

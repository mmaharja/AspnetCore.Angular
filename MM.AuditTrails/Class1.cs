using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.AuditTrails
{

    public class UserCreated: UserDomainEvent
    {
        public UserCreated(): base(UserEventMeaning.Created)
        {

        }
    }

    public abstract class UserDomainEvent : DomainEvent<UserEventMeaning>
    {
        public UserDomainEvent()
            : base()
        {

        }

        protected UserDomainEvent(UserEventMeaning meaning)
        {
            this.EventType = meaning;
        }

    }

    public enum UserEventMeaning
    {
        Created
    }

    public abstract class DomainEvent<TEventType> : DomainEvent, IDomainEvent<TEventType>, IDomainEvent where TEventType : struct, IConvertible, IComparable, IFormattable
    {
        public DomainEvent()
        {

        }

        public TEventType EventType { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        //protected static readonly JsonSerializerSettings m_jsonSettings;

        protected DomainEvent()
        {

        }

        public int EventId { get; set; }
        public int? AggregateId { get; set; }
        public Guid? EntityId { get; set; }
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Note { get; set; }
        public byte[] Details { get; set; }

        public  virtual string BuildDetails()
        {
            return "";
        }


        public override string ToString()
        {
            return "";
        }
    }

    public interface IDomainEvent<TEventType> : IDomainEvent where TEventType : struct, IConvertible, IComparable, IFormattable
    {
        TEventType EventType { get; set; }
    }

    public interface IDomainEvent
    {
        int EventId { get; set; }
        int? AggregateId { get; set; }
        Guid? EntityId { get; set; }
        DateTime Timestamp { get; set; }
        int? UserId { get; set; }
        string Username { get; set; }
        string Note { get; set; }
        byte[] Details { set; }

        string BuildDetails();
    }

    //CreateTable(
    //            "User.DomainEvent",
    //            c => new
    //                {
    //                    EventId = c.Int(nullable: false, identity: true),
    //                    EventType = c.Byte(nullable: false),
    //                    AggregateId = c.Int(nullable: false),
    //                    EntityId = c.Guid(),
    //                    Timestamp = c.DateTime(nullable: false),
    //                    UserId = c.Int(nullable: false),
    //                    Note = c.String(),
    //                    Details = c.Binary(),
    //                    Discriminator = c.Byte(nullable: false),
    //                })
    //            .PrimaryKey(t => t.EventId)
    //            .Index(t => t.AggregateId)
    //            .Index(t => t.Timestamp);
}

namespace Bank.Core.Domain.SeedWork
{
  public interface IEntity
  {
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void AddDomainEvent(IDomainEvent domainEvent);

    void ClearEvents();
  }
}
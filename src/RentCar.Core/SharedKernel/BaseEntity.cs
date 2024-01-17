// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Core.SharedKernel;

public abstract class BaseEntity
{
    public Ulid Id { get; set; } = Ulid.NewUlid();

    private readonly List<BaseEvent> _domainEvents = [];

    [NotMapped] public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
        => _domainEvents.Add(domainEvent);


    public void RemoveDomainEvent(BaseEvent domainEvent)
        => _domainEvents.Remove(domainEvent);


    public void ClearDomainEvents()
        => _domainEvents.Clear();
}

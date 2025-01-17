﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReserveSpot.Domain.Shared.Events;
using ReserveSpot.Domain.Models.Spaces;
using ReserveSpot.Domain.Models.Reservations;
using ReserveSpot.Domain.Shared;
using ReserveSpot.Application.Shared.Interfaces;
using ReserveSpot.Infrastructure.Shared.DBContext;

namespace ReserveSpot.Infrastructure.Persistence;
internal sealed class ReserveSpotDbContext : BaseDbContext<ReserveSpotDbContext>//, ICurrentUserService currentUserService) :DbContext
{
    private readonly IDateTime _dateTime;

    public ReserveSpotDbContext(DbContextOptions<ReserveSpotDbContext> options, IDateTime dateTime) : base(options)
    {
        _dateTime = dateTime;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    // private readonly ICurrentUserService _currentUserService= currentUserService;
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<Space> Spaces => Set<Space>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                  //  entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = _dateTime.Now;
                    break;
                case EntityState.Modified:
                  //  entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = _dateTime.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    break;
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
           // await _domainEventService.Publish(@event);
        }
    }
}

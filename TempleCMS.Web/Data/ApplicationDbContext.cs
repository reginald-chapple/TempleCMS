#nullable disable
using TempleCMS.Web.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data.EntityConfigurations;

namespace TempleCMS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
<<<<<<< HEAD
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubMember> ClubMembers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ClubActivity> ClubActivities { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<CommunityService> CommunityServices { get; set; }
        public DbSet<Fundraiser> Fundraisers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
=======
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<Church> Churches { get; set; }
        public DbSet<ChurchMember> ChurchMembers { get; set; }
        public DbSet<Belief> Beliefs { get; set; }
        // public DbSet<Position> Positions { get; set; }
        // public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Value> Values { get; set; }
>>>>>>> parent of 5530561 (massive changes)

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            builder.ApplyConfiguration(new ChatUserConfiguration());
            builder.ApplyConfiguration(new UserNotificationConfiguration());
<<<<<<< HEAD
            builder.ApplyConfiguration(new ClubActivityConfiguration());
            builder.ApplyConfiguration(new ClubMemberConfiguration());
=======
            builder.ApplyConfiguration(new ChurchMemberConfiguration());
            // builder.ApplyConfiguration(new UserPositionConfiguration());
>>>>>>> parent of 5530561 (massive changes)
            builder.ApplyConfiguration(new EventUserConfiguration());
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;

                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }

            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;

                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }
            }
            return await base.SaveChangesAsync(true, cancellationToken);
        }

        public DbSet<TempleCMS.Web.Domain.Event>? Event { get; set; }
    }
}

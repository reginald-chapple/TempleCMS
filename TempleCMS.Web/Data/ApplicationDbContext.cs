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
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<GroupValue> GroupValues { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Fundraiser> Fundraisers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }

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
            builder.ApplyConfiguration(new GroupValueConfiguration());
            builder.ApplyConfiguration(new GroupMemberConfiguration());
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
    }
}

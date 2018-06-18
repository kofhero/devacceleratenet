// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using Ejyle.DevAccelerate.Notifications.Messages;
using Ejyle.DevAccelerate.Notifications.Recipients;
using Ejyle.DevAccelerate.Notifications.Senders;
using Ejyle.DevAccelerate.Notifications.Subjects;
using Ejyle.DevAccelerate.Notifications.Templates;

namespace Ejyle.DevAccelerate.Notifications
{
    public class NotificationsDbContext<TKey, TUserIdKey, TNotificationMessageTemplate, TNotificationSender, TNotificationMessage, TNotificationMessageSubjectParam, TNotificationMessageParam, TNotificationMessageRecipient> : DbContext
        where TNotificationMessage : NotificationMessage<TKey, TUserIdKey, TNotificationMessageParam, TNotificationMessageRecipient, TNotificationMessageSubjectParam>
        where TNotificationMessageParam : NotificationMessageParam<TKey, TNotificationMessage>
        where TNotificationMessageRecipient : NotificationRecipient<TKey, TUserIdKey, TNotificationMessage>
        where TNotificationMessageSubjectParam : NotificationSubjectParam<TKey, TNotificationMessage>
        where TNotificationMessageTemplate : NotificationTemplate<TKey>
        where TNotificationSender : NotificationSender<TKey, TUserIdKey>
    {
        private const string SCHEMA_NAME = "notifications";

        public NotificationsDbContext()
            : base("NotificationsConnection")
        { }

        public void SetConnection(string connectionString)
        {
            this.Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<TNotificationMessageParam> NotificationMessageParams { get; set; }
        public DbSet<TNotificationSender> NotificationSenders { get; set; }
        public DbSet<TNotificationMessage> NotificationMessages { get; set; }
        public DbSet<TNotificationMessageRecipient> NotificationRecipients { get; set; }
        public DbSet<TNotificationMessageSubjectParam> NotificationSubjectParams { get; set; }
        public DbSet<TNotificationMessageTemplate> NotificationTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TNotificationMessage>().ToTable("Messages", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationMessageTemplate>().ToTable("Templates", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationMessageParam>().ToTable("MessageParams", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationMessageRecipient>().ToTable("Recipients", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationMessageSubjectParam>().ToTable("SubjectParams", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationSender>().ToTable("NotificationSenders", SCHEMA_NAME);

            modelBuilder.Entity<TNotificationMessage>()
                .HasMany(e => e.MessageParams)
                .WithRequired(e => e.Message)
                .HasForeignKey(e => e.NotificationMessageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TNotificationMessage>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.Message)
                .HasForeignKey(e => e.NotificationMessageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TNotificationMessage>()
                .HasMany(e => e.SubjectParams)
                .WithRequired(e => e.Message)
                .HasForeignKey(e => e.NotificationMessageId)
                .WillCascadeOnDelete(false);
        }
    }
}

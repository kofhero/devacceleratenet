// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Notifications.Messages;
using Ejyle.DevAccelerate.Notifications.Recipients;
using Ejyle.DevAccelerate.Notifications.Senders;
using Ejyle.DevAccelerate.Notifications.Subjects;
using Ejyle.DevAccelerate.Notifications.Templates;

namespace Ejyle.DevAccelerate.Notifications
{
    public class NotificationsDbContext
        : NotificationsDbContext<int, int?, string, NotificationTemplate, NotificationSender, NotificationMessage, NotificationSubjectParam, NotificationMessageParam, NotificationRecipient>
    {
    }

    public class NotificationsDbContext<TKey, TNullableKey, TUserIdKey, TNotificationTemplate, TNotificationSender, TNotificationMessage, TNotificationSubjectParam, TNotificationMessageParam, TNotificationRecipient> : DbContext
        where TKey : IEquatable<TKey>
        where TNotificationMessage : NotificationMessage<TKey, TUserIdKey, TNotificationMessageParam, TNotificationRecipient, TNotificationSubjectParam>
        where TNotificationMessageParam : NotificationMessageParam<TKey, TUserIdKey, TNotificationMessage>
        where TNotificationRecipient : NotificationRecipient<TKey, TUserIdKey, TNotificationMessage>
        where TNotificationSubjectParam : NotificationSubjectParam<TKey, TNotificationMessage>
        where TNotificationTemplate : NotificationTemplate<TKey, TNullableKey, TUserIdKey, TNotificationSender>
        where TNotificationSender : NotificationSender<TKey, TNullableKey, TUserIdKey, TNotificationTemplate>
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
        public DbSet<TNotificationRecipient> NotificationRecipients { get; set; }
        public DbSet<TNotificationSubjectParam> NotificationSubjectParams { get; set; }
        public DbSet<TNotificationTemplate> NotificationTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TNotificationMessage>().ToTable("Messages", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationTemplate>().ToTable("Templates", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationMessageParam>().ToTable("MessageParams", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationRecipient>().ToTable("Recipients", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationSubjectParam>().ToTable("SubjectParams", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationSender>().ToTable("NotificationSenders", SCHEMA_NAME);

            modelBuilder.Entity<TNotificationSender>()
                .HasMany(e => e.Templates)
                .WithOptional(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

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

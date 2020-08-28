﻿using Microsoft.EntityFrameworkCore;
using SpeakerMeet.Core.Entities;

namespace SpeakerMeet.Infrastructure.Data
{
    public class SpeakerMeetContext : DbContext
    {
        public SpeakerMeetContext(DbContextOptions<SpeakerMeetContext> options) : base(options)
        {
        }

        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Search> Searches { get; set; } = null!;
        public virtual DbSet<Speaker> Speakers { get; set; } = null!;
        public virtual DbSet<Community> Communities { get; set; } = null!;
        public virtual DbSet<Conference> Conferences { get; set; } = null!;
        public virtual DbSet<SpeakerTag> SpeakerTags { get; set; } = null!;
        public virtual DbSet<SocialPlatform> SocialPlatforms { get; set; } = null!;
        public virtual DbSet<SpeakerSocialPlatform> SpeakerSocialPlatforms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Search>(x =>
            {
                x.HasNoKey();
                x.ToView("Search");
            });

            modelBuilder.Entity<SpeakerTag>()
                .HasOne(x => x.Speaker)
                .WithMany(x => x.SpeakerTags)
                .HasForeignKey(x => x.SpeakerId);

            modelBuilder.Entity<SpeakerTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.SpeakerTags)
                .HasForeignKey(x => x.TagId);

            modelBuilder.Entity<SpeakerSocialPlatform>()
                .HasOne(x => x.Speaker)
                .WithMany(x => x.SpeakerSocialPlatforms)
                .HasForeignKey(x => x.SpeakerId);

            modelBuilder.Entity<SpeakerSocialPlatform>()
                .HasOne(x => x.SocialPlatform)
                .WithMany(x => x.SpeakerSocialPlatforms)
                .HasForeignKey(x => x.SocialPlatformId);
        }
    }
}
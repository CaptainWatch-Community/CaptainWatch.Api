﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.EntityFramework.Objects;

public partial class CaptainWatchContext : DbContext
{
    public CaptainWatchContext(DbContextOptions<CaptainWatchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movie { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Movies");

            entity.HasIndex(e => new { e.BelongsToCollection, e.Id }, "CL_Movie_Collection");

            entity.HasIndex(e => e.ImdbId, "CL_Movie_Imdb");

            entity.HasIndex(e => new { e.ImdbRating, e.Time }, "CL_Movie_ImdbTime");

            entity.HasIndex(e => new { e.Popularity, e.MinReleaseDate }, "CL_Movie_PopularityRelease");

            entity.HasIndex(e => e.ReleaseDate, "CL_Movie_ReleaseDate");

            entity.HasIndex(e => e.ReleaseDateFr, "CL_Movie_Release_fr");

            entity.HasIndex(e => new { e.SiteVoteCount, e.SiteVoteAverage, e.Time }, "_dta_index_Movie_5_1140199112__K24D_K23_K29_1").IsDescending(true, false, false);

            entity.HasIndex(e => e.Id, "_dta_index_Movie_5_1677249030__K1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BackdropPath)
                .HasMaxLength(255)
                .HasColumnName("backdrop_path");
            entity.Property(e => e.BelongsToCollection).HasColumnName("belongs_to_collection");
            entity.Property(e => e.BlogUrl)
                .HasMaxLength(2048)
                .HasColumnName("blog_url");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.Certification)
                .HasMaxLength(50)
                .HasColumnName("certification");
            entity.Property(e => e.CertificationFr)
                .HasMaxLength(50)
                .HasColumnName("certification_fr");
            entity.Property(e => e.CncLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("cnc_last_update");
            entity.Property(e => e.CollectionPosition).HasColumnName("collection_position");
            entity.Property(e => e.ComingSoonRating).HasColumnName("coming_soon_rating");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DominantColorB).HasColumnName("dominant_color_b");
            entity.Property(e => e.DominantColorG).HasColumnName("dominant_color_g");
            entity.Property(e => e.DominantColorR).HasColumnName("dominant_color_r");
            entity.Property(e => e.DominantOriginalColorB).HasColumnName("dominant_original_color_b");
            entity.Property(e => e.DominantOriginalColorG).HasColumnName("dominant_original_color_g");
            entity.Property(e => e.DominantOriginalColorR).HasColumnName("dominant_original_color_r");
            entity.Property(e => e.FRated).HasColumnName("f_rated");
            entity.Property(e => e.ImdbAnime).HasColumnName("imdb_anime");
            entity.Property(e => e.ImdbCertificate)
                .HasMaxLength(200)
                .HasColumnName("imdb_certificate");
            entity.Property(e => e.ImdbCertificateFr)
                .HasMaxLength(200)
                .HasColumnName("imdb_certificate_fr");
            entity.Property(e => e.ImdbId)
                .HasMaxLength(50)
                .HasColumnName("imdb_id");
            entity.Property(e => e.ImdbLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("imdb_last_update");
            entity.Property(e => e.ImdbNumVotes).HasColumnName("imdb_num_votes");
            entity.Property(e => e.ImdbRating).HasColumnName("imdb_rating");
            entity.Property(e => e.IsFrench)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isFrench");
            entity.Property(e => e.ItunesLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("itunes_last_update");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.MainTrailer)
                .HasMaxLength(50)
                .HasColumnName("main_trailer");
            entity.Property(e => e.MinReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("min_release_date");
            entity.Property(e => e.NetflixAvailability).HasColumnName("netflix_availability");
            entity.Property(e => e.NetflixAvailabilityDate)
                .HasColumnType("datetime")
                .HasColumnName("netflix_availability_date");
            entity.Property(e => e.NetflixId)
                .HasMaxLength(50)
                .HasColumnName("netflix_id");
            entity.Property(e => e.OriginalTitle)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("original_title");
            entity.Property(e => e.Overview)
                .HasColumnType("text")
                .HasColumnName("overview");
            entity.Property(e => e.OverviewFr)
                .HasColumnType("text")
                .HasColumnName("overview_fr");
            entity.Property(e => e.Popularity).HasColumnName("popularity");
            entity.Property(e => e.PosterPath)
                .HasMaxLength(255)
                .HasColumnName("poster_path");
            entity.Property(e => e.PosterPathFr)
                .HasMaxLength(255)
                .HasColumnName("poster_path_fr");
            entity.Property(e => e.RealOriginalTitle)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("real_original_title");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.ReleaseDateFr)
                .HasColumnType("datetime")
                .HasColumnName("release_date_fr");
            entity.Property(e => e.Revenue).HasColumnName("revenue");
            entity.Property(e => e.SiteScore).HasColumnName("site_score");
            entity.Property(e => e.SiteScoreFuture).HasColumnName("site_score_future");
            entity.Property(e => e.SiteScorePast).HasColumnName("site_score_past");
            entity.Property(e => e.SiteScorePresent).HasColumnName("site_score_present");
            entity.Property(e => e.SiteVoteAverage).HasColumnName("site_vote_average");
            entity.Property(e => e.SiteVoteCount).HasColumnName("site_vote_count");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Tagline)
                .HasMaxLength(2000)
                .HasColumnName("tagline");
            entity.Property(e => e.TaglineFr)
                .HasMaxLength(1000)
                .HasColumnName("tagline_fr");
            entity.Property(e => e.TheaterCountFr).HasColumnName("theater_count_fr");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.TripleFRated).HasColumnName("triple_f_rated");
            entity.Property(e => e.Video).HasColumnName("video");
            entity.Property(e => e.VoteAverage).HasColumnName("vote_average");
            entity.Property(e => e.VoteCount).HasColumnName("vote_count");
            entity.Property(e => e.WatchlistCount).HasColumnName("watchlist_count");
            entity.Property(e => e.Wplay).HasColumnName("wplay");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
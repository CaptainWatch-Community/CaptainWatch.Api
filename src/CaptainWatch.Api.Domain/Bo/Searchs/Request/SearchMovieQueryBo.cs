﻿namespace CaptainWatch.Api.Domain.Bo.Searchs.Request
{
    public class SearchMovieQueryBo
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; }
    }
}

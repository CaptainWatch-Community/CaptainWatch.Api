﻿namespace CaptainWatch.Api.Domain.Bo.Searchs.Request
{
    public class SearchUserAddOrUpdateBo
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Pseudo { get; set; } = string.Empty;
    }
}

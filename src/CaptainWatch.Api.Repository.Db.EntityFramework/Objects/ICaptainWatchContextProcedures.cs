﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CaptainWatch.Api.Repository.Db.EntityFramework.Objects
{
    public partial interface ICaptainWatchContextProcedures
    {
        Task<int> DeleteMovieAsync(int? id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteTVAsync(int? id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}

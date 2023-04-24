﻿using AutoMapper;
using MediaLibrary.Server.Data;

namespace MediaLibrary.Server.Services
{
    public partial class MovieService : BaseService<Movie, Shared.Models.MovieModel>
    {
        public MovieService(MediaLibraryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

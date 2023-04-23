﻿using AutoMapper;
using MediaLibrary.Server.Data;

namespace MediaLibrary.Server.Services
{
    public class MovieService : BaseService<Movie, Shared.Models.MovieModel>
    {
        public MovieService(MediaLibraryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

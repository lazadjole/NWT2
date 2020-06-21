﻿using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class TipVozilaService : ITipVozilaService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public TipVozilaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipVozila>> GetTipVozilaAsync(CancellationToken ct)
        {
            var tipVozila = await _dbContext.TipVozila.ToArrayAsync();
            if (tipVozila == null) return null;

            return _mapper.Map<IEnumerable<Entities.TipVozila>, IEnumerable<Models.TipVozila>>(tipVozila);
        }

        public async Task<TipVozila> GetTipVozilaByIdAsync(Guid id, CancellationToken ct)
        {
            var tipVozila = await _dbContext.TipVozila.FirstOrDefaultAsync(x => x.TipVozilaID == id);
            if (tipVozila == null) return null;

            return _mapper.Map<Entities.TipVozila, Models.TipVozila>(tipVozila);

        }
    }
}
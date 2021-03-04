using LIBs.Domain;
using LIBs.Infra.Context;
using LIBs.Repository.IRepositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIBs.Repository
{
    public class RepositoryVenda : RepositoryBase<Venda>, IRepositoryVenda
    {
        private readonly ProjetoContext _context;
        public RepositoryVenda(ProjetoContext context) : base(context)
        {
            _context = context;

        }       
    }
}

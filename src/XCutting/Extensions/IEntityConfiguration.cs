using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCutting.ModelBuilderExtensions
{
    public interface IEntityConfiguration<TContext>
    {
        void Configure();
    }
}

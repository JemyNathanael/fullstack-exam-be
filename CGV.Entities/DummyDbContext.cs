using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CGV.Entities;

public partial class DummyDbContext : DbContext
{
    public DummyDbContext()
    {
    }

    public DummyDbContext(DbContextOptions<DummyDbContext> options)
        : base(options)
    {
    }
}

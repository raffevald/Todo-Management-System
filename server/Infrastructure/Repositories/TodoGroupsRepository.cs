using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories {
    public class TodoGroupsRepository : Repository<TodoGroup>, ITodoGroupsRepository {
        public TodoGroupsRepository ( ApplicationDbContext applicationDbContext ) : base ( applicationDbContext ) { }

        public Task<TodoGroup> GetDuplicate ( TodoGroup model ) {
            return _applicationDbContext
                .TodoGroups
                .FirstOrDefaultAsync ( 
                    i => i.GroupName.Equals ( model.GroupName, StringComparison.CurrentCultureIgnoreCase ) 
                 );
        }
    }
}

﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Users.Models;
using Microsoft.AspNet.Identity;

namespace Users.Infrastructure {
    public class AppIdentityDbContext : IdentityDbContext<AppUser> {

        public AppIdentityDbContext() : base("IdentityDb") { }

        static AppIdentityDbContext() {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create() {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext> {
    }
}

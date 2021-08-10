using ECommerce.Core.DataAccess.Auth;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.Models.GrantType;

namespace ECommerce.Infrastructure.API
{
    public static class Seed
    {
        internal static async Task SeedIdentityRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = "user" });
                await roleManager.CreateAsync(new Role { Name = "admin" });
            }
        }
        internal static async Task SeedIdentityUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "anton179",
                    Email = "anichitenco@gmail.com",
                    EmailConfirmed = true,
                    IsActive = true
                };

                var result = await userManager.CreateAsync(user, "12345test");
                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                    await userManager.AddToRoleAsync(user, "admin");
                }
            }
        }

        internal static async Task SeedIdentityServer(ConfigurationDbContext configurationDbContext,
            PersistedGrantDbContext persistedGrantDbContext)
        {
            configurationDbContext.Database.Migrate();
            persistedGrantDbContext.Database.Migrate();

            if (!configurationDbContext.Clients.Any())
            {
                await SeedClients(configurationDbContext);
            }

            if (!configurationDbContext.ApiScopes.Any())
            {
                await SeedScopes(configurationDbContext);
            }

            if (!configurationDbContext.ApiResources.Any())
            {
                await SeedApiResources(configurationDbContext);
            }

            await configurationDbContext.SaveChangesAsync();
        }

        internal static async Task SeedScopes(ConfigurationDbContext configurationDbContext)
        {
            await configurationDbContext.ApiScopes.AddRangeAsync(new List<ApiScope>
            {
                new ApiScope
                {
                    Name = "app.expensetracker.api.read"
                },
                new ApiScope
                {
                    Name = "app.expensetracker.api.write"
                },
                new ApiScope
                {
                    Name = "app.expensetracker.api.full"
                },
                new ApiScope
                {
                    Name = "app.expensetracker.api.swagger"
                },
                new ApiScope
                {
                    Name = "openid"
                },
                new ApiScope
                {
                    Name = "offline_access"
                },
                new ApiScope
                {
                    Name = "profile"
                },
            });
        }

        internal static async Task SeedClients(ConfigurationDbContext configurationDbContext)
        {
            await configurationDbContext.Clients.AddRangeAsync(new List<Client>
            {
                new Client
                {
                    ClientId = "t8agr5xKt4$3sad31oj$d",
                    ClientName = "Expense Tracker Web Api",
                    AllowedGrantTypes = new List<ClientGrantType>
                    {
                        new ClientGrantType
                        {
                            GrantType = ResourceOwnerPassword
                        },
                        new ClientGrantType
                        {
                            GrantType = ClientCredentials
                        }
                    },
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret
                        {
                            Value = "234edf$43-fs$a4asdf-423qwadsaes$f-34$5f$-web-api".ToSha256()
                        }
                    },
                    RequireClientSecret = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.full"
                        },

                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.read"
                        },

                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.write"
                        },

                        new ClientScope
                        {
                            Scope = "openid"
                        },

                        new ClientScope
                        {
                            Scope = "offline_access"
                        },

                        new ClientScope
                        {
                            Scope = "profile"
                        }
                    }
                },

                new Client
                {
                    ClientId = "t8agr5xKt4$3",
                    ClientName = "Expense Tracker Swagger",
                    AllowedGrantTypes = new List<ClientGrantType>
                    {
                        new ClientGrantType
                        {
                            GrantType = ClientCredentials
                        }
                    },
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret
                        {
                            Value = "234edf$43-fs$a34asdf-423qwadsaes$f-34$5f$-swagger".ToSha256()
                        }
                    },
                    RequireClientSecret = true,
                    AllowedScopes = new List<ClientScope>
                    {
                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.full"
                        },

                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.read"
                        },

                        new ClientScope
                        {
                            Scope = "app.expensetracker.api.write"
                        },
                    }
                }
            });
        }

        internal static async Task SeedApiResources(ConfigurationDbContext configurationDbContext)
        {
            await configurationDbContext.ApiResources.AddAsync(
                new ApiResource
                {
                    Name = "app.expensetracker.api",
                    DisplayName = "Expense Tracker Api",
                    Secrets = new List<ApiResourceSecret>
                    {
                        new ApiResourceSecret()
                        {
                            Value = "a75a559d-1dab-4c65-9bc0-f8e590cb388d-expense-tracker-api".ToSha256()
                        }
                    },
                    Scopes = new List<ApiResourceScope>
                    {
                        new ApiResourceScope
                        {
                            Scope = "profile"
                        },
                        new ApiResourceScope
                        {
                            Scope = "app.expensetracker.api.read"
                        },
                        new ApiResourceScope
                        {
                            Scope = "app.expensetracker.api.write"
                        },
                        new ApiResourceScope
                        {
                            Scope = "app.expensetracker.api.full"
                        },
                        new ApiResourceScope
                        {
                            Scope = "app.expensetracker.api.swagger"
                        },
                        new ApiResourceScope
                        {
                            Scope = "openid"
                        },
                        new ApiResourceScope
                        {
                            Scope = "offline_access"
                        }
                    }
                });
        }
    }
}

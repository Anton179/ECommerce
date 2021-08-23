using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Enums;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Entities.Characteristics;
using ApiResource = IdentityServer4.EntityFramework.Entities.ApiResource;
using ApiScope = IdentityServer4.EntityFramework.Entities.ApiScope;
using Client = IdentityServer4.EntityFramework.Entities.Client;
using IdentityResource = IdentityServer4.EntityFramework.Entities.IdentityResource;

namespace ECommerce.Core.DataAccess
{
    public class Seed
    {
        public static async Task SeedIdentityRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Id = Guid.NewGuid(), Name = "user" });
                await roleManager.CreateAsync(new Role { Id = Guid.NewGuid(), Name = "vendor" });
                await roleManager.CreateAsync(new Role { Id = Guid.NewGuid(), Name = "admin" });
            }
        }
        public static async Task SeedIdentityUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                {
                    var user = new User
                    {
                        Id = new Guid("7D55490E-E76D-4713-BBF3-B3EC8912A8D7"),
                        UserName = "Anton179",
                        Email = "anichitenco@gmail.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "12345test");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "admin");
                    }
                }
                {
                    var user = new User
                    {
                        Id = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                        UserName = "Alex123",
                        Email = "alex123@gmail.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "12345test");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "vendor");
                    }
                }
                {
                    var user = new User
                    {
                        Id = new Guid("DE0821F1-6819-49E8-A823-B4B1A19BAEAD"),
                        UserName = "Jenea228",
                        Email = "jenea228@gmail.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "12345test");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "user");
                    }
                }

            }
        }

        public static async Task SeedIdentityServer(ConfigurationDbContext configurationDbContext)
        {
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

        private static async Task SeedScopes(ConfigurationDbContext configurationDbContext)
        {
            await configurationDbContext.ApiScopes.AddRangeAsync(new List<ApiScope>
            {
                new ApiScope
                {
                    Name = "read"
                },
                new ApiScope
                {
                    Name = "write"
                },
                new ApiScope
                {
                    Name = "full"
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

        private static async Task SeedClients(ConfigurationDbContext configurationDbContext)
        {
            var client = new Client
            {
                ClientId = "6A491EB6-99A7-4277-9884-72904DF2BA9A",
                ClientName = "eSearch Angular Client",
                ClientUri = "http://localhost:4200",
                AllowedGrantTypes = new List<ClientGrantType>
                {
                    new ClientGrantType
                    {
                        GrantType = GrantType.AuthorizationCode
                    }
                },
                RequirePkce = true,
                AllowOfflineAccess = true,
                ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret
                    {
                        Value = "6FF4EC10-TCDProject-ACDD-Angular-4BFD-Client-8532-351C6D056462".ToSha256()
                    }
                },
                RequireClientSecret = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<ClientScope>
                {
                    new ClientScope
                    {
                        Scope = "full"
                    },

                    new ClientScope
                    {
                        Scope = "read"
                    },

                    new ClientScope
                    {
                        Scope = "write"
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
            };

            client.RedirectUris = new()
            {
                new ClientRedirectUri
                {
                    RedirectUri = "http://localhost:4200/home",
                    Client = client
                },
                new ClientRedirectUri
                {
                    RedirectUri = "http://localhost:4200/signin-callback",
                    Client = client
                }
            };

            client.PostLogoutRedirectUris = new()
            {
                new ClientPostLogoutRedirectUri { PostLogoutRedirectUri = "http://localhost:4200/signout-callback", Client = client }
            };



            await configurationDbContext.Clients.AddAsync(client);

            await configurationDbContext.ClientCorsOrigins.AddAsync(new ClientCorsOrigin
            {
                Client = client,
                Origin = "http://localhost:4200"
            });
        }

        private static async Task SeedApiResources(ConfigurationDbContext configurationDbContext)
        {
            await configurationDbContext.ApiResources.AddAsync(
                new ApiResource
                {
                    Name = "ECommerce.Web.API",
                    DisplayName = "eSearch API",
                    Secrets = new List<ApiResourceSecret>
                    {
                        new ApiResourceSecret()
                        {
                            Value = "A1837CD3-TCDProject-5340-API-4B40-Resource-BE7C-55E5B5C9FAAB".ToSha256()
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
                            Scope = "read"
                        },
                        new ApiResourceScope
                        {
                            Scope = "write"
                        },
                        new ApiResourceScope
                        {
                            Scope = "full"
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

        private async Task SeedIdentityResources(ConfigurationDbContext configurationDbContext)
        {
            var resources = new IdentityResource[]
            {
                new IdentityResource
                {
                    Name = "profile",
                    UserClaims = new List<IdentityResourceClaim>
                    {
                        new IdentityResourceClaim
                        {
                            Type = "name"
                        },
                        new IdentityResourceClaim
                        {
                            Type = "email"
                        },
                        new IdentityResourceClaim
                        {
                            Type = "website"
                        }
                    },
                    DisplayName = "Your profile data"
                },
                new IdentityResource()
                {
                    Name = "openid",
                    UserClaims = new List<IdentityResourceClaim>
                    {
                        new IdentityResourceClaim
                        {
                            Type = "sub"
                        }
                    },
                    DisplayName = "Your user identifier"
                }
            };

            await configurationDbContext.IdentityResources.AddRangeAsync(resources);
        }

        public static async Task SeedApiServer(ECommerceDbContext eCommerceDbContext)
        {
            if (!eCommerceDbContext.Products.Any())
            {
                await SeedResources(eCommerceDbContext);
            }

            await eCommerceDbContext.SaveChangesAsync();
        }

        private static async Task SeedResources(ECommerceDbContext eCommerceDbContext)
        {
            var categories = new List<Category>();

            {
                var electronics = new Category()
                {
                    Name = "Electronics",
                };
                var phones = new Category()
                {
                    Name = "Phones",
                    Parent = electronics
                };
                var mobilePhones = new Category()
                {
                    Name = "Mobile phones",
                    Parent = phones
                };
                var homePhones = new Category()
                {
                    Name = "Home phones",
                    Parent = phones
                };

                categories.AddRange(new List<Category>() {electronics, phones, mobilePhones, homePhones});
            }

            

            var mobilePhonesCat = categories.SingleOrDefault(c => c.Name == "Mobile phones");

            var products = new List<Product>()
            {
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi note 10",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 10 pro",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone 12",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone 11",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone X",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 10",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 11",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 11 ultra",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi redmi note 9 pro",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    CreatedAt = DateTime.Today,
                    ImageUrl = "assets/img/Products/Smartphone.png",
                },
            };

            var characteristics = new List<Characteristic>()
            {
                new CharacteristicNumberType()
                {
                    Name = "Selfie camera",
                    ValueNum = 16,
                    Category = categories.SingleOrDefault(c => c.Name == "Mobile phones"),
                    Product = products.SingleOrDefault(c => c.Name == "Xiaomi mi note 10")
                },
                new CharacteristicStringType()
                {
                    Name = "Display",
                    ValueStr = "AMOLED",
                    Category = categories.SingleOrDefault(c => c.Name == "Mobile phones"),
                    Product = products.SingleOrDefault(c => c.Name == "Xiaomi mi note 10")
                }
            };

            await eCommerceDbContext.AddRangeAsync(characteristics);
            await eCommerceDbContext.AddRangeAsync(categories);
            await eCommerceDbContext.AddRangeAsync(products);
        }
    }
}

using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
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
                await roleManager.CreateAsync(new Role { Id = Guid.NewGuid(), Name = "operator" });
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
                        UserName = "Admin",
                        Email = "admin@gmail.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "admin123");
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
                        UserName = "Operator",
                        Email = "operator@gmail.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "operator123");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "operator");
                    }
                }
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
                        await userManager.AddToRoleAsync(user, "user");
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
                        Id = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                        UserName = "Microsoft",
                        Email = "Microsoft@gmail.com",
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
                        Id = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                        UserName = "Sony",
                        Email = "Sony@gmail.com",
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
                new ApiScope
                {
                    Name = "roles"
                }
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
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowedScopes = new List<ClientScope>
                {
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
                    },
                    new ClientScope
                    {
                        Scope = "roles"
                    }
                }
            };

            client.RedirectUris = new List<ClientRedirectUri>()
            {
                new ClientRedirectUri
                {
                    RedirectUri = "http://localhost:4200/home",
                    Client = client
                },
                new ClientRedirectUri
                {
                    RedirectUri = "http://localhost:4200/auth/signin-callback",
                    Client = client
                }
            };

            client.PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>()
            {
                new ClientPostLogoutRedirectUri { PostLogoutRedirectUri = "http://localhost:4200/auth/signout-callback", Client = client }
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
                    UserClaims = new List<ApiResourceClaim>()
                    {
                        new ApiResourceClaim()
                        {
                            Type = "sub"
                        },
                        new ApiResourceClaim()
                        {
                            Type = "userName"
                        },
                        new ApiResourceClaim()
                        {
                            Type = "email"
                        },
                        new ApiResourceClaim()
                        {
                            Type = JwtClaimTypes.Role
                        }
                    },
                    Scopes = new List<ApiResourceScope>
                    {
                        new ApiResourceScope
                        {
                            Scope = "roles"
                        },
                        new ApiResourceScope
                        {
                            Scope = "profile"
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
                },
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    UserClaims = new List<IdentityResourceClaim>
                    {
                        new IdentityResourceClaim()
                        {
                            Type = JwtClaimTypes.Role
                        }
                    }
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

            try
            {
                await eCommerceDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private static async Task SeedResources(ECommerceDbContext eCommerceDbContext)
        {
            var shippings = new List<ShippingMethod>()
            {
                new ShippingMethod()
                {
                    Name = "Nova Poshta",
                    Price = 25,
                    Estimated = "7-14 days",
                    Image = "assets/img/Delivery/novaposhta.png"
                },
                new ShippingMethod()
                {
                    Name = "DHL Express",
                    Price = 40,
                    Estimated = "4-8 days",
                    Image = "assets/img/Delivery/DHL.png"
                }
            };

            var categories = new List<Category>();

            {
                var musicalInstruments = new Category()
                {
                    Name = "Musical Instruments",
                    Image = "assets/img/Categories/MusicalInstruments.png"
                };
                var clothes = new Category()
                {
                    Name = "Clothes",
                    Image = "assets/img/Categories/Clothes.png"
                };
                var fishing = new Category()
                {
                    Name = "Fishing",
                    Image = "assets/img/Categories/Fishing.png"
                };
                var autoAccessories = new Category()
                {
                    Name = "Auto Accessories",
                    Image = "assets/img/Categories/AutoAccessories.png"
                };
                var homeAndGarden = new Category()
                {
                    Name = "Home and Garden",
                    Image = "assets/img/Categories/Home&Garden.png"
                };
                var sports = new Category()
                {
                    Name = "Sports",
                    Image = "assets/img/Categories/Sports.png"
                };
                var electronics = new Category()
                {
                    Name = "Electronics",
                    Image = "assets/img/Categories/Electronics.png"
                };

                var phones = new Category()
                {
                    Name = "Phones",
                    Parent = electronics
                };
                var mobilePhones = new Category()
                {
                    Name = "Mobile Phones",
                    Parent = phones
                };
                var homePhones = new Category()
                {
                    Name = "Home Phones",
                    Parent = phones
                };
                var computersTablets = new Category()
                {
                    Name = "Computers and Tablets",
                    Parent = electronics
                };
                var hardware = new Category()
                {
                    Name = "Hardware",
                    Parent = electronics
                };
                var consoles = new Category()
                {
                    Name = "Consoles",
                    Parent = electronics
                };
                var accessories = new Category()
                {
                    Name = "Accessories",
                    Parent = consoles
                };
                var videoGames = new Category()
                {
                    Name = "Video Games",
                    Parent = consoles
                };

                var women = new Category()
                {
                    Name = "Women's Clothing",
                    Parent = clothes
                };
                var men = new Category()
                {
                    Name = "Men's Clothing",
                    Parent = clothes
                };
                var menJeans = new Category()
                {
                    Name = "Men's Jeans",
                    Parent = men
                };
                var womenJeans = new Category()
                {
                    Name = "Women's Jeans",
                    Parent = women
                };

                categories.AddRange(new List<Category>()
                {
                    musicalInstruments, clothes, fishing, autoAccessories, homeAndGarden, sports, electronics, phones, mobilePhones, homePhones,
                    computersTablets, hardware, videoGames, women, men, menJeans, womenJeans, consoles, accessories
                });
            }



            var mobilePhonesCat = categories.FirstOrDefault(c => c.Name == "Mobile Phones");
            var consolesCat = categories.FirstOrDefault(x => x.Name == "Consoles");
            var accessoriesCat = categories.FirstOrDefault(x => x.Name == "Accessories");
            var computersCat = categories.FirstOrDefault(x => x.Name == "Computers and Tablets");

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
                    ImageUrl = "assets/img/Products/XiaomiMiNote10.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 10 pro",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/XiaomiMi10Pro.png",
                    InStock = false
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone 12",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/iPhone12.png",
                    InStock = false
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone 11",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/iPhone11.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "iPhone X",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/iPhoneX.png",
                    InStock = false
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 10",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/XiaomiMi10.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 11",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/XiaomiMi11.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi mi 11 ultra",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/XiaomiMi11Ultra.png",
                },
                new Product()
                {
                    OwnerId = new Guid("7D2F4A75-B474-4FC4-B46D-F9545A971FA0"),
                    Name = "Xiaomi redmi note 9 pro",
                    Description = "New xiaomi mi note 10 smartphone",
                    Category = mobilePhonesCat,
                    Price = 450,
                    Weight = 1.2,
                    ImageUrl = "assets/img/Products/XiaomiRedmiNote9Pro.png",
                },

                // ----------------------------------
                
                new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "Play Station 4 pro",
                    Description = "The most advanced PlayStation system ever. PS4 Pro is designed to take your favorite PS4 games and add to them with more power for graphics, performance, or features for your 4K HDR TV, or 1080p HD TV.",
                    Category = consolesCat,
                    Price = 348,
                    Weight = 4.8,
                    ImageUrl = "assets/img/Products/PS4Pro.png",
                },
                new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "Play Station 4",
                    Description = "Enables the greatest game developers in the world to unlock their creativity and push the boundaries of play through a platform that is tuned specifically to their needs. Engage in endless personal challenges between you and your community, and share your epic moments for the world to see.",
                    Category = consolesCat,
                    Price = 270,
                    Weight = 4.1,
                    ImageUrl = "assets/img/Products/PS4.png",
                },
                new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "Play Station 4 Slim",
                    Description = "PlayStation 4 is the best place to play with dynamic, connected gaming, powerful graphics and speed, intelligent personalization, deeply integrated social capabilities, and innovative second-screen features.",
                    Category = consolesCat,
                    Price = 240,
                    Weight = 3.2,
                    ImageUrl = "assets/img/Products/PS4Slim.png",
                },

                new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Series S",
                    Description = "The next generation of gaming brings our largest digital launch library yet to our smallest Xbox ever. With more dynamic worlds, faster load times, and the addition of Xbox Game Pass (sold separately), the all-digital Xbox Series S is the best value in gaming.",
                    Category = consolesCat,
                    Price = 497,
                    Weight = 4.05,
                    ImageUrl = "assets/img/Products/XboxSeriesS.png",
                },
                new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Series X",
                    Description = "Introducing Xbox Series X, the fastest, most powerful Xbox ever. Play thousands of titles from four generations of consoles-all games look and play best on Xbox Series X.",
                    Category = consolesCat,
                    Price = 580,
                    Weight = 5.8,
                    ImageUrl = "assets/img/Products/XboxSeriesX.png",
                },
                new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox 360",
                    Description = "The Official Xbox 360 500GB Hard Drive For Slim Console is the best option for media enthusiasts who game on Xbox 360. Expand your Xbox 360 experience with downloadable content. ",
                    Category = consolesCat,
                    Price = 71,
                    Weight = 3.2,
                    ImageUrl = "assets/img/Products/Xbox360.png",
                },
                new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox One S",
                    Description = "Play over 100 console exclusives and a growing library of Xbox 360 games on the Xbox One S. Stream your favorite films and shows in stunning 4K Ultra HD.",
                    Category = consolesCat,
                    Price = 300,
                    Weight = 2.72,
                    ImageUrl = "assets/img/Products/XboxOneS.png",
                },

            };

            var characteristics = new List<Characteristic>()
            {
                new Characteristic()
                {
                    Name = "Audio",
                    Category = accessoriesCat,
                },
                new Characteristic()
                {
                    Name = "System requirements",
                    Category = accessoriesCat,
                },
                new Characteristic()
                {
                    Name = "Battery",
                    Category = accessoriesCat,
                },
                new Characteristic()
                {
                    Name = "Selfie camera",
                    Category = mobilePhonesCat
                },
                new Characteristic()
                {
                    Name = "Display",
                    Category = mobilePhonesCat
                },
                new Characteristic()
                {
                    Name = "Released",
                    Category = categories.FirstOrDefault(c => c.Name == "Electronics")
                },

                new Characteristic()
                {
                    Name = "Memory",
                    Category = consolesCat
                },
                new Characteristic()
                {
                    Name = "Storage size",
                    Category = consolesCat
                },

                new Characteristic()
                {
                    Name = "Operating System",
                    Category = computersCat
                },
                new Characteristic()
                {
                    Name = "Screen Size",
                    Category = computersCat
                },
                new Characteristic()
                {
                    Name = "Specific Uses For Product",
                    Category = computersCat
                },
                new Characteristic()
                {
                    Name = "Series",
                    Category = computersCat
                },
            };

            var characteristicsValues = new List<CharacteristicValue>()
            {
                
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "8GB DDR3",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox One S")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "2048GB",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox One S")
                },
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "10GB GDDR6",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox Series S")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "512GB",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox Series S")
                },
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "16 GB GDDR6",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox Series X")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "1024GB",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox Series X")
                },
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "GDDR5 8GB",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox 360")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "512GB",
                    Product = products.FirstOrDefault(c => c.Name == "Xbox 360")
                },
                // ----------------------------------
                
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "GDDR5 8GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4 pro")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "1024GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4 pro")
                },
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "GDDR5 8GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "1024GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4")
                },
                // ----------------------------------
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Memory"),
                    ValueStr = "GDDR5 8GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4 Slim")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Storage size"),
                    ValueStr = "512GB",
                    Product = products.FirstOrDefault(c => c.Name == "Play Station 4 Slim")
                },
                // ----------------------------------

                new CharacteristicDecimalType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Selfie camera"),
                    ValueDec = 16,
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi note 10")
                },
                new CharacteristicDateType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Released"),
                    ValueDate = new DateTime(2021, 3, 21),
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi note 10")
                },
                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi note 10")
                },

                // ----------------------------------

                new CharacteristicDecimalType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Selfie camera"),
                    ValueDec = 16,
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 10 pro")
                },
                new CharacteristicDateType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Released"),
                    ValueDate = new DateTime(2019, 11, 6),
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 10 pro")
                },
                
                // ----------------------------------

                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "iPhone 12")
                },
                new CharacteristicDateType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Released"),
                    ValueDate = new DateTime(2020, 10, 13),
                    Product = products.FirstOrDefault(c => c.Name == "iPhone 12")
                },
                
                // ----------------------------------

                new CharacteristicDecimalType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Selfie camera"),
                    ValueDec = 16,
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 10")
                },
                new CharacteristicDateType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Released"),
                    ValueDate = new DateTime(2020, 2, 14),
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 10")
                },
                
                // ----------------------------------

                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "iPhone X")
                },
                
                // ----------------------------------

                new CharacteristicDecimalType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Selfie camera"),
                    ValueDec = 16,
                    Product = products.FirstOrDefault(c => c.Name == "iPhone 11")
                },
                
                // ----------------------------------

                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 11")
                },
                
                // ----------------------------------

                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi mi 11 ultra")
                },
                
                // ----------------------------------

                new CharacteristicStringType()
                {
                    Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Display"),
                    ValueStr = "AMOLED",
                    Product = products.FirstOrDefault(c => c.Name == "Xiaomi redmi note 9 pro")
                }
            };

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Elite Wireless Controller Series 2 - Halo Infinite Limited Edition",
                    Description =
                        "Step inside the armor of humanity’s greatest hero with the Xbox Elite Wireless Controller Series 2 – Halo Infinite Limited Edition featuring over 30 new ways to play like a pro. Fire with Spartan-like speed using the Hair Trigger Locks with three discrete settings. Enhance your aiming with new adjustable-tension thumbsticks and stay on target with a wrap-around rubberized diamond grip.",
                    Category = accessoriesCat,
                    Price = 200,
                    Weight = 0.345,
                    ImageUrl = "assets/img/Products/XboxEliteWirelessControllerSeries2.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 40 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Xbox, Windows 7, Windows 10"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Wireless Controller – Forza Horizon 5 Limited Edition",
                    Description = "Grab the Xbox Wireless Controller – Forza Horizon 5 Limited Edition for the ultimate Horizon adventure, featuring racing inspired custom grips and a first-ever transparent yellow finish. Take control over all terrain with textured trigger grip, and custom bottom and side dimple grip patterns inspired by perforated style performance car steering wheels.",
                    Category = accessoriesCat,
                    Price = 75,
                    Weight = 0.345,
                    ImageUrl = "assets/img/Products/XboxWirelessController–ForzaHorizon5LimitedEdition.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 40 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Xbox, Windows 7, Windows 10"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Wireless Controller Carbon Black",
                    Description = "Experience the modernized design of the Xbox Wireless Controller, featuring sculpted surfaces and refined geometry for enhanced comfort during gameplay. Stay on target with textured grip and a hybrid D-pad. Seamlessly capture and share content with a dedicated Share button.",
                    Category = accessoriesCat,
                    Price = 50,
                    Weight = 0.345,
                    ImageUrl = "assets/img/Products/XboxWirelessControllerBlack.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 40 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Xbox, Windows 7, Windows 10"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Wireless Controller – Electric Volt",
                    Description = "Experience the modernized design of the Xbox Wireless Controller, featuring sculpted surfaces and refined geometry for enhanced comfort during gameplay. Stay on target with textured grip and a hybrid D-pad. Seamlessly capture and share content with a dedicated Share button.",
                    Category = accessoriesCat,
                    Price = 65,
                    Weight = 0.345,
                    ImageUrl = "assets/img/Products/XboxWirelessControllerElectricVolt.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 40 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Xbox, Windows 7, Windows 10"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Xbox Wireless Controller - Pulse Red",
                    Description = "Experience the modernized design of the Xbox Wireless Controller, featuring sculpted surfaces and refined geometry for enhanced comfort during gameplay. Stay on target with textured grip and a hybrid D-pad. Seamlessly capture and share content with a dedicated Share button.",
                    Category = accessoriesCat,
                    Price = 60,
                    Weight = 0.345,
                    ImageUrl = "assets/img/Products/XboxWirelessControllerPulseRed.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 40 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Xbox, Windows 7, Windows 10"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - Gold",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4Gold.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - Red Camouflage",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4RedCamouflage.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - Rose Gold",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4RoseGold.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - Steel Black",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4SteelBlack.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - Berry Blue",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4BerryBlue.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "DualShock 4 Wireless Controller - The Last of Us Part II",
                    Description = "Our most comfortable, intuitive controller ever designed. Now even better, and available in a range of colors and styles.",
                    Category = accessoriesCat,
                    Price = 70,
                    Weight = 0.34,
                    ImageUrl = "assets/img/Products/DualShock4TLOU2.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 30 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps4, Ps4 pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "PlayStation 5 DualSense Wireless Controller",
                    Description = "The DualSense has kept what gamers love about the DualShock 4, while also adding new functionality and refining the design. The DualSense has adaptive triggers built into the L2 and R2 buttons so you can truly feel the tension of your actions, a strong battery life with rechargeable battery whilst also keeping the controller lightweight.",
                    Category = accessoriesCat,
                    Price = 97,
                    Weight = 0.43,
                    ImageUrl = "assets/img/Products/PS5DualSenseController.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Battery"),
                        ValueStr = "Up to 50 hours"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "System requirements"),
                        ValueStr = "Ps5"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Audio"),
                        ValueDec = 3.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Microsoft Surface Laptop Go",
                    Description = "Sleek design and standout value. At just 2.44 lbs, it’s light, portable, and easy to keep by your side throughout the day. Be productive, browse, and binge watch on the 12.4” PixelSense touchscreen display. Convenient security with Windows Hello sign-in, plus Fingerprint Power Button with Windows Hello and One Touch sign-in on select models.",
                    Category = computersCat,
                    Price = 749,
                    Weight = 1.11,
                    ImageUrl = "assets/img/Products/MicrosoftSurfaceLaptopGo.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 10"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Business"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "Surface Laptop Go"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 12.4M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Microsoft Surface Pro 7",
                    Description = "Faster than surface pro 6, with a 10th gen intel core processor – redefining what’s possible in a thin and light computer. Display Resolution - 2736 x 1824 (267 PPI)",
                    Category = computersCat,
                    Price = 999,
                    Weight = 0.77,
                    ImageUrl = "assets/img/Products/MicrosoftSurfacePro.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 10"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Personal"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "Surface Pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 12.3M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Microsoft Surface Laptop 3",
                    Description = "Faster than surface pro 6, with a 10th gen intel core processor – redefining what’s possible in a thin and light computer. Display Resolution - 2736 x 1824 (267 PPI)",
                    Category = computersCat,
                    Price = 560,
                    Weight = 0.77,
                    ImageUrl = "assets/img/Products/MicrosoftSurfaceLaptop3.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 10 Home"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Personal"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "Surface Laptop"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 13.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("2ca243b2-a35d-4941-a618-073c284c40a4"),
                    Name = "Microsoft Surface Pro 6",
                    Description = "Faster than surface pro 6, with a 10th gen intel core processor – redefining what’s possible in a thin and light computer. Display Resolution - 2736 x 1824 (267 PPI)",
                    Category = computersCat,
                    Price = 899,
                    Weight = 1.6,
                    ImageUrl = "assets/img/Products/MicrosoftSurfacePro6.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 10 Home"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Personal"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "Surface Pro"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 12.3M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "Sony VAIO EL2 VPCEL22FX",
                    Description = "Whether it is open or closed, you will find yourself wanting to feel this VAIO E Series laptop. With a textured, diamond-shaped pattern embossed on the lid and palm rest, this PC is artfully crafted to be pleasing to the eyes and to the touch without leaving any fingerprint smudges.",
                    Category = computersCat,
                    Price = 340,
                    Weight = 2.67,
                    ImageUrl = "assets/img/Products/SonyVAIOEL2VPCEL22FX.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 7 Home"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Personal"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "VAIO EL Series"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 15.5M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            {
                var product = new Product()
                {
                    OwnerId = new Guid("c3c70f23-ed99-430b-b587-f3ad698356c3"),
                    Name = "Sony VPCEG1BFX",
                    Description = "Whether it is open or closed, you will find yourself wanting to feel this VAIO E Series laptop. With a textured, diamond-shaped pattern embossed on the lid and palm rest, this PC is artfully crafted to be pleasing to the eyes and to the touch without leaving any fingerprint smudges.",
                    Category = computersCat,
                    Price = 290,
                    Weight = 2.31,
                    ImageUrl = "assets/img/Products/SonyVPCEG1BFX.png"
                };

                var productCharacteristicsValues = new List<CharacteristicValue>()
                {
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Operating System"),
                        ValueStr = "Windows 7 Home"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Specific Uses For Product"),
                        ValueStr = "Personal"
                    },
                    new CharacteristicStringType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Series"),
                        ValueStr = "VAIO EL Series"
                    },
                    new CharacteristicDecimalType()
                    {
                        Product = product,
                        Characteristic = characteristics.FirstOrDefault(ch => ch.Name == "Screen Size"),
                        ValueDec = 14M
                    }
                };

                await eCommerceDbContext.AddAsync(product);
                await eCommerceDbContext.AddRangeAsync(productCharacteristicsValues);
            }

            await eCommerceDbContext.AddRangeAsync(shippings);
            await eCommerceDbContext.AddRangeAsync(characteristics);
            await eCommerceDbContext.AddRangeAsync(characteristicsValues);
            await eCommerceDbContext.AddRangeAsync(categories);
            await eCommerceDbContext.AddRangeAsync(products);
        }
    }
}

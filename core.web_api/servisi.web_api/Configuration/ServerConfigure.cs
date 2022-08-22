using modeli.trading.Security;

namespace servisi.trading.Configuration;

public static class ServerConfigure
{
    public static IEnumerable<Scope> scopes => new[] { 
        new Scope() { 
            name = "trading_api.read",
            inlcudes_roles = new List<string>() { 
                "reader" 
            } 
        },
        new Scope() {
            name = "trading_api.write",
            inlcudes_roles = new List<string>() {
                "writer"
            }
        },
        new Scope() {
            name = "trading_api.trade",
            inlcudes_roles = new List<string>() {
                "trader"
            }
        },
        new Scope() {
            name = "trading_api.admin",
            inlcudes_roles = new List<string>() {
                "admin"
            }
        }
    };

    public static IEnumerable<Client> clients => new [] { 
        new Client() { 
            id = "mobile.client", 
            hidden_secret = Cryptography.SH256_string("SuperSecretPassword;This-one-is-kinde-of-long"), 
            allows_scopes = new List<string>() {
                "trading_api.read",
                "trading_api.write",
                "trading_api.trade"
            } 
        },
        new Client() {
            id = "desktop.client",
            hidden_secret = Cryptography.SH256_string("SuperSecretPassword(as-in-SSP);To-be-honest-it-is-realy-long"),
            allows_scopes = new List<string>() {
                "trading_api.read",
                "trading_api.write",
                "trading_api.admin"
            }
        }
    };

    public static IEnumerable<Role> roles => new[] { 
        new Role() { 
            Name = "trader", 
            Description = "This one buys and/or sells crypto currencies." 
        },
        new Role() {
            Name = "reader", 
            Description = "This one reads data." 
        },
        new Role() {
            Name = "writer",
            Description = "This one writes data."
        },
        new Role() {
            Name = "admin",
            Description = "This one administrates aplication."
        }
    };

}





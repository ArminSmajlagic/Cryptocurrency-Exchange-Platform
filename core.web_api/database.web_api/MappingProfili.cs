using AutoMapper;
using database.trading.DB_Models.Kripto;
using database.trading.DB_Models.Security;
using database.trading.DB_Models.Trading;
using database.trading.DB_Models.User;
using database.trading.DB_Models.User.Wallet;
using modeli.trading.Kripto;
using modeli.trading.Security;
using modeli.trading.Trading;
using modeli.trading.Trading.Requests;
using modeli.trading.User;
using modeli.trading.User.Request;
using modeli.trading.User.Wallet;

namespace database.trading;
public class MappingProfili:Profile
{
    public MappingProfili()
    {
        CreateMap<valuta, Valuta> ();
        CreateMap<ponuda, Ponuda> ();
        CreateMap<user, User>();
        CreateMap<UserUpsertRequest, user>();
        CreateMap<token, Token>();
        CreateMap<Token, token>();
        CreateMap<wallet, Wallet>();
        CreateMap<walletTransakcija, WalletTransakcija>();
        CreateMap<WalletTransakcija, walletTransakcija>();
        CreateMap<wallet_imovina, WalletImovina>();
        //
        CreateMap<narudzba, Narudzba>();
        CreateMap<NarudzbaUpsertRequest, narudzba>();
    }

}


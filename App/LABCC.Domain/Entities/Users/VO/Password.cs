﻿using ValueOf;

namespace LABCC.Domain.Entities.Users.VO;

public sealed class Password : ValueOf<string, Password>
{
    public static Password Hash(string item)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(item); //  Argon2.Hash(item); 
         return From(hash);
    }

    public static bool Verify(Password pass, string maybePass)
    {
        var hash = pass.Value;
        return BCrypt.Net.BCrypt.Verify(maybePass, hash); //Argon2.Verify(hash, maybePass);
    }
    
    public static bool Verify(string hash, string maybePass)
    {
        return BCrypt.Net.BCrypt.Verify(maybePass, hash); //Argon2.Verify(hash, maybePass);
    }
   
}
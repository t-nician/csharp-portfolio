using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class AccountContext : DbContext {
    public DbSet<Account> Accounts { get; set; }

    public string DbPath { get; }

    public AccountContext() => DbPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "account.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();
}


public class Account {
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set;}


    [Required]
    public ScryptParams ScryptParams { get; set; }

    [Required]
    public  EncryptedData EncryptedData { get; set; }
}


public class EncryptedData {
    public string Nonce { get; set; }
    public string Data { get; set; }
}


public class ScryptParams {
    public int ParamR { get; set; }
    public int ParamN { get; set; }
    public int ParamP { get; set; }

    public int HashLength { get; set; }
    public int SaltLength { get; set; }
}
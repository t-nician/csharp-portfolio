using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;


public class AccountContext : DbContext {
    public DbSet<Account> Accounts { get; set; }

    public string DbPath { get; }

    public AccountContext() => DbPath = Path.Join(Environment.CurrentDirectory, "account.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();
}


public class Account {
    [Required, Key]
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


public class AccountServiceResult {
    private Account? _account;
    private string _message;

    public AccountServiceResult(Account? account, string message) {
        _account = account;
        _message = message;
    }

    public string GetMessage() => _message;
    public Account? GetAccount() => _account;
}


public class AccountService {
    private AccountContext _context;

    public AccountService(AccountContext context) => _context = context; 


    public AccountServiceResult CreateAccount(string username, string password) {
        if (username.Length < 3) return new AccountServiceResult(null, "The username provided is too short!");
        if (GetAccountByUsername(username) != null) return new AccountServiceResult(null, "An accout with that username already exists!");



        return new AccountServiceResult(null, "Something unexpected happend!");
    }

    public Account? GetAccountByUsername(string username) {


        return null;
    }
}
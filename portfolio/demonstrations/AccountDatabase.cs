using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;


public class AccountContext : DbContext {
    public DbSet<Account> Accounts { get; set; } 

    public string DbPath { get; }

    public AccountContext() => DbPath = Path.Join(Environment.CurrentDirectory, "account.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();
}


[Table("Accounts")]
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
    [Key]
    public int Id { get; set; }
    public string Nonce { get; set; }
    public string Data { get; set; }
}


public class ScryptParams {
    [Key]
    public int Id { get; set; }
    public int ParamR { get; set; }
    public int ParamN { get; set; }
    public int ParamP { get; set; }

    public int HashLength { get; set; }
    public int SaltLength { get; set; }
}


public class AccountServiceResult {
    private Account? _account;
    private string _message;
    private bool _success;

    public AccountServiceResult(Account? account, bool success, string message) {
        _account = account;
        _message = message;
        _success = success;
    }

    public bool IsSuccess() => _success;
    public string GetMessage() => _message;
    public Account? GetAccount() => _account;
    
}


public class AccountService {
    private AccountContext _context;

    public AccountService() {
        _context = new AccountContext();
    }


    public AccountServiceResult CreateAccount(string username, string password) {
        if (username.Length < 3) return new AccountServiceResult(null, false, "The username provided is too short!");
        if (GetAccountByUsername(username).IsSuccess()) return new AccountServiceResult(null, false, "An account with that username already exists!");

        Account account = new Account() {
            Username = username
        };

        return new AccountServiceResult(account, true, "Account created!");
    }

    public AccountServiceResult GetAccountByUsername(string username) {
        Account? account = _context.Accounts.Find(username);

        if (account != null) return new AccountServiceResult(account, true, "Success!");

        return new AccountServiceResult(null, false, "An account with that username doesn't exist!");;
    }
}
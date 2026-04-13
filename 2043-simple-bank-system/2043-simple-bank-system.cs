public class Bank
{
    private long[] balances;
    private int n;

    public Bank(long[] balance)
    {
        balances = balance;
        n = balance.Length;
    }

    private bool IsValidAccount(int account)
    {
        return account >= 1 && account <= n;
    }

    public bool Transfer(int account1, int account2, long money)
    {
        if (!IsValidAccount(account1) || !IsValidAccount(account2))
            return false;

        int from = account1 - 1;
        int to = account2 - 1;

        if (balances[from] < money)
            return false;

        balances[from] -= money;
        balances[to] += money;

        return true;
    }

    public bool Deposit(int account, long money)
    {
        if (!IsValidAccount(account))
            return false;

        balances[account - 1] += money;
        return true;
    }

    public bool Withdraw(int account, long money)
    {
        if (!IsValidAccount(account))
            return false;

        int idx = account - 1;

        if (balances[idx] < money)
            return false;

        balances[idx] -= money;
        return true;
    }
}
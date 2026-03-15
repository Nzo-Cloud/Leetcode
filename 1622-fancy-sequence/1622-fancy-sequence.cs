using System;
using System.Collections.Generic;

public class Fancy {

    const long MOD = 1000000007;
    List<long> seq;
    long mul;
    long add;

    public Fancy() {
        seq = new List<long>();
        mul = 1;
        add = 0;
    }
    
    public void Append(int val) {
        long invMul = ModPow(mul, MOD - 2);
        long stored = ((val - add) % MOD + MOD) % MOD;
        stored = (stored * invMul) % MOD;
        seq.Add(stored);
    }
    
    public void AddAll(int inc) {
        add = (add + inc) % MOD;
    }
    
    public void MultAll(int m) {
        mul = (mul * m) % MOD;
        add = (add * m) % MOD;
    }
    
    public int GetIndex(int idx) {
        if (idx >= seq.Count) return -1;
        return (int)((seq[idx] * mul + add) % MOD);
    }

    private long ModPow(long baseVal, long exp) {
        long result = 1;
        baseVal %= MOD;

        while (exp > 0) {
            if ((exp & 1) == 1)
                result = (result * baseVal) % MOD;

            baseVal = (baseVal * baseVal) % MOD;
            exp >>= 1;
        }

        return result;
    }
}
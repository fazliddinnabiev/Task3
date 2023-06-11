using System.Security.Cryptography;
namespace Game;
public static class CalculatingHmac
{
    private static string _hmacValue = "";
    private static int _computerMove;
    private static string _key = "";
    internal static string Key => _key; 
    /// <summary>
    /// returns hmac value in string base64 format
    /// </summary>
    internal static string HmacValue => _hmacValue;
    
    internal static int ComputerMove
    {
        get => _computerMove;
        set
        {
            var random = new Random();
            _computerMove = random.Next(0, value);
            CalculateHmac();
        }
    }
    /// <summary>
    /// generates cryptographic random key
    /// </summary>
    /// <returns>array of byte</returns>
    private static byte[] GenerateRandomKey()
    {
        var key = new byte[256];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(key);
        _key = Convert.ToBase64String(key);
        return key;
    }
    private static void CalculateHmac()
    {
        var key = GenerateRandomKey();
        using var hmac = new HMACSHA256(key: key);
        var computerMoveInBytes = BitConverter.GetBytes(ComputerMove);
        var hash = hmac.ComputeHash(computerMoveInBytes);
        _hmacValue = Convert.ToBase64String(hash).ToLower();
    }
}
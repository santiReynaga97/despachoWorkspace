using System.Security.Cryptography;
using System.Text;
using DespachoWorkspace.Management.WebApi.Abstractions;

namespace DespachoWorkspace.Management.WebApi.Services;

public class EncryptionService : IEncryptionService
{

    private readonly IConfiguration _configuration;
    private readonly ILogger<EncryptionService> _logger;

    public EncryptionService(IConfiguration configuration, ILogger<EncryptionService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public string Decrypt(string toDecrypt, string userAgent, string gID)
    {

        _logger.LogInformation("pass Phrase: {Path}", _configuration["SharedCryptPharase"]);
        _logger.LogInformation("SharedCryptIv: {Path}", _configuration["SharedCryptIv"]);
        _logger.LogInformation("SharedCryptSaltKey: {Path}", _configuration["SharedCryptSaltKey"]);
        _logger.LogInformation("SharedCryptHashDigest : {Path}", _configuration["SharedCryptHashDigest"]);
        _logger.LogInformation("SharedCryptIterations : {Path}", _configuration["SharedCryptIterations"]);

        byte[] passPhrase = Encoding.ASCII.GetBytes(_configuration["SharedCryptPharase"]!);
        byte[] iv = Encoding.ASCII.GetBytes(_configuration["SharedCryptIv"]!);
        byte[] salt = Encoding.ASCII.GetBytes(_configuration["SharedCryptSaltKey"] + userAgent + gID);
        byte[] data = Convert.FromBase64String(toDecrypt);
        byte[] key = new PasswordDeriveBytes(passPhrase, salt, _configuration["SharedCryptHashDigest"]!, Convert.ToInt32(_configuration["SharedCryptIterations"])).GetBytes(Convert.ToInt32(_configuration["SharedCryptDerivedKeyLenght"]));

        using Aes aes = Aes.Create();
        aes.Mode = CipherMode.CBC;

        ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
        MemoryStream memoryStream = new MemoryStream(data);
        CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);

        byte[] numArray = new byte[data.Length];
        int num2;
        int num3;

        for (num2 = 0; num2 < numArray.Length; num2 += num3)
        {
            num3 = cryptoStream.Read(numArray, num2, numArray.Length - num2);

            if (num3 == 0)
            {
                break;
            }
        }

        memoryStream.Close();
        cryptoStream.Close();

        return Encoding.UTF8.GetString(numArray, 0, num2);
    }

    public string Encrypt(string toEncrypt, string userAgent, string extraSalt)
    {
        byte[] iv = Encoding.ASCII.GetBytes(_configuration["SharedCryptIv"]!);
        byte[] salt = Encoding.ASCII.GetBytes(_configuration["SharedCryptSaltKey"] + userAgent + extraSalt);
        byte[] data = Encoding.UTF8.GetBytes(toEncrypt);
        byte[] key = new PasswordDeriveBytes(_configuration["SharedCryptPharase"]!, salt, _configuration["SharedCryptHashDigest"]!, Convert.ToInt32(_configuration["SharedCryptIterations"])).GetBytes(Convert.ToInt32(_configuration["SharedCryptDerivedKeyLenght"]));

        using Aes aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(data, 0, data.Length);
        cryptoStream.FlushFinalBlock();
        byte[] array = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(array);
    }

    public string EncryptCertificate(byte[] toEncrypt, byte[] encryptionKey)
    {
        byte[] iv = GenerateRandomBytes(16);

        using Aes aes = Aes.Create();
        aes.Key = encryptionKey;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        byte[] encrypted = encryptor.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
        byte[] result = new byte[aes.IV.Length + encrypted.Length];

        Buffer.BlockCopy(iv, 0, result, 0, aes.IV.Length);
        Buffer.BlockCopy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

        return Convert.ToBase64String(result);

    }

    public byte[] GenerateRandomBytes(int numberOfBytes = 32)
    {
        byte[] randomNumber = new byte[numberOfBytes];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        return randomNumber;
    }

    public byte[] getBytesCertKey(IFormFile formFile)
    {
        byte[] file = new byte[0];

        using (var memoryStream = new MemoryStream())
        {
            formFile.CopyTo(memoryStream);
            file = memoryStream.ToArray();
            memoryStream.SetLength(0);
            memoryStream.Position = 0;
            memoryStream.Close();
        }

        return file;
    }

    public string RsaEncrypt(byte[] data, string publicKey)
    {
        using RSACryptoServiceProvider rsa = new();
        rsa.PersistKeyInCsp = false;
        rsa.ImportFromPem(publicKey);

        byte[] encryptedData = rsa.Encrypt(data, fOAEP: true);

        return Convert.ToBase64String(encryptedData);
    }
}
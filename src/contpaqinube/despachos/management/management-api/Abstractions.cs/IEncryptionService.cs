namespace ContpaqiNube.Despachos.Management.Api.Abstractions;

public interface IEncryptionService
{
    string Encrypt(string toEncrypt, string userAgent, string extraSalt);

    string Decrypt(string toDecrypt, string userAgent, string gID);
    string EncryptCertificate(byte[] toEncrypt, byte[] encryptionKey);

    string RsaEncrypt(byte[] data, string publicKey);
    byte[] GenerateRandomBytes(int numberOfBytes = 32);

    byte[] getBytesCertKey(IFormFile formFile);
}
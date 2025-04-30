using Microsoft.IdentityModel.Tokens;

internal class SimmetricSecuritykey : SecurityKey
{
    private byte[] bytes;

    public SimmetricSecuritykey(byte[] bytes)
    {
        this.bytes = bytes;
    }

    public override int KeySize => throw new NotImplementedException();
}
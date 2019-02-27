namespace Jumio.Api.Tests
{
    public abstract class NoOpTestBase
    {
        internal readonly Api.Netverify.IClient NetverifyClient;
        internal readonly Api.Fastfill.IClient FastfillClient;

        public NoOpTestBase()
        {
            NetverifyClient = new Api.Netverify.NoOpClient();
            FastfillClient = new Api.Fastfill.NoOpClient();
        }
    }
}

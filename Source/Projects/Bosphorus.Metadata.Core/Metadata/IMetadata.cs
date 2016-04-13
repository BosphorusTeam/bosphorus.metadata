namespace Bosphorus.Metadata.Core.Metadata
{
    public interface IMetadata<out TOwner>
    {
        TOwner Owner { get; }
    }

}

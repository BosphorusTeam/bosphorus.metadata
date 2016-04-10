namespace Bosphorus.Metadata.Core.Metadata
{
    public interface IMetadata<TOwner>
    {
        TOwner Owner { get; set; }
    }
}

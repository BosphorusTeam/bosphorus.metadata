namespace Bosphorus.Metadata.Core.Metadata
{
    public class ParentMetadata<TOwner, TChild> : IMetadata<TOwner>
    {
        public TOwner Owner { get; set; }

        public IMetadata<TChild> ChildMetadata { get; set; }
    }
}
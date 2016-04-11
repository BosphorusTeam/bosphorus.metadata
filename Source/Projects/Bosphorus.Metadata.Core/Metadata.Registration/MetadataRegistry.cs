namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public class MetadataRegistry<TOwner>
    {
        private readonly TOwner owner;
        private readonly IMetadataRepository<TOwner> repository;

        public MetadataRegistry(TOwner owner, IMetadataRepository<TOwner> repository)
        {
            this.owner = owner;
            this.repository = repository;
        }

        public MetadataRegistry<TOwner> Is<TMetadata>()
            where TMetadata : IMetadata<TOwner>, new()
        {
            TMetadata metadata = new TMetadata();
            metadata.Owner = owner;
            repository.Metadatas.Add(metadata);

            return this;
        }
    }
}
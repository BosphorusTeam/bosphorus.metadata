using System;
using Bosphorus.Metadata.Core.Metadata.Repository;

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

        public MetadataRegistry<TOwner> Is<TMetadata>(Action<TMetadata> configurer = null)
            where TMetadata : IMetadata<TOwner>, new()
        {
            TMetadata metadata = new TMetadata();
            ((dynamic)metadata).Owner = owner;
            configurer?.Invoke(metadata);
            repository.Metadatas.Add(metadata);

            return this;
        }
    }
}
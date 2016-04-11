namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public static class MetadataRepositoryExtensions
    {
        public static MetadataRegistry<TOwner> RegistryFor<TOwner>(this IMetadataRepository<TOwner> repository, TOwner owner)
        {
            return new MetadataRegistry<TOwner>(owner, repository);
        }
    }
}

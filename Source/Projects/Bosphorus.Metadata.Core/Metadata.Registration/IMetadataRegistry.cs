using System;

namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public interface IMetadataRegistry<TOwner>
    {
        IMetadataRegistry<TOwner> Is<TMetadata>() 
            where TMetadata : IMetadata<TOwner>, new();

    }

}
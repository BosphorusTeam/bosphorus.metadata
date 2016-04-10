using System;

namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public interface IMetadataRegistration<TOwner>
    {
        IMetadataRegistration<TOwner> Is<TMetadata>() 
            where TMetadata : IMetadata<TOwner>, new();

    }

}
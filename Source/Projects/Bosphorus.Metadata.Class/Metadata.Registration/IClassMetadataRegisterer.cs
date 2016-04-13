namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public interface IClassMetadataRegisterer<TModel>
    {
        void Register(ClassMetadataRegistry<TModel> model);
    }
}
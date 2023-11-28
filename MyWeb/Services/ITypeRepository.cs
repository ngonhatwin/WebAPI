namespace MyWeb.Services
{
    public interface ITypeRepository
    {
        List<InterfaceModels.Types> GetAll();
        InterfaceModels.Types GetById(int id);
        InterfaceModels.Types Add (Models.Type model);
        void Update(InterfaceModels.Types type);
        void Delete(int id);
    }
}

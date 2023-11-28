
using MyWeb.Data;
using MyWeb.InterfaceModels;
using System.Xml;

namespace MyWeb.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DbContextProduct context_;
        public TypeRepository(DbContextProduct context) 
        {
            context_ = context;
        }

        public Types Add(Models.Type model)
        {
            var types = new Data.Type
            {
                TypeName = model.Name,
            };
            context_.Add(types);
            context_.SaveChanges();
            return new Types
            {
                Id = types.TypeID,
                Name = types.TypeName,
            };
        }

        public void Delete(int id)
        {
            var types = context_.Types.SingleOrDefault(ty => ty.TypeID == id);
            if (types != null)
            {
                context_.Remove(types);
                context_.SaveChanges();
            }
        }

        public List<Types> GetAll()
        {
            var types = context_.Types.Select(ty => new Types
            {
                Name = ty.TypeName,
                Id = ty.TypeID
            });
            return types.ToList();
        }

        public Types GetById(int id)
        {
            var types = context_.Types.SingleOrDefault(ty => ty.TypeID == id);
            if(types != null)
            {
                return new Types
                {
                    Name = types.TypeName,
                    Id = types.TypeID
                };
            }
            return null;
        }

        public void Update(Types type)
        {
            var types = context_.Types.SingleOrDefault(ty => ty.TypeID == type.Id);
            types.TypeName = type.Name;
            context_.SaveChanges();
        }
    }
}

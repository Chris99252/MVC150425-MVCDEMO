using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
	
namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public override IQueryable<Client> All()
        {     
            return base.All().Where(p => p.IsDelete == false);
        }

        internal IQueryable<Client> SelectGender(string gender)
        {
            return base.All().Where(p => p.Gender == gender && p.IsDelete == false).Take(10);
        }

        internal IQueryable<Client> SelectCity(string city)
        {
            if (String.IsNullOrEmpty(city))
            {
                return base.All().Take(10);
            }
            else
            {
                return base.All().Where(p => p.City == city && p.IsDelete == false).Take(10);
            }
        }

        public Client Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ClientId == id);
        }

        public void Detele(Client client)
        {           
            var db = (FabricsEntities)this.UnitOfWork.Context;

            var Unitclient = db.Client.Find(client.ClientId);

            foreach (var order in Unitclient.Order.ToList())
            {
                db.OrderLine.RemoveRange(order.OrderLine);
            }

            db.Order.RemoveRange(Unitclient.Order.ToList());

            db.Client.Remove(Unitclient);           
        }

        public ObjectResult<Product> QueryProduct()
        {
            //var db = new FabricsEntities();
            //var db = (FabricsEntities)this.UnitOfWork.Context;
            return (((FabricsEntities)this.UnitOfWork.Context).QueryProduct());
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}
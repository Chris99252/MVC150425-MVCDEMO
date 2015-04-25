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
        public Client Find(int id)
        {
            return base.All().FirstOrDefault(p => p.ClientId == id);
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
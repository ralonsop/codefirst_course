using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Base
{
   public abstract class EntityBase
    {
        #region Public properties
   
        public Guid Id { get; set; }
        public DateTime? DBInsertedDate { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Contructores 

        public EntityBase() {
            Id = Guid.NewGuid();
            DBInsertedDate = null;
            Active = true;
        }

        #endregion

        public void UpdateFKs(bool deleteObjectProperty) {
            foreach (var property in this.GetType().GetProperties()) {
                if(property.PropertyType.ToString().Contains("BusinessLayer.Entities")
                    && 
                    (typeof(Person).GUID == property.PropertyType.GUID
                    ||
                    typeof(Login).GUID == property.PropertyType.GUID)
                    ){

                    if (property.GetValue(this) != null
                        && property.GetValue(this) is EntityBase)
                    {

                        var propertyId = this
                            .GetType()
                            .GetProperties()
                            .Where(p => p.Name == property.Name + "Id").FirstOrDefault();

                        propertyId.SetValue(this,
                            ((EntityBase)property.GetValue(this)).Id);

                        if (deleteObjectProperty) {
                            property.SetValue(this, null);
                        }
                    }
                }


            }

        }

    }
}

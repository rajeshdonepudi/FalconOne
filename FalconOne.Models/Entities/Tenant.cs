using FalconOne.Enumerations.Employee;
using FalconOne.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class LegalEntity : ITrackableEntity
    {
        public LegalEntity()
        {
            BusinessUnits = new HashSet<BusinessUnit>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public int CompanyIdentificationNumber { get; set; }
        public DateTime DateOfIncorporation { get; set; }
        public BusinessTypeEnum BusinessType { get; set; }
        public ServiceSectorEnum Sector { get; set; }
        public NatureOfBusinessEnum NatureOfBusiness { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<BusinessUnit> BusinessUnits { get; set; }
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }



    public class Tenant : ITrackableEntity
    {
        public Tenant()
        {
            LegalEntities = new HashSet<LegalEntity>();
            Users = new HashSet<TenantUser>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AccountAlias { get; private set; }
        public string Host { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Image? ProfilePicture { get; set; }
        public virtual ICollection<LegalEntity> LegalEntities { get; set; }
        public virtual ICollection<TenantUser> Users { get; set; }
    }
}

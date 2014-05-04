using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Domains {
	public class TrackableDomainModel<T> : DomainModel<T>, IDeleteModel where T : DomainModel<T> {
		public DateTime CreatedDate { get; set; }
		public int? CreatedById { get; set; }

		public DateTime ModifiedDate { get; set; }
		public int? ModifiedById { get; set; }

		public DateTime? DeletedDate { get; set; }
		public int? DeletedById { get; set; }
		public bool IsDeleted { get; set; }

		public virtual IUser CreatedBy { get; set; }
		public virtual IUser ModifiedBy { get; set; }
		public virtual IUser DeletedBy { get; set; }

		public TrackableDomainModel() {
			CreatedDate =
			ModifiedDate =
				DateTime.Now
			;
		}
	}
}

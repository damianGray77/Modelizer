using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Modelizer.Repositories;

namespace Modelizer.Domains {
	public class DomainModel<T> : Model<T> where T : DomainModel<T> {
		[Key]
		public int Id { get; set; }

		public static IQueryable<T> GetList(Repository Repository) {
			if(null == Repository) {
				return null;
			}

			return Repository.GetList<T>();
		}

		public static IQueryable<T> GetListByIdList(Repository Repository, IEnumerable<int> IdList) {
			if (null == Repository) {
				return null;
			}

			return Repository.GetListByIdList<T>(IdList);
		}

		public static T GetById(Repository Repository, int Id) {
			if (null == Repository) {
				return null;
			}

			return Repository.GetById<T>(Id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Domains;

namespace Modelizer.Repositories {
	public abstract class Repository {
		public IUser CurrentUser { get; set; }

		public abstract IEnumerable<T> Query<T>(SqlQuery SqlQuery) where T : Model<T>;
		public abstract Task<IEnumerable<T>> QueryAsync<T>(SqlQuery SqlQuery) where T : Model<T>;
		public abstract int NonQuery(SqlQuery SqlQuery);
		public abstract Task<int> NonQueryAsync(SqlQuery SqlQuery);

		protected abstract IQueryable<T> GetBaseQuery<T>() where T : DomainModel<T>;

		protected IQueryable<T> GetBaseQuery<T>(bool Deleted) where T : TrackableDomainModel<T> {
			IQueryable<T> query = GetBaseQuery<T>()
					.Where(o => o.IsDeleted == Deleted)
				;

			return query;
		}

		private IQueryable<T> Finalize<T>(IQueryable<T> Query, bool? Deleted = null) where T : DomainModel<T> {
			if (null == Deleted) {
				return Query;
			}

			IQueryable<TrackableDomainModel<T>> tQuery = Query as IQueryable<TrackableDomainModel<T>>;
			if (null == tQuery) {
				return Query;
			}

			IQueryable query = tQuery.Where(o => o.IsDeleted == Deleted.Value);

			return query.Cast<T>();
		}

		public IQueryable<T> GetList<T>() where T : DomainModel<T> {
			IQueryable<T> query = GetBaseQuery<T>();

			return Finalize(query, false);
		}

		public IQueryable<T> GetListByIdList<T>(IEnumerable<int> IdList) where T : DomainModel<T> {
			IQueryable<T> query = GetBaseQuery<T>().Where(o => IdList.Contains(o.Id));

			return Finalize(query);
		}

		public T GetById<T>(int Id) where T : DomainModel<T> {
			IQueryable<T> query = GetBaseQuery<T>().Where(o => o.Id == Id);

			return Finalize(query).FirstOrDefault();
		}

		public void Update<T>(DomainModel<T> Model) where T : DomainModel<T> {
			
		}

		public void Update<T>(TrackableDomainModel<T> Model) where T : TrackableDomainModel<T> {
			DateTime date = DateTime.Now;

			if (0 == Model.Id) {
				Model.CreatedDate = date;
				Model.CreatedById = CurrentUser.Id;
			}

			Model.ModifiedDate = date;
			Model.ModifiedById = CurrentUser.Id;
		}

		public void Delete<T>(DomainModel<T> Model) where T : DomainModel<T> {
			IDeleteModel d = Model as IDeleteModel;
			if (null != d) {
				d.IsDeleted = true;
			}
		}

		public void Delete<T>(TrackableDomainModel<T> Model) where T : TrackableDomainModel<T> {
			Model.IsDeleted = true;
			Model.DeletedDate = DateTime.Now;
			Model.DeletedById = CurrentUser.Id;
		}

		public abstract int Commit();
		public abstract int RollBack();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Modelizer.Mapper;
using Modelizer.Domains;

namespace Modelizer.Projections {
	public static class ProjectionModelExtension {
		public static TDest Project<TSource, TDest>(this TSource Model, Profile<TSource, TDest> Profile)
			where TSource : DomainModel<TSource>
			where TDest : ProjectionModel<TDest>
		{
			if (null == Model || null == Profile) {
				return default(TDest);
			}

			return Profile.Projection.Compile().Invoke(Model);
		}

		private static Expression<Func<TSource, TDest>> ConvertMap<TSource, TDest>(Expression<Profile<TSource, TDest>.Map> Map)
			where TSource : DomainModel<TSource>
			where TDest : ProjectionModel<TDest>
		{
			// rebuild regular Expression<Func<T1, T2>> as our custom
			// Expression<Map> is incompatible with Linq Extensions
			Expression<Func<TSource, TDest>> p = Expression.Lambda<Func<TSource, TDest>>(Map.Body, Map.Parameters);

			return p;
		}

		public static IEnumerable<TDest> Project<TSource, TDest>(this IEnumerable<TSource> List, Profile<TSource, TDest> Profile)
			where TSource : DomainModel<TSource>
			where TDest : ProjectionModel<TDest>
		{
			if (null == List || null == Profile) {
				return null;
			}

			Func<TSource, TDest> p = ConvertMap(Profile.Projection).Compile();

			return List.Select(p);
		}

		public static IQueryable<TDest> Project<TSource, TDest>(this IQueryable<TSource> Query, Profile<TSource, TDest> Profile)
			where TSource : DomainModel<TSource>
			where TDest : ProjectionModel<TDest>
		{
			if (null == Query || null == Profile) {
				return null;
			}

			Expression<Func<TSource, TDest>> p = ConvertMap(Profile.Projection);

			return Query.Select(p);
		}
	}
}

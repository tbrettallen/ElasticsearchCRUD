using System.Collections.Generic;
using ElasticsearchCRUD.Model.GeoModel;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Filters;
using ElasticsearchCRUD.Model.SearchModel.Queries;
using ElasticsearchCRUD.Model.SearchModel.Queries.FunctionQuery;
using ElasticsearchCRUD.Model.Units;
using ElasticsearchCRUD.Tracing;
using NUnit.Framework;

namespace ElasticsearchCRUD.Integration.Test.SearchTests
{
	[TestFixture]
	public class SearchQueryFunctionScoreQueries : SetupSearch
	{
		[Test]
		public void SearchQueryFunctionScoreQueryLinearNumber()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new LinearNumericFunction<double>("lift", 2.0, 3.0)
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}

		[Test]
		public void SearchQueryFunctionScoreQueryLinearGeoPoint()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new LinearGeoPointFunction("location", new GeoPoint(40,40), new DistanceUnitKilometer(100) )
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}

		[Test]
		public void SearchQueryFunctionScoreQueryGaussNumber()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new GaussNumericFunction<double>("lift", 2.0, 3.0)
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}

		[Test]
		public void SearchQueryFunctionScoreQueryGaussGeoPoint()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new GaussGeoPointFunction("location", new GeoPoint(40,40), new DistanceUnitKilometer(100) )
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}

		[Test]
		public void SearchQueryFunctionScoreQueryExpNumber()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new ExpNumericFunction<double>("lift", 2.0, 3.0)
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}

		[Test]
		public void SearchQueryFunctionScoreQueryExpGeoPoint()
		{
			var search = new Search
			{
				Query = new Query(
					new FunctionScoreQuery(
						new MatchAllQuery(),
						new List<BaseScoreFunction>
						{
							new ExpGeoPointFunction("location", new GeoPoint(40,40), new DistanceUnitKilometer(100) )
							{
								Decay=0.3,
								Filter = new MatchAllFilter(),
								Offset= 3,
								Weight= 3.0
							}
						}
					)
				)
			};

			using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
			{
				context.TraceProvider = new ConsoleTraceProvider();
				Assert.IsTrue(context.IndexTypeExists<SearchTest>());
				var items = context.Search<SearchTest>(search);
				Assert.AreEqual(3, items.PayloadResult.Hits.Total);
			}
		}
	}

}
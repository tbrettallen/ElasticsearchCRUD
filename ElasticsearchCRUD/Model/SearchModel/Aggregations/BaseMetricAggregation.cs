﻿using System.Collections.Generic;
using ElasticsearchCRUD.Utils;

namespace ElasticsearchCRUD.Model.SearchModel.Aggregations
{
	/// <summary>
	/// A single-value metrics aggregation that keeps track and returns the minimum value among numeric values extracted from the aggregated documents. 
	/// These values can be extracted either from specific numeric fields in the documents, or be generated by a provided script.
	/// </summary>
	public class BaseMetricAggregation : IAggs
	{
		private readonly string _type;
		private readonly string _name;
		private readonly string _field;

		private string _script;
		private List<ScriptParameter> _params;
		private bool _paramsSet;
		private bool _scriptSet;

		public BaseMetricAggregation(string type, string name, string field)
		{
			_type = type;
			_name = name;
			_field = field;
		}

		public string Script
		{
			get { return _script; }
			set
			{
				_script = value;
				_scriptSet = true;
			}
		}

		public List<ScriptParameter> Params
		{
			get { return _params; }
			set
			{
				_params = value;
				_paramsSet = true;
			}
		}

		public void WriteJson(ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter)
		{
			elasticsearchCrudJsonWriter.JsonWriter.WritePropertyName(_name);
			elasticsearchCrudJsonWriter.JsonWriter.WriteStartObject();
			elasticsearchCrudJsonWriter.JsonWriter.WritePropertyName(_type);
			elasticsearchCrudJsonWriter.JsonWriter.WriteStartObject();

			JsonHelper.WriteValue("field",_field,elasticsearchCrudJsonWriter);
			if (_scriptSet)
			{
				elasticsearchCrudJsonWriter.JsonWriter.WritePropertyName("script");
				elasticsearchCrudJsonWriter.JsonWriter.WriteRawValue("\"" + _script + "\"");
				if (_paramsSet)
				{
					elasticsearchCrudJsonWriter.JsonWriter.WritePropertyName("params");
					elasticsearchCrudJsonWriter.JsonWriter.WriteStartObject();

					foreach (var item in _params)
					{
						elasticsearchCrudJsonWriter.JsonWriter.WritePropertyName(item.ParameterName);
						elasticsearchCrudJsonWriter.JsonWriter.WriteValue(item.ParameterValue);
					}
					elasticsearchCrudJsonWriter.JsonWriter.WriteEndObject();
				}
			}

			elasticsearchCrudJsonWriter.JsonWriter.WriteEndObject();
			elasticsearchCrudJsonWriter.JsonWriter.WriteEndObject();
		}
	}
}

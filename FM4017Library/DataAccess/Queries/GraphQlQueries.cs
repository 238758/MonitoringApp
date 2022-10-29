using FM4017Library.Helpers;
using System.Formats.Asn1;

namespace FM4017Library.DataAccess;

public static class GraphQlQueries
{
    public static string GetAllPointsSignals = @"query {
		points(paginate: { last: 100 }) {
			nodes {
				id
				spaceId
				name
				createdAt
				updatedAt
				metadata
				signals(paginate: { last: 100 }) {
					nodes {
						id
						pointId
						timestamp
						unit
						createdAt
						updatedAt
						metadata
						data {
							rawValue
							numericValue
						}
					}
				}
			}
		}
	}";

    public static string GetAllSpacesPointsSignals = @"query {
	spaces(paginate: { last: 100 }) {
	nodes {
		id
		name
		createdAt
		updatedAt
		metadata
		parent {
			id
			name
		}
		points(paginate: { last: 100 }) {
			nodes {
				id
				spaceId
				name
				createdAt
				updatedAt
				metadata
				signals(paginate: { last: 100 }) {
					nodes {
						id
						pointId
						timestamp
						unit
						createdAt
						updatedAt
						metadata
						data {
							rawValue
							numericValue
								}
							}
						}
					}
				}
			}
		}
	}";

	public static string DeleteSpace(string spaceId)
	{
		string result = $"mutation {{ space {{ delete(input: {{ id: \"{spaceId}\" }}) {{ id	}} }} }}";

        return result;
	}

    public static string DeletePoint(string pointId)
    {
        string result = $"mutation {{ point {{ delete(input: {{ id: \"{pointId}\" }}) {{ id	}} }} }}";

        return result;
    }

    public static string DeleteSignal(string signalId)
    {
        string result = $"mutation {{ signal {{ delete(input: {{ id: \"{signalId}\" }}) {{ id	}} }} }}";

        return result;
    }



    public static string CreateSpace(string name, string? parentId = null, double? longitude = null, double? latitude = null, string? imageUrl = null)
	{
        string metadata = $"metadata: {{ longitude: {longitude} latitude: {latitude} imageUrl: \"{imageUrl}\" }}";

        string result = $"mutation {{ space {{ create( input: {{ name: \"{name}\" parentId: \"{parentId}\" {metadata} }}) {{ id }} }}	}}";

        return result;
    }

    public static string CreatePoint(string name, string? spaceId = null, double? longitude = null, double? latitude = null, string? imageUrl = null)
    {
        string metadata = $"metadata: {{ longitude: {longitude} latitude: {latitude} imageUrl: \"{imageUrl}\" }}";

        string result = $"mutation {{ point {{ create( input: {{ name: \"{name}\" spaceId: \"{spaceId}\" {metadata} }}) {{ id }} }}	}}";

        return result;
    }

    public static string CreateSignal(string pointId, string value, DateTime timestamp, string unit)
    {
        string result = $"mutation {{ signal {{ create( input: {{ pointId: \"{pointId}\", signals: [ {{ unit: {unit} value: \"{value}\" type: \"{""}\" timestamp: \"{DateTimeHelpers.DateTimeToD4Format(timestamp)}\" }} ] }} ) {{ id }} }} }}";

        return result;
    }

    public static string EditSpace(string name, string id, double? longitude = null, double? latitude = null, string? imageUrl = null)
    {
        string metadata = $"metadata: {{ longitude: {longitude} latitude: {latitude} imageUrl: \"{imageUrl}\" }}";

        string result = $"mutation {{ space {{ update(input: {{ id: \"{id}\" data: {{ name: \"{name}\" {metadata} }} }}) {{ id }} }} }}";

        return result;
    }

    public static string EditPoint(string name, string id, double? longitude = null, double? latitude = null, string? imageUrl = null)
    {
        string metadata = $"metadata: {{ longitude: {longitude} latitude: {latitude} imageUrl: \"{imageUrl}\" }}";

        string result = $"mutation {{ point {{ update(input: {{ id: \"{id}\" point: {{ name: \"{name}\" {metadata} }} }}) {{ id }} }} }}";

        return result;
    }

}

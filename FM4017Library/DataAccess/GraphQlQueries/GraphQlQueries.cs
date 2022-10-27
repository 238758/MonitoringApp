using FM4017Library.DataModels;

namespace FM4017Library.DataAccess.GraphQlQueries;

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
		string result = @"mutation {
		  space {
			delete(input: { id: """ + spaceId + @""" }) {
			  id
			}
		  }
		}
		";

		return result;
	}

	public static string CreateSpace(string name, string? parentId = null, double? longitude = null, double? latitude = null, string? imageUrl = null)
	{
		//string result =
		//@"mutation {
  //          space {
  //              create(
  //                  input: {
  //              name: """ + name + @""" 
  //              parentId: """ + parentId + @"""
  //              metadata:
  //                  {
  //                  longitude:" + longitude + @"
  //                  latitude: " + latitude + @"
  //                  imageUrl: """ + imageUrl + @"""
		//			}
  //              }
		//		) {
  //                  id
		//		}
		//			}
		//		}";

        string result =
        @"mutation {
            space {
                create(
                    input: {
                name: """ + name + @""" 
                }
				) {
                    id
				}
					}
				}";

        return result;

    }


}

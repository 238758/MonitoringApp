using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataAccess.GraphQlQueries
{
    public static class GraphQlQueries
    {
        public static string GetAllPoints = @"query {
		points {
			nodes{
				id
				spaceId
				name
				metadata
				createdAt
				updatedAt
				signals(paginate: {last: 100}) {
					nodes{
						id
						pointId
						unit
						metadata
						createdAt
						updatedAt
						data{
							rawValue
						}
						timestamp
					}
				}
			}
		}
	}";


    }
}

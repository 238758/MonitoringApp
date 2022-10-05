using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataAccess.GraphQlQueries
{
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
									}
								}
							}
						}
					}
				}
			}
		}";


    }
}

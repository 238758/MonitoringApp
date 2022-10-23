﻿using FM4017Library.Dtos;

namespace FM4017Library.DataModels;

public class Point
{
    public string? Id { get; set; }
    public string? SpaceId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Signal>? signals { get; set; }
    
    // derived from metadata
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? ImageUrl { get; set; }

    public Point()
    {

    }

    public Point(PointNode pointNode)
    {
        Id = pointNode.Id;
        SpaceId = pointNode.SpaceId;
        Name = pointNode.Name;
        CreatedAt = pointNode.CreatedAt;
        UpdatedAt = pointNode.UpdatedAt;


        Latitude = pointNode?.Metadata?.Latitude;
        Longitude = pointNode?.Metadata?.Longitude;
        ImageUrl = pointNode?.Metadata?.ImageUrl;

    }
}

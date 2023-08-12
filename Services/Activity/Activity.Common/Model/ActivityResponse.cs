﻿namespace Activity.Common.Model;

public record ActivityResponse
{
    public int activityId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }    
}

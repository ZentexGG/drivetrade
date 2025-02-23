﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModels;

public class ImageApiResponse
{
    public int Status { get; set; }
    public bool Success { get; set; }
    public ImageApiData Data { get; set; }
}

public class ImageApiData
{
    public string Id { get; set; }
    public string Deletehash { get; set; }
    public string AccountId { get; set; }
    public string AccountUrl { get; set; }
    public string AdType { get; set; }
    public string AdUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Size { get; set; }
    public int Views { get; set; }
    public string Section { get; set; }
    public string Vote { get; set; }
    public int Bandwidth { get; set; }
    public bool Animated { get; set; }
    public bool Favorite { get; set; }
    public bool InGallery { get; set; }
    public bool InMostViral { get; set; }
    public bool HasSound { get; set; }
    public bool IsAd { get; set; }
    public bool? Nsfw { get; set; }  // Nullable because it can be null in the response
    public string Link { get; set; }
    public List<string> Tags { get; set; }
    public int Datetime { get; set; }
    public string Mp4 { get; set; }
    public string Hls { get; set; }
}

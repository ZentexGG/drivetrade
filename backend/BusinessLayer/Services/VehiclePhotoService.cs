using BusinessLayer.EntitiesDTOs;
using BusinessLayer.Interfaces;
using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Net.Http.Headers;
using DataLayer.ApiModels;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BusinessLayer.Services;

public class VehiclePhotoService(IDbContext context) : IVehiclePhotoService
{
    private readonly IDbContext _context = context;

    public async Task<VehiclePhotoDTO> Create(VehiclePhotoUploadDto vehiclePhotoUploadDto)
    {
        using var client = new HttpClient();
        using var content = new MultipartFormDataContent();
        // Add the image file as 'image'
        var fileContent = new StreamContent(vehiclePhotoUploadDto.File.OpenReadStream());
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(vehiclePhotoUploadDto.File.ContentType);
        content.Add(fileContent, "image", vehiclePhotoUploadDto.File.FileName);
        content.Add(new StringContent("file"), "type");
        content.Add(new StringContent($"DriveTrade photo for vehicle ID: {vehiclePhotoUploadDto.VehicleId}"), "title");
        content.Add(new StringContent("DriveTrade"), "description");

        // Set the authorization header with your client ID
        // TODO: ADD CLIENT ID
        client.DefaultRequestHeaders.Add("Authorization", $"Client-ID ");

        // Send POST request to ImgUr
        var response = await client.PostAsync("https://api.imgur.com/3/image", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Image API Exception thrown!");
        }
        var responseString = await response.Content.ReadAsStringAsync();
        var responseData = JsonConvert.DeserializeObject<ImageApiResponse>(responseString);


        var photoToAdd = new VehiclePhotoDTO
        {
            VehicleId = vehiclePhotoUploadDto.VehicleId,
            ImageUrl = responseData.Data.Link,
            UploadDate = DateTime.UtcNow
        };
        await _context.VehiclePhotos.AddAsync(VehiclePhotoDTO.ToEntity(photoToAdd));
        await _context.SaveChangesAsync();
        return photoToAdd;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<VehiclePhotoDTO> GetAll()
    {
        throw new NotImplementedException();
    }

    public VehiclePhotoDTO GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, VehiclePhotoDTO vehiclePhoto)
    {
        throw new NotImplementedException();
    }
}
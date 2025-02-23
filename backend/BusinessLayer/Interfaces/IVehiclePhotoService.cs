using BusinessLayer.EntitiesDTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Interfaces;

public interface IVehiclePhotoService
{
    IEnumerable<VehiclePhotoDTO> GetAll();
    VehiclePhotoDTO GetById(int id);
    Task<VehiclePhotoDTO> Create(VehiclePhotoUploadDto vehiclePhotoUploadDto);
    void Update(int id, VehiclePhotoDTO vehiclePhoto);
    void Delete(int id);
}
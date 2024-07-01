using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotelManagementSystem.Implementation.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomService(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public async Task<BaseResponse<Guid>> CreateRoom(CreateRoom request)
        {
            try
            {
                if (request != null)
                {
                    // Check if the room already exists
                    var existingRoom = _dbContext.Rooms.FirstOrDefault(x =>
                        x.RoomName == request.RoomName &&
                        x.RoomNumber == request.RoomNumber &&
                        x.RoomType == request.RoomType &&
                        x.RoomStatus == request.RoomStatus);

                    if (existingRoom != null)
                    {
                        // Room already exists
                        return new BaseResponse<Guid>
                        {
                            Success = true,
                            Message = $"Room {request.RoomName} already exists.",
                            Hasherror = true
                        };

                    }

                    //create a new one
                    var room = new Room
                    {
                        RoomName = request.RoomName,
                        Availability = request.Availability,
                        RoomNumber = request.RoomNumber,
                        RoomRate = request.RoomRate,
                        RoomStatus = request.RoomStatus,
                        BedType = request.BedType,
                        //RoomId = request.RoomId,
                        RoomType = request.RoomType,
                        MaxOccupancy = request.MaxOccupancy,
                        //Amenities = request.AmenityName,
                    };

                    await _dbContext.Rooms.AddAsync(room);
                    _dbContext.SaveChanges();
                }
                return new BaseResponse<Guid>
                {
                    Success = true,
                    Message = $"Room {request.RoomName} Created failed"

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Guid>
                {

                    Success = true,
                    Message = $"Room {request.RoomName} Created Failed"

                };
            }

        }




        public async Task<List<RoomDto>> GetRoom()
        {
            return _dbContext.Rooms
                .Include(x => x.Amenities)
                //.Include(x => x.RoomType)
                .Select(x => new RoomDto()
                {
                    Id = x.Id,
                    RoomType = x.RoomType,
                    RoomName = x.RoomName,
                    Availability = x.Availability,
                    MaxOccupancy = x.MaxOccupancy,
                    BedType = x.BedType,
                    RoomNumber = x.RoomNumber,
                    RoomRate = x.RoomRate,
                    RoomStatus = x.RoomStatus,
                    //Amenity = x.Amenity


                }).ToList();
        }


        public async Task<BaseResponse<Guid>> DeleteRoomAsync(Guid Id)
        {
            try
            {
                var room = await _dbContext.Rooms.FirstOrDefaultAsync();
                if (room != null)
                {
                    _dbContext.Rooms.Remove(room);
                }
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = $"Room  Number {Id} has been deleted succesfully "
                    };
                }
                else
                {
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = $"Failed to delete room with {Id}.The room may not exist or there was an error in the deletion process."
                    };
                }
            }
            catch
            {
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = $"Failed to delete room with {Id}.The room may not exist or there was an error in the deletion process."
                };
            }
        }
        public async Task<BaseResponse<RoomDto>> GetRoomAsync(Guid Id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == Id);
            if (room != null)
            {
                return new BaseResponse<RoomDto>
                {
                    Message = "",
                    Success = true,
                    Data = new RoomDto
                    {

                        RoomNumber = room.RoomNumber,
                        Availability = room.Availability,
                        BedType = room.BedType,
                        Id = room.Id,
                        MaxOccupancy = room.MaxOccupancy,
                        RoomRate = room.RoomRate,
                        RoomName = room.RoomName,
                        RoomStatus = room.RoomStatus,
                        RoomType = room.RoomType,
                        // Amenity  = room.Amenity
                    }

                };

            }
            return new BaseResponse<RoomDto>
            {
                Success = false,
                Message = "",
            };
        }

        public List<SelectAmenityDto> GetAmenitySelect()
        {
            var amenityName = _dbContext.Amenities.ToList();
            var result = new List<SelectAmenityDto>();

            if (amenityName.Count > 0)
            {
                result = amenityName.Select(x => new SelectAmenityDto()
                {
                    Id = x.Id,
                    AmenityName = x.AmenityName,
                }).ToList();
            }

            return result;
        }


        public async Task<BaseResponse<IList<RoomDto>>> GetAllRoomsCreatedAsync()
        {
            var rooms = await _dbContext.Rooms
             .Select(x => new RoomDto()
             {
                 Id = x.Id,
                 RoomName = x.RoomName,
                 RoomNumber = x.RoomNumber,
                 Availability = x.Availability,
                 RoomRate = x.RoomRate,
                 RoomStatus = x.RoomStatus,
                 BedType = x.BedType,
                 RoomType = x.RoomType,
                 MaxOccupancy = x.MaxOccupancy,
                 // Amenity = x.Amenity
             }).ToListAsync();


            return new BaseResponse<IList<RoomDto>>
            {
                Success = true,
                Message = "Rooms Succesfully Retrieved",
                Data = rooms
            };
        }




        public async Task<BaseResponse<RoomDto>> GetRoomsByIdAsync(Guid Id)
        {

            var rooms = await _dbContext.Rooms
             .Where(x => x.Id == Id)
             .Select(x => new RoomDto()
             {
                 Id = x.Id,
                 RoomName = x.RoomName,
                 RoomNumber = x.RoomNumber,
                 Availability = x.Availability,
                 RoomRate = x.RoomRate,
                 RoomStatus = x.RoomStatus,
                 BedType = x.BedType,
                 RoomType = x.RoomType,
                 MaxOccupancy = x.MaxOccupancy,
                 // Amenity = x.Amenity
             }).FirstOrDefaultAsync();
            if (rooms != null)
            {
                return new BaseResponse<RoomDto>
                {
                    Success = true,
                    Message = $"Room {Id} Retrieved succesfully",
                    Data = rooms

                };
            }
            else
            {
                return new BaseResponse<RoomDto>
                {
                    Success = false,
                    Message = $"Room {Id} Retrieval Failed"
                };
            }

        }



        public async Task<BaseResponse<RoomDto>> UpdateRoom(Guid Id, UpdateRoom request)
        {
            try
            {
                var room = _dbContext.Rooms.FirstOrDefault(x => x.Id == Id);
                if (room == null)
                {
                    return new BaseResponse<RoomDto>
                    {
                        Success = false,
                        Message = $"Room {request.RoomName} Update failed",
                        Hasherror = true
                    };

                }
                room.RoomNumber = request.RoomNumber;
                room.RoomName = request.RoomName;
                room.RoomRate = request.RoomRate;
                room.RoomStatus = request.RoomStatus;
                room.BedType = request.BedType;
                room.RoomType = request.RoomType;
                room.MaxOccupancy = request.MaxOccupancy;
                room.RoomStatus = request.RoomStatus;
                // room.Amenity = request.Amenity;
                _dbContext.Rooms.Update(room);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<RoomDto>
                    {
                        Success = true,
                        Message = $"Room {request.Id} Updated Succesfully",
                    };

                }
                else
                {
                    return new BaseResponse<RoomDto>
                    {
                        Success = false,
                        Message = $"Room {request.Id} Update failed",
                        Hasherror = true
                    };
                }
            }
            catch
            {
                return new BaseResponse<RoomDto>
                {
                    Success = false,
                    Message = $"Room {request.Id} Update failed",
                    Hasherror = true
                };
            }


        }


    }
}



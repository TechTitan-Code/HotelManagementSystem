namespace HotelManagementSystem.Model.Entity.Enum
{
    public enum RoomStatus
    {
        CheckedIn = 1,
        CheckedOut,
        Pending,
        Cancelled,

    }
    public enum RoomName
    {

        StandardRoom = 1,
        DeluxeRoom,
        SuperiorRoom,
        ExecutiveRoom,
        JuniorSuite,
        PresidentialSuite,
        LuxuryRoom,
        PremiumRoom,
        ClassicRoom,
        ComfortRoom,
        FamilyRoom,
        DoubleRoom,
        TwinRoom,
        KingRoom,
        QueenRoom,
        OceanViewRoom,
        CityViewRoom,
        GardenViewRoom,
    }

    public enum BedType
    {
        KingBed = 1,
        TrundleBed,
        RollawayBed,
    }

    public enum RoomType
    {
        Single = 1,
        Double,
        Suite
    }

    public enum Gender
    {
        Male =1,
        Female 
    }

    public enum Review
    {
        Excellent = 1,
        Good ,
        Bad ,
        Worst 

    }
}



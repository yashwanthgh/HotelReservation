using HotelReservationSystem;

internal class Program
{
    public static void Main(string[] args)
    {
       
        ReservationSystem lakeWood = new("LakeWood", 3, 110, 90);
        ReservationSystem bridgeWood = new("BridgeWood", 4, 160, 60);
        ReservationSystem ridgeWood = new("RidgeWood", 5, 220, 150);
    }
}
namespace Art.Exhibit.FrontEnd.Application.DTOs;

public class CreateOrderDTO
{
    public int UserId { get; set; }
    public float TotalPrice { get; set; } = 0f;
    public float Commission { get; set; } = 0f;
    public string OrderStatus { get; set; } = string.Empty;
}
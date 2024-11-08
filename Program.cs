using DbzCards.Models;
using DbzCards.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//

List<Card> cards = new List<Card>()
{
    new Card()
    {
        Id = 1,
        Name = "Goku",
        Race = "Saiyan",
        PowerLevel = 9001
    },
    new Card()
    {
        Id = 2,
        Name = "Gohan",
        Race = "Saiyan",
        PowerLevel = 5000
    },
    new Card()
    {
        Id = 3,
        Name = "Piccolo",
        Race = "Namekian",
        PowerLevel = 6000
    },
    new Card()
    {
        Id = 4,
        Name = "Krillin",
        Race = "Human",
        PowerLevel = 2000
    },
};

app.MapGet("/cards", () => 
{
    return Results.Ok(cards.Select(card => new CardDTO
    {
        Name = card.Name,
        Race = card.Race,
        PowerLevel = card.PowerLevel
    }));
});

app.MapGet("/cards/{id}", (int id) => 
{
    Card card = cards.FirstOrDefault(card => card.Id == id);
    CardDTO cardDTO = new CardDTO
    {
        Name = card.Name,
        Race = card.Race,
        PowerLevel = card.PowerLevel
    };
    return Results.Ok(cardDTO);
});

app.MapPut("/cards/{id}", (int id, CardDTO cardDTO) => 
{
    Card card = cards.FirstOrDefault(card => card.Id == id);

    card.Name = cardDTO.Name;
    card.Race = cardDTO.Race;
    card.PowerLevel = cardDTO.PowerLevel;

    return Results.Ok(card);

});

app.MapPost("/cards", (CardDTO cardDTO) => 
{
    int newCardId = cards.Max(card => card.Id) + 1;
    Card card = new Card
    {
        Id = newCardId,
        Name = cardDTO.Name,
        Race = cardDTO.Race,
        PowerLevel = cardDTO.PowerLevel
    };
    cards.Add(card);
    return Results.Created($"/cards/{newCardId}", card);
});

app.MapDelete("/cards/{id}", (int id) => 
{
    Card cardToDelete = cards.FirstOrDefault(card => card.Id == id);

    cards.Remove(cardToDelete);
    
    return Results.NoContent();
});

//

app.Run();



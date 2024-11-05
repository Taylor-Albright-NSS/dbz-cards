using System;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information

var builder = WebApplication.CreateBuilder(args);

// Add basic services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development mode only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var cardList = new List<Card>();
var card1 = new Card { Id = 1, Name = "Goku", Race = "Saiyan", Power = 9000 };
var card2 = new Card { Id = 2, Name = "Vegeta", Race = "Saiyan", Power = 8500 };
var card3 = new Card { Id = 3, Name = "Piccolo", Race = "Namekian", Power = 7000 };
var card4 = new Card { Id = 4, Name = "Frieza", Race = "Alien", Power = 10000 };
var card5 = new Card { Id = 5, Name = "Krillin", Race = "Human", Power = 3000 };
var card6 = new Card { Id = 6, Name = "Gohan", Race = "Saiyan", Power = 7500 };
var card7 = new Card { Id = 7, Name = "Trunks", Race = "Saiyan", Power = 7200 };
var card8 = new Card { Id = 8, Name = "Bulma", Race = "Human", Power = 100 };
var card9 = new Card { Id = 9, Name = "Tien", Race = "Human", Power = 3500 };
var card10 = new Card { Id = 10, Name = "Yamcha", Race = "Human", Power = 2500 };

// Create the list and add each card to it

cardList.Add(card1);
cardList.Add(card2);
cardList.Add(card3);
cardList.Add(card4);
cardList.Add(card5);
cardList.Add(card6);
cardList.Add(card7);
cardList.Add(card8);
cardList.Add(card9);
cardList.Add(card10);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


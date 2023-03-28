using System.Collections.ObjectModel;

namespace MicroCoffees.Domain.Entities.CoffeeAggregate;

/// <summary>
/// Represents a coffee sold by the shop.
/// </summary>
public sealed class Coffee : Entity
{
    /// <summary>
    /// Ingredients in the <see cref="Coffee"/>.
    /// </summary>
    private readonly List<Ingredient> ingredients;

    /// <summary>
    /// Initializes the <see cref="Coffee"/> class.
    /// </summary>
    public Coffee() : base()
    {
        this.ingredients = new List<Ingredient>();
        this.Name = string.Empty;
        this.ImageUrl =  string.Empty;
    }

    /// <summary>
    /// The coffee's name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// A url leading to an image of the coffee.
    /// </summary>
    public string ImageUrl { get; init; }

    /// <summary>
    /// The coffee's cost.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// How much of this <see cref="Coffee"/> the shop has in stock.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Ingredients in the coffee.
    /// </summary>
    public ReadOnlyCollection<Ingredient> Ingredients
        => this.ingredients.AsReadOnly();

    /// <summary>
    /// Adds an ingredient to the <see cref="Coffee"/>.
    /// </summary>
    /// <param name="ingredient">The <see cref="Ingredient"/> to add.</param>
    /// <returns>The current instance with an added ingredient.</returns>
    /// <exception cref="ArgumentException"></exception>
    public Coffee AddIngredient(Ingredient ingredient)
    {
        if (this.Cost < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }

        this.Cost += ingredient.Cost;
        this.ingredients.Add(ingredient);

        return this;
    }

    /// <summary>
    /// Serves the <see cref="Coffee"/> to a customer.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void Serve()
    {
        if (this.Quantity <= 0)
        {
            throw new InvalidOperationException("Cannot serve a coffee that we don't have.");
        }

        this.Quantity--;

        if (this.Quantity == 0)
        {
            // Remove coffee.
        }
    }
}

namespace Monopoly;
public struct Player   //REQUIREMENT 4: struct definition, we used an struct for player, even though we had use ref later, it helped to change the owner of the properties as it was a value type.
{
    public int CurrentPosition { get; set; }
    public bool wasSentInJail { get; set; }
    public Token token { get; }
    public string Name
    {
        get;
    }
    public int Money
    {
        get; set;
    }
    public int moneyToPay
    {
        get; set;
    }

    public IEnumerable<Property> Properties  //REQUIREMNT 15: Use of one built-in generic collection type, we used IEnumerable in order to have the properties of the player be set to either array or list 
    {
        get; set;
    }
    public Player(string name)
    {
        token = (Token)new Random().Next(0, 25);
        wasSentInJail = false;
        moneyToPay = 0;
        CurrentPosition = 0;
        Name = name;
        Money = 1500;
        Properties = new List<Property>();   //REQUIREMNT 15: Use of one built-in generic collection type, we used list in order to have items added freely
    }

}

public enum Token { ς, ε, ρ, τ, υ, θ, ι, ο, π, λ, κ, ξ, η, γ, φ, δ, σ, α, ζ, χ, ψ, ω, β, ν, μ, Ε, Ρ, Τ, Υ, Θ, Ι, Ο, Π, Α, Σ, Δ, Φ, Γ, Η, Ξ, Κ, Λ, Ζ, Χ, Ψ, Ω, Β, Ν, Μ }
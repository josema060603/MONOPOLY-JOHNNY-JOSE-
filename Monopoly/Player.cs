namespace Monopoly;
public struct Player   //feature 4: struct definition 
{
    public int CurrentPosition{get; set;}
    public bool wasSentInJail{get; set;}
    public Token token{get;}
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
    
    public IEnumerable<Property> Properties  //Requirement 15: Use of one build-in generic function
    {
        get; set;
    }
    public Player(string name)
    {
        token=  (Token) new Random().Next(0, 25);
        wasSentInJail=false;
        moneyToPay=0;
        CurrentPosition=0;
        Name = name;
        Money = 1500;
        Properties = new List<Property>();   //Requirement 15: Use of one built-in generic function
    }
    public static bool operator==(Player player1, Player player2)
    {
        return player1==player2;
    }
    public static bool operator!=(Player player1, Player player2)
    {
        return player1!=player2;
    }
}

public enum Token{ς,ε,ρ,τ,υ,θ,ι,ο,π,λ,κ,ξ,η,γ,φ,δ,σ,α,ζ,χ,ψ,ω,β, ν, μ, Ε, Ρ, Τ,Υ,Θ, Ι, Ο, Π, Α, Σ, Δ, Φ, Γ, Η, Ξ, Κ, Λ, Ζ, Χ, Ψ, Ω, Β, Ν, Μ}  
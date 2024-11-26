class Player {
    public int health { get; set;} 
    public int level { get; set;}
    public double hability { get; set;}

    public Player(int health, int level, double hability) {
        this.health = health;
        this.level = level;
        this.hability = hability;
    }

    public int dice(){
        Random random = new Random();
        return random.Next(1, 7) + random.Next(1, 7);
    }

    public virtual void Figth(){
        int attack = dice();
        hability += 0.10;
        Console.WriteLine($"Player atacó con {attack} y tu habilidad ahora es {hability}");
    }

    public void upHablity() {hability ++;}
    public void upLevel() {level ++;}

}


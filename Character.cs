class Character {
    public string name { get; set;} 
    public int level { get; set;}
    public int health { get; set;}
    
    public Character(string name, int health, int level)
    {
        this.level = level;
        this.health = health;
        this.name = name;
    }

    public int dice(){
        Random random = new Random();
        return random.Next(1, 7) + random.Next(1, 7);
    }

    public virtual int Attack () {
        return dice();
    }
}
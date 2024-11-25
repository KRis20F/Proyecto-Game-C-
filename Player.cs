class Player {
    public int health { get; set;}
    public int level { get; set;}
    public int hability { get; set;}

    public Player(int health, int level, int hability) {
        this.health = health;
        this.level = level;
        this.hability = hability;
    }

    public void LevelUp() {
        level++;
        health += 5;
        hability += 5;
    }
}


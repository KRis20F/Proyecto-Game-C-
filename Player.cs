class Player : Character {
    
    public int hability { get; set; }
    public Player(string name, int health, int level, int hability) : base(name ,health, level ){
        this.hability = hability;
    }

    public override int Attack () {
        int attackdice = dice();
        int bonusHability = Convert.ToInt32(hability * 0.10);
        return attackdice + bonusHability;
    }


}


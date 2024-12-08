class Magic : Player{
    
    public int speciallyHabality { get; set; }

    public Magic(string name, int health, int level, int hability, int speciallyHabality):base (name, health, level, hability){
        this.speciallyHabality = speciallyHabality;
    }

    public override int Attack() {
        return base.Attack() + 4;
    }

    public void getLife(int shift) {
        if ((shift - speciallyHabality) >= 3 )
        {
            health += 2;
            speciallyHabality = shift;
        }

    }

}
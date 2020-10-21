import java.util.ArrayList;

public class Armouries {
    private ArrayList<Weapon> arrWeapon;

    public Armouries() {
        arrWeapon = new ArrayList<>();
    }

    public Armouries(ArrayList<Weapon> arrWeapon) {
        this.arrWeapon = arrWeapon;
    }

    public void addWeapon(Weapon weapon) {
        arrWeapon.add(weapon);
    }

    public ArrayList<Weapon> getArmoriesWeapon() {
        return arrWeapon;
    }

    public void setArrWeapon(ArrayList<Weapon> arrWeapon) {
        this.arrWeapon = arrWeapon;
    }

    public boolean findWeapon(Weapon weapon) {
        return arrWeapon.contains(weapon);
    }

    public boolean removeWeapon(Weapon weapon) {
        return arrWeapon.remove(weapon);
    }

    public void clearArmouries() {
        arrWeapon.clear();
    }

    public void printArmories() {
        int gun = 0, steel = 0;

        for (Weapon weapon : arrWeapon) {
            if (weapon instanceof Gun)
                gun++;
            else if (weapon instanceof ColdSteel)
                steel++;
        }

        System.out.println(String.format("Количество единиц огнестрельного оружия: %d%n", gun));
        System.out.println(String.format("Количество единиц холодного оружия: %d%n", steel));
    }
}

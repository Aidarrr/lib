/*
class Robot
{
    private int x = 0;
    private int y = 0;
    private Direction direction = Direction.UP;

    public Robot() {
    }

    public Robot(int x, int y, Direction direction) {
        this.x = x;
        this.y = y;
        this.direction = direction;
    }

    public Direction getDirection() {
        return direction;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public void turnLeft() {
        System.out.println("Поворот против часовой стрелки");
        if (direction == Direction.DOWN) {
            this.direction = Direction.RIGHT;
            return;
        }

        if (direction == Direction.UP) {
            this.direction = Direction.LEFT;
            return;
        }

        if (direction == Direction.LEFT) {
            this.direction = Direction.DOWN;
            return;
        }

        if (direction == Direction.RIGHT) {
            this.direction = Direction.UP;
            return;
        }
    }

    public void turnRight() {
        System.out.println("поворот по часовой стрелке");
        if (this.direction == Direction.DOWN) {
            System.out.println("Вниз -> влево");
            this.direction = Direction.LEFT;
            return;
        }

        if (this.direction == Direction.UP) {
            System.out.println("Вверх -> вправо");
            this.direction = Direction.RIGHT;
            return;
        }

        if (this.direction == Direction.LEFT) {
            System.out.println("Влево -> вверх");
            this.direction = Direction.UP;
            return;
        }

        if (this.direction == Direction.RIGHT) {
            System.out.println("Вправо -> вниз");
            this.direction = Direction.DOWN;
            return;
        }
    }

    public void stepForward() {
        System.out.println("движение");
        if (direction == Direction.DOWN) {
            System.out.println("вниз");
            this.y--;
        }

        if (direction == Direction.UP) {
            System.out.println("вверх");
            this.y++;
        }

        if (direction == Direction.LEFT) {
            System.out.println("налево");
            this.x--;
        }

        if (direction == Direction.RIGHT) {
            System.out.println("направо");
            this.x++;
        }
    }
}

enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class Mem
{
    public static void actions(Robot robot, Direction necessaryDirection, int necessaryCoordinate, boolean robotCoord)
    {
        while(robot.getDirection() != necessaryDirection)
        {
            robot.turnRight();
        }

        if(robotCoord)
        {
            while(robot.getX() != necessaryCoordinate)
            {
                robot.stepForward();
            }
        }
        else
        {
            while(robot.getY() != necessaryCoordinate)
            {
                robot.stepForward();
            }
        }
    }

    public static void moveRobot(Robot robot, int toX, int toY)
    {
        if(robot.getX() < toX)
            actions(robot, Direction.RIGHT, toX, true);
        else if(robot.getX() > toX)
            actions(robot, Direction.LEFT, toX, true);

        if(robot.getY() < toY)
            actions(robot, Direction.UP, toY, false);
        else if(robot.getY() > toY)
            actions(robot, Direction.DOWN, toY, false);
    }

    public static void main(String[] args)
    {
        Robot robot = new Robot(0,0, Direction.UP);

        moveRobot(robot, 5, 5);
    }
}
*/

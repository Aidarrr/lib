import javafx.application.Application;
import javafx.scene.paint.Color;
import javafx.scene.shape.Line;
import javafx.scene.shape.Rectangle;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.Group;
import javafx.scene.text.Text;

import java.lang.reflect.Array;
import java.util.ArrayList;

class vec3d
{
    public double x, y, z;
    public vec3d(double x, double y, double z)
    {
        this.x = x; this.y = y; this.z = z;
    }
}

class triangle
{
    public ArrayList<vec3d> tri;
    public triangle(vec3d vec1, vec3d vec2, vec3d vec3)
    {
        tri = new ArrayList<vec3d>();
        tri.add(vec1);
        tri.add(vec2);
        tri.add(vec3);
    }
}

class Cube
{
    public ArrayList<triangle> cubeCoord;
    public Cube(triangle tr1, triangle tr2,triangle tr3, triangle tr4,triangle tr5, triangle tr6,
                triangle tr7, triangle tr8,triangle tr9, triangle tr10,triangle tr11, triangle tr12)
    {
        cubeCoord = new ArrayList<triangle>();
        cubeCoord.add(tr1);
        cubeCoord.add(tr2);
        cubeCoord.add(tr3);
        cubeCoord.add(tr4);
        cubeCoord.add(tr5);
        cubeCoord.add(tr6);
        cubeCoord.add(tr7);
        cubeCoord.add(tr8);
        cubeCoord.add(tr9);
        cubeCoord.add(tr10);
        cubeCoord.add(tr11);
        cubeCoord.add(tr12);
    }
}

public class Main extends Application
{
    static  int w = 16, h = 9;
    static  double theta = Math.PI / 2;
    static double a = (double) ( h / w);
    static  double F = 1 / Math.tan(theta / 2);
    static  double Znear = 0.1;
    static double Zfar = 1000.0;
    static double q = (Zfar/(Zfar - Znear));
    static Cube cube;
    static double[][] projMatrix =
    {
        {a * F,0,0,0 }, {0, F, 0, 0}, {0,0,q, 1}, {0, 0, -Znear * q, 0}
    };

    public static void projecting(vec3d vec)
    {
        double[] resArr = {0,0,0,0};
        double[] v = {vec.x, vec.y, vec.z, 1};
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                resArr[i] += v[i] * projMatrix[j][i];
            }
        }

        vec.x = resArr[0]/resArr[3];
        vec.y = resArr[1]/resArr[3];
        vec.z = resArr[2];

    }

    public static void cube2D(Cube cube3D)
    {
        for (triangle tri : cube3D.cubeCoord)
        {
            for (vec3d vec : tri.tri)
            {
                projecting(vec);
            }
        }
    }

    public static void main(String[] args)
    {

        Cube meshCube = new Cube
                (
                        //SOUTH
                        new triangle(new vec3d(0.0,0.0,0.0), new vec3d(0.0,1.0,0.0), new vec3d(1.0,1.0,0.0)),
                        new triangle(new vec3d(0.0,0.0,0.0), new vec3d(1.0,1.0,0.0), new vec3d(1.0,0.0,0.0)),

                        //EAST
                        new triangle(new vec3d(1.0,0.0,0.0), new vec3d(1.0,1.0,0.0), new vec3d(1.0,1.0,1.0)),
                        new triangle(new vec3d(1.0,0.0,0.0), new vec3d(1.0,1.0,1.0), new vec3d(1.0,0.0,1.0)),

                        //NORTH
                        new triangle(new vec3d(1.0,0.0,1.0), new vec3d(1.0,1.0,1.0), new vec3d(0.0,1.0,1.0)),
                        new triangle(new vec3d(1.0,0.0,1.0), new vec3d(0.0,1.0,1.0), new vec3d(0.0,0.0,1.0)),

                        //WEST
                        new triangle(new vec3d(0.0, 0.0, 1.0), new vec3d( 0.0, 1.0, 1.0), new vec3d( 0.0, 1.0, 0.0)),
                        new triangle(new vec3d(0.0, 0.0, 1.0), new vec3d( 0.0, 1.0, 0.0), new vec3d(  0.0, 0.0, 0.0)),

                        //TOP
                        new triangle(new vec3d(0.0, 1.0, 0.0), new vec3d(0.0, 1.0, 1.0), new vec3d(1.0,1.0,1.0)),
                        new triangle(new vec3d(0.0f, 1.0f, 0.0f), new vec3d( 1.0f, 1.0f, 1.0f), new vec3d(1.0f, 1.0f, 0.0f)),

                        //BOTTOM
                        new triangle(new vec3d(1.0, 0.0, 1.0), new vec3d(0.0,0.0,0.0), new vec3d(0.0,0.0,0.0)),
                        new triangle(new vec3d(1.0,0.0,1.0), new vec3d(0.0,0.0,0.0), new vec3d(1.0,0.0,0.0))
                );

        cube2D(meshCube);
        cube = meshCube;
        Application.launch(args);
    }



    @Override
    public void start(Stage stage)
    {
        Line[] lines = new Line[12];
        int i =0;
        for (triangle tri:cube.cubeCoord)
        {
            for (int j = 0; j < tri.tri.size(); j++)
            {
                var vec = tri.tri.get(j);
                var vecNext = tri.tri.get(j + 1);
                lines[i] = new Line(tri.tri.get(j).x, tri.tri.get(j).y, )
            }
        }


        Group group = new Group(lines);
        Scene scene = new Scene(group);
        scene.setFill(Color.BLACK);

        stage.setScene(scene);
        stage.setTitle("3D Cube");
        stage.setWidth(1024);
        stage.setHeight(1080);
        stage.show();
    }
}